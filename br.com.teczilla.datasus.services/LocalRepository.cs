using br.com.teczilla.lib.ftp;
using System;
using System.Collections.Generic;
using System.Text;

namespace br.com.teczilla.datasus.services
{
    public class LocalRepository : IRepository
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public IEnumerable<IFTPFile> Files { get => LocalFiles; set => throw new NotSupportedException(); }
        public string WorkingDirectory
        {
            get;
            set;
        }
        public IEnumerable<LocalFile> LocalFiles { get; set; }
        
    }
}
