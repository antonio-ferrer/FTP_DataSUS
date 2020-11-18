using br.com.teczilla.lib;
using br.com.teczilla.lib.ftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace br.com.teczilla.datasus.services
{
    public class LocalRepositoryManager
    {
        private LocalRepositoryManager() { }
        private static readonly LocalRepositoryManager _instance;
        private static readonly Dictionary<string, LocalRepository> _repositories;
        static LocalRepositoryManager()
        {
            _instance = new LocalRepositoryManager();
            _repositories = new Dictionary<string, LocalRepository>();
        }

        public static LocalRepositoryManager GetInstance() => _instance;
       

        public void DownloadOrUpdate(LocalRepository rep, RepositoryFilter filter) 
        { 
        }

        public LocalRepository GetLocalRepository(DiscoveredRepository rep)
        {
            string key = $"{rep.Name}~{rep.URL}";
            LocalRepository local = null;
            if (_repositories.ContainsKey(key))
                local = _repositories[key];
            else
            {
                local = new LocalRepository { Name = rep.Name, URL = rep.URL };
                _repositories.Add(key, local);
            }
            local.WorkingDirectory = Path.Combine(Util.GetExecPath(), rep.Name);
            if(!Directory.Exists(local.WorkingDirectory))
            {
                Directory.CreateDirectory(local.WorkingDirectory);
            }
            var files = rep.Files.Select(f => GetFile(Path.Combine(local.WorkingDirectory, f.Name), f)).ToArray();
            local.LocalFiles = files;
            return local;
        }

        private LocalFile GetFile(string path, IFTPFile file)
        {
            LocalFile instance = new LocalFile
            {
                Date = file.Date,
                FileSize = file.FileSize,
                Name = file.Name,
                URL = file.URL,
                File = null
            };
            if (File.Exists(path))
                instance.File = new FileInfo(path);
            return instance;
        }

        

    }
}
