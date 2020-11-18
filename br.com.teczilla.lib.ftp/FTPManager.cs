using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace br.com.teczilla.lib.ftp
{
    public class FTPManager : IDisposable
    {

        private string _user, _pwd;
        FTPLink _server;
        private readonly CultureInfo _enUS;
        private readonly CultureInfo _currentCulture, _currentUICulture;
        private string[] _rawDirectoryContentList;
        private FTPDirectory _currentDirectory;
        private readonly Regex _rxFile;
        private readonly Regex _rxDir;
        private readonly Regex _rxDate;
        private bool _disposed = false;
        public Exception LastError
        {
            get;
            private set;
        }


        public FTPManager(string server)
        {
            _enUS = new CultureInfo("en-US");
            _currentCulture = Thread.CurrentThread.CurrentCulture;
            _currentUICulture = Thread.CurrentThread.CurrentUICulture;
            _rxDate = new Regex(@"^(?<date>\d{1,2}\-\d{1,2}\-\d{2,4})(\s|\t)+(?<time>\d{1,2}\:\d{2}(\:\d{2})?([a-z]{2})?)", RegexOptions.IgnoreCase);
            _rxDir = new Regex(_rxDate.ToString() + @"(\s|\t)+\<DIR\>(\s|\t)+(?<dir>.+)$", RegexOptions.IgnoreCase);
            _rxFile = new Regex(_rxDate.ToString() + @"(\s|\t)+(?<size>\d+)(\s|\t)+(?<file>\w.+)$", RegexOptions.IgnoreCase);
            LastError = null;
            this._server = server;
        }

        public bool? UsePassiveMode
        {
            get;
            set;
        }

        public FTPManager SetUser(string user, string pwd)
        {
            _user = user;
            _pwd = pwd;
            return this;
        }

        private void FillContent(string url)
        {
            try
            {
                _rawDirectoryContentList = null;
                _currentDirectory = new FTPDirectory(url);
                
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = _enUS;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                if (UsePassiveMode != null)
                    request.UsePassive = this.UsePassiveMode.Value;

                if (!string.IsNullOrEmpty(_user) && !string.IsNullOrEmpty(_pwd))
                {
                    request.Credentials = new NetworkCredential(_user, _pwd);
                }

                string names = "";
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            names = reader.ReadToEnd();
                            reader.Close();
                        }
                    }
                    response.Close();
                }
                _rawDirectoryContentList = names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (var data in _rawDirectoryContentList)
                {
                    var match = _rxDate.Match(data);
                    if (!match.Success) continue;
                    DateTime date = DateTime.Parse(match.Value, _enUS);
                    var dirMatch = _rxDir.Match(data);
                    var fileMatch = _rxFile.Match(data);
                    if (!dirMatch.Success && !fileMatch.Success)
                        continue;
                    if (dirMatch.Success)
                    {
                        _currentDirectory.AddContent(new FTPDirectory(dirMatch.Groups["dir"].Value, date, _currentDirectory));
                    }
                    else
                    {
                        _currentDirectory.AddContent(new FTPFile(
                            fileMatch.Groups["file"].Value,
                            ulong.Parse(fileMatch.Groups["size"].Value),
                            date, _currentDirectory));
                    }
                }

            }
            catch (Exception ex)
            {
                LastError = ex;
                
            }
        }

        /*
         FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://servername/filepath"));
request.Proxy = null;
request.Credentials = new NetworkCredential("user", "password");
request.Method = WebRequestMethods.Ftp.GetFileSize;

FtpWebResponse response = (FtpWebResponse)request.GetResponse();
long size = response.ContentLength;
response.Close();
         */

       

        /*public FTPDirectory GoBack()
        {
            if (_parent != null)
            {
                _currentContent = _parent;
                _parent = _parent?.Parent as FTPDirectory;
            }
            return _currentContent;
        }*/

        public FTPDirectory Load(FTPLink link = null)
        {
            FillContent(link?.URL ?? _server.URL);
            return _currentDirectory;
        }

        public bool? Download(DirectoryInfo localDirectory, Action<string, float> progress = null, IEnumerable<IFTPFile> filesToDownload = null)
        {
            filesToDownload = filesToDownload ?? GetFiles();
            float total = filesToDownload.Count(), idx = 0, currentPercent = 0;
            string currentFile = "";
            if (total == 0) return null;

            Action<float> localProgress = null;
            if (progress != null) localProgress = (percent) =>
            {
                if (percent == 100f)
                {
                    idx++;
                    percent = 0;
                }
                percent /= 100f;
                var val = ((idx + percent) / total) * 100f;
                currentPercent = val;
                if (currentPercent <= 99.99f)
                    progress(currentFile, currentPercent);
            };

            foreach(var file in filesToDownload)
            {
                currentFile = file.Name;
                if(!Download(file, localDirectory, localProgress))
                {
                    return false;
                }
            }
            progress?.Invoke("",100f);
            return true;
        }


        private FtpWebRequest GetFTPRequest(string url, string method = null)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(url));
            request.Method = method ?? WebRequestMethods.Ftp.DownloadFile;
            if (UsePassiveMode != null)
                request.UsePassive = UsePassiveMode.Value;
            if (!string.IsNullOrEmpty(_user) && !string.IsNullOrEmpty(_pwd))
            {
                request.Credentials = new NetworkCredential(_user, _pwd);
            }
            request.UseBinary = true;
            return request;
        }

        public ulong GetFileSize(IFTPFile file)
        {
            var request = GetFTPRequest(file.URL, WebRequestMethods.Ftp.GetFileSize);
            using(FtpWebResponse resp = (FtpWebResponse)request.GetResponse())
            {
                return (ulong)resp.ContentLength;
            }
        }

        public DateTime GetFileDate(IFTPFile file)
        {
            var request = GetFTPRequest(file.URL, WebRequestMethods.Ftp.GetDateTimestamp);
            using (FtpWebResponse resp = (FtpWebResponse)request.GetResponse())
            {
                return resp.LastModified;
            }
        }

        public bool Download(IFTPFile file, DirectoryInfo localDirectory, Action<float> progress = null)
        {
            try
            {
                if (!localDirectory.Exists)
                    localDirectory.Create();

                FtpWebRequest request = GetFTPRequest(file.URL, WebRequestMethods.Ftp.DownloadFile);
                string local = Path.Combine(localDirectory.FullName, file.Name);
                
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    using (Stream rs = response.GetResponseStream())
                    {
                        using (FileStream ws = new FileStream(local, FileMode.Create))
                        {
                            int bytesCount = 2048;
                            int times = 0;
                            float percent = 0;
                            byte[] buffer = new byte[bytesCount];
                            int bytesRead = rs.Read(buffer, 0, buffer.Length);
                            while (bytesRead > 0)
                            {
                                ws.Write(buffer, 0, bytesRead);
                                bytesRead = rs.Read(buffer, 0, buffer.Length);

                                if (file.FileSize > 0)
                                {
                                    ++times;
                                    percent = ((times * bytesCount) / (float)file.FileSize) * 100f;
                                    if (percent <= 99.999f)
                                        progress?.Invoke(percent);
                                }
                                else progress?.Invoke(-1);
                            }
                            progress?.Invoke(100f);
                        }
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                LastError = ex;
                return false;
            }
        }

        public IEnumerable<FTPFile> GetFiles()
        {
            return _currentDirectory?.GetFiles();
        }

        public FTPFile GetFile(string name)
        {
            return _currentDirectory?.GetFiles()?.FirstOrDefault(d => StringComparer.OrdinalIgnoreCase.Equals(d.Name, name));
        }

        public IEnumerable<FTPDirectory> GetDirectories()
        {
            return _currentDirectory?.GetDirectories();
        }

        public FTPDirectory GetDirectory(string name)
        {
            return _currentDirectory?.GetDirectories()?.FirstOrDefault(d => StringComparer.OrdinalIgnoreCase.Equals( d.Name , name));
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (!dispose)
                return;
            if (_disposed)
            {
                _disposed = true;
                _currentDirectory.ClearContent();
                _rawDirectoryContentList = null;
                _currentDirectory = null;
                if (_currentCulture.Name != _enUS.Name)
                {
                    Thread.CurrentThread.CurrentCulture = _currentCulture;
                }
                if (_currentUICulture.Name != _enUS.Name)
                {
                    Thread.CurrentThread.CurrentUICulture = _currentUICulture;
                }
            }
            else
                throw new ObjectDisposedException("FTPManager");
        }



    }
}
