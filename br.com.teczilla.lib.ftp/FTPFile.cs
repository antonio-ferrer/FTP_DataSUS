using System;
using System.Collections.Generic;
using System.Text;

namespace br.com.teczilla.lib.ftp
{
    public class FTPFile : FTPLink, IFTPFile
    {

        public string Name
        {
            get;
            set;
        }

        public ulong FileSize 
        { 
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public FTPFile(string name, ulong size, DateTime date, FTPDirectory parent)
        {
            this.Name = name;
            this.FileSize = size;
            this.Date = date;
            this.URL = parent.URL + "/" + name;
        }

        public override string ToString()
        {
            return Name + " " + FileSize + "b";
        }

        public string ToXML()
        {
            //<![CDATA[...]]>
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<file name=\"{Name}\" size=\"{FileSize}\" date=\"{Date:yyyy-MM-dd HH:mm:ss}\">");
            sb.AppendLine($"<url><![CDATA[{URL}]]></url>");
            sb.AppendLine("</file>");
            return sb.ToString();
        }
    }
}
