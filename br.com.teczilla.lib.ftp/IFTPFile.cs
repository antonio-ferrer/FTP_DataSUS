using System;
using System.Collections.Generic;
using System.Text;

namespace br.com.teczilla.lib.ftp
{
    public interface IFTPFile
    {
        string Name
        {
            get;
            set;
        }

        ulong FileSize
        {
            get;
            set;
        }

        DateTime Date
        {
            get;
            set;
        }

        string URL
        {
            get;
            set;
        }

        string ToXML();
    }
}
