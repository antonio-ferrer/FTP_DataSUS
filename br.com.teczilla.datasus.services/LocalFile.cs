using br.com.teczilla.lib.ftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace br.com.teczilla.datasus.services
{
    public class LocalFile : FlatFile
    {

        public FileInfo File
        {
            get;
            set;
        }

       

    }
}
