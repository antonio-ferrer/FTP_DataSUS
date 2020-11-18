using br.com.teczilla.lib.ftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace br.com.teczilla.datasus.services
{
    public interface IRepository
    {
        string Name { get; set; }
        string Description { get; set; }
        string URL { get; set; }
        IEnumerable<IFTPFile> Files { get; set; }
    }
}
