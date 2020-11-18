using br.com.teczilla.lib;
using br.com.teczilla.lib.ftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using IOPath = System.IO.Path;

namespace br.com.teczilla.datasus.services
{
    public class DiscoverRepository : IDisposable
    {
        private lib.ftp.FTPManager _ftp;
        private Regex _rxFileExtension;
        private bool _disposed = false;
        private readonly static Dictionary<string, IEnumerable<DiscoveredRepository>> _data;
        private readonly List<Exception> _Errors;
        private Regex _rxDocExtension;
        private readonly static Dictionary<string, DiscoverRepository> _instances;
        public IEnumerable<Exception> Errors
        {
            get => _Errors.ToArray();

        }
        public static DiscoveredRepository CurrentRepository
        {
            get;
            set;
        }

        public static IEnumerable<DiscoveredRepository> CurrentRepositories
        {
            get;
            set;
        }

        public string FTP { get; set; }

        public IEnumerable<string> DataFileTypes { get; }

        public IEnumerable<string> DocFileTypes { get; }

        public int MinFilesCount { get; }

        static DiscoverRepository()
        {
            _data = new Dictionary<string, IEnumerable<DiscoveredRepository>>();
            _instances = new Dictionary<string, DiscoverRepository>(StringComparer.OrdinalIgnoreCase);
        }

        public DiscoverRepository(string ftpLink, string[] fileTypes = null, string[] docTypes = null, int minFiles = UFs.UF_Count)
        {
            _ftp = new lib.ftp.FTPManager(ftpLink);
            DataFileTypes = fileTypes ?? new string[] { "dbc", "dbf", "csv", "xml" };
            DocFileTypes = docTypes ?? new string[] { "doc", "docx", "txt", "pdf", "rtf", "zip" };
            FTP = ftpLink;
            MinFilesCount = minFiles;
            _Errors = new List<Exception>();
          
        }

        public static DiscoverRepository GetInstance(string ftpLink = null)
        {
            if (ftpLink != null)
            {
                if (!_instances.ContainsKey(ftpLink))
                {
                    _instances.Add(ftpLink, new DiscoverRepository(ftpLink));
                }
                return _instances[ftpLink];
            }
            if (_instances.Count > 0)
            {
                return _instances.FirstOrDefault().Value;
            }
            return null;
        }

        private string GetCachePath()
        {
            var dir = Util.GetExecPath();
            var cache = IOPath.Combine(dir, "repositories.xml");
            return cache;
        }
        private bool ReadCache(TimeSpan expires, out IEnumerable<DiscoveredRepository> repositories)
        {
            repositories = null;
            var cache = GetCachePath();
            try
            {
                if (File.Exists(cache))
                {
                    var xmlCache = XElement.Parse(File.ReadAllText(cache, Encoding.UTF8));
                    if (DateTime.TryParse(xmlCache.Attribute("date")?.Value, out DateTime date) && (DateTime.Now - date) <= expires)
                    {
                        repositories = Load(xmlCache);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                _Errors.Add(ex);
            };
            return false;
        }

        private IEnumerable<DiscoveredRepository> Load(XElement xml)
        {
            List<DiscoveredRepository> list = new List<DiscoveredRepository>();
            foreach (var xmlRep in xml.Elements("repository"))
            {
                DiscoveredRepository dr = new DiscoveredRepository() { Name = xmlRep.Attribute("name").Value };
                dr.Description = xmlRep?.Element("description")?.Value;
                dr.URL = xmlRep.Element("url").Value;
                var files = xmlRep.Element("files").Elements();
                var listFiles = new List<FlatFile>();
                dr.Files = listFiles;
                foreach (var xmlFile in files)
                {
                    listFiles.Add(new FlatFile(xmlFile));
                }
                var doc = xmlRep?.Element("miscellaneous");
                if (doc != null)
                {
                    dr.Miscellaneous = doc.Elements().Select(d => new FlatFile(d)).ToArray();
                }
                list.Add(dr);
            }
            return list.ToArray();
        }

        private void WriteCache(IEnumerable<DiscoveredRepository> repositories)
        {
            using (StreamWriter sw = new StreamWriter(GetCachePath(), false, Encoding.UTF8))
            {
                sw.WriteLine($"<repositories date=\"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\">");
                foreach (var rep in repositories)
                    sw.WriteLine(rep.ToXML());
                sw.WriteLine("</repositories>");
            }
        }

        public IEnumerable<DiscoveredRepository> Load(bool renewCache = false)
        {
            //memo cache
            string key = $"{FTP} - ({string.Join("-", this.DataFileTypes)})";
            if (!renewCache && _data.ContainsKey(key))
                return CurrentRepositories = _data[key];

            //file cache
            if (!renewCache && ReadCache(TimeSpan.FromHours(3), out IEnumerable<DiscoveredRepository> repositories))
            {
                _data.Add(key, repositories.ToArray());
                return CurrentRepositories = repositories;
            }

            //get from ftp 
            List<DiscoveredRepository> list = new List<DiscoveredRepository>();
            var directories = _ftp.Load(FTP).GetDirectories();
            foreach (var dir in directories)
            {

                List<FlatFile> misc = new List<FlatFile>();
                var dr = CheckRepository(dir.Name, dir, ref misc);
                if (dr != null)
                {
                    dr.Miscellaneous = misc;
                    list.Add(dr);
                }
            }

            repositories = list.ToArray();
            //fill memo chache
            if (!_data.ContainsKey(key))
                _data.Add(key, repositories);
            else
                _data[key] = repositories;

            //fill file cache
            Task.Run(() => WriteCache(list));

            return CurrentRepositories = _data[key];
        }

        private bool checkFile(FTPFile file)
        {
            this._rxFileExtension = this._rxFileExtension ?? new Regex(@"\.(" + string.Join("|", DataFileTypes) + ")$", RegexOptions.IgnoreCase);
            return _rxFileExtension.IsMatch(file.Name);
        }


        private bool checkMiscellaneousFile(FTPFile file)
        {
            this._rxDocExtension = this._rxDocExtension ?? new Regex(@"\.(" + string.Join("|", DocFileTypes) + ")$", RegexOptions.IgnoreCase);
            return _rxDocExtension.IsMatch(file.Name);
        }


        private void FillMiscellaneousFiles(string owner, IEnumerable<FTPFile> files, ref List<FlatFile> miscellaneousFiles)
        {
            /*var temp = IOPath.Combine(Util.GetExecPath(), owner);
            if (!Directory.Exists(temp))
                Directory.CreateDirectory(temp);*/
            foreach (var file in files)
            {
                FlatFile ff = new FlatFile()
                {
                    Date = file.Date,
                    FileSize = file.FileSize,
                    Name = file.Name,
                    URL = file.URL
                };
                miscellaneousFiles.Add(ff);
            }
        }


        private DiscoveredRepository CheckRepository(string name, FTPDirectory dir, ref List<FlatFile> miscellaneous)
        {
            DiscoveredRepository dr = null;
            var rawFiles = _ftp.Load(dir.URL)?.GetFiles();
            var files = rawFiles?.Where(f => checkFile(f));
            if (files?.Count() >= MinFilesCount)
            {
                dr = new DiscoveredRepository();
                dr.Files = files.ToArray();
                dr.URL = dir.URL;
                dr.Name = name;
                return dr;
            }
            else
            {
                var miscFiles = rawFiles?.Where(f => checkMiscellaneousFile(f));
                if (miscFiles?.Count() > 0)
                    FillMiscellaneousFiles(name, miscFiles, ref miscellaneous);
                var directories = _ftp.Load(dir)?.GetDirectories();
                if (directories?.Any() == true)
                {
                    foreach (var subDir in directories)
                    {
                        dr = CheckRepository(name, subDir, ref miscellaneous);
                        if (dr != null)
                            break;
                    }
                }
            }
            return dr;
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
        protected virtual void Dispose(bool dispose)
        {
            if (!dispose)
                return;
            if (_disposed)
            {
                throw new ObjectDisposedException("DiscoverRepository");
            }
            _disposed = true;
            _rxFileExtension = null;
            _ftp?.Dispose();
            _ftp = null;
        }

        public string GetRepositoryWorkingFolder(DiscoveredRepository rep, DiscoveredRepositoryCache target = DiscoveredRepositoryCache.Root)
        {
            return GetRepositoryWorkingFolder(rep.Name, target);
        }

        internal string GetRepositoryWorkingFolder(string repositoryName, DiscoveredRepositoryCache target = DiscoveredRepositoryCache.Root)
        {
            var path = IOPath.Combine(Util.GetExecPath(), repositoryName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (target == DiscoveredRepositoryCache.Root)
                return path;
            if (target == DiscoveredRepositoryCache.Files)
                path = IOPath.Combine(path, "files");
            else
                path = IOPath.Combine(path, "miscellaneous");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        internal bool Download(string repositoryName, DiscoveredRepositoryCache target, IEnumerable<IFTPFile> files)
        {
            var path = GetRepositoryWorkingFolder(repositoryName, target);
            return _ftp.Download(new DirectoryInfo(path), null, files) == true;
        }

    }
}
