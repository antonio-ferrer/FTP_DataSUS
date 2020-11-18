using br.com.teczilla.lib.ftp;
using br.com.teczilla.teczftp.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace br.com.teczilla.teczftp
{
    public class DownloadManager
    {
        private readonly JsonConfig _config;
        private readonly List<Tuple<Download, List<string>>> _downloads;
        private DownloadManager() { }

        public DownloadManager(JsonConfig config)
        {
            _config = config;
            _downloads = new List<Tuple<Download, List<string>>>();
        }

        public bool Download(Action<string, float> progress = null)
        {
            _downloads.Clear();
            foreach (var config in _config.Downloads)
            {
                List<string> listOfFiles = new List<string>();
                using (var ftp = new FTPManager(config.Ftp))
                {
                    ftp.UsePassiveMode = _config.Passive;
                    ftp.SetUser(_config?.Credentials?.User, _config?.Credentials?.Pwd);
                    var ftpDir = ftp.Load();
                    var localDir = new DirectoryInfo(config.Directory);
                    IEnumerable<FTPFile> ftpFiles = null;
                    if (config?.Files?.Any() ?? false)
                    {
                        ftpFiles = config.Files.Select(f => ftp.GetFile(f));
                        listOfFiles.AddRange(ftpFiles.Select(f => f.Name));
                    }
                    else
                    {
                        listOfFiles.AddRange(ftp.GetFiles().Select(f => f.Name));
                    }

                    if (ftp.Download(localDir, progress, ftpFiles) == true)
                    {
                        _downloads.Add(new Tuple<Download, List<string>>(config, listOfFiles));
                    }
                }
                if (config?.WhenFinished?.Any() ?? false)
                {
                    HandleFinishedDownloads(config, listOfFiles);
                }
            }
            HandleFinishedDownloads(_downloads);
            return _config.Downloads.Count == _downloads.Count;
        }

        private void HandleFinishedDownloads(List<Tuple<Download, List<string>>> downloads)
        {
            if (!(_config?.WhenDone?.Any() == true)) return;
            foreach (var exec in _config.WhenDone)
            {
                if (string.IsNullOrEmpty(exec.Program)) continue;
                var matchDir = Regex.Matches(exec.Params, @"\$dw(\d+)");
                var @params = exec.Params;
                if (matchDir.Count > 0)
                {
                    var dirs = matchDir.Cast<Match>().Select(m => m.Value).Distinct();
                    foreach (var dir in dirs)
                    {
                        int dirIdx = int.Parse(Regex.Match(dir, @"\d+").Value);
                        @params = @params.Replace("$dw" + dirIdx, "");
                        @params = @params.Replace("$directory", downloads[dirIdx].Item1.Directory);
                        var matchFile = Regex.Match(@params, @"\$file(\d)");
                        if (matchFile.Success)
                        {
                            int fileIndex = int.Parse(matchFile.Groups[1].Value);
                            string localFile = Path.Combine(downloads[dirIdx].Item1.Directory, downloads[dirIdx].Item2[fileIndex]);
                            @params = @params.Replace(@"$file" + fileIndex, localFile);
                        }
                    }
                }

                ProcessStartInfo process = new ProcessStartInfo();
                process.FileName = exec.Program;
                process.Arguments = @params;
                if(process.FileName.ToLower() == "cmd")
                {
                    process.RedirectStandardOutput = true;
                    process.UseShellExecute = false;
                    process.CreateNoWindow = true;
                }
                if (!string.IsNullOrEmpty(process.FileName))
                {
                    Util.FailSafeExec(() =>
                    {
                        Process.Start(process);
                    });
                }
            }
        }

        private void HandleFinishedDownloads(Download download, List<string> files)
        {
            foreach (var exec in download.WhenFinished)
            {
                if (string.IsNullOrEmpty(exec.Program)) continue;
                string @params = exec.Params;
                @params = @params.Replace("$directory", download.Directory);
                var matchFile = Regex.Match(@params, @"\$file(\d+)");
                if (matchFile.Success)
                {
                    int fileIndex = int.Parse(matchFile.Groups[1].Value);
                    string localFile = Path.Combine(download.Directory, files[fileIndex]);
                    @params = @params.Replace(@"$file" + fileIndex, localFile);
                }
                ProcessStartInfo process = new ProcessStartInfo();
                process.FileName = exec.Program;
                process.Arguments = @params;
                if (process.FileName.ToLower() == "cmd")
                {
                    process.RedirectStandardOutput = true;
                    process.UseShellExecute = false;
                    process.CreateNoWindow = true;
                }
                if (!string.IsNullOrEmpty(process.FileName))
                {
                    Util.FailSafeExec(() =>
                    {
                        Process.Start(process);
                    });
                }
            }
        }
    }
}
