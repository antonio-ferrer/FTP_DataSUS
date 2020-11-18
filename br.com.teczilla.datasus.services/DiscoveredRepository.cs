using br.com.teczilla.lib.ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.teczilla.datasus.services
{

    public enum DiscoveredRepositoryCache
    {
        Root,
        Miscellaneous,
        Files
    }

    public  class DiscoveredRepository : IRepository
    {

        public IEnumerable<IFTPFile> Miscellaneous { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string URL { get; set; }

        public IEnumerable<IFTPFile> Files { get; set; }


        public override string ToString()
        {
            return $"Rep: \"{Name}\" - files:({Files?.Count() ?? 0})";
        }

        public string ToXML()
        {
            // <![CDATA[...]]>
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<repository name=\"{Name}\">");
            sb.AppendLine($"<description><![CDATA[{Description}]]></description>");
            sb.AppendLine($"<url><![CDATA[{URL}]]></url>");
            sb.AppendLine("<files>");
            if (Files?.Count() > 0)
                foreach (var file in Files)
                    sb.AppendLine(file.ToXML());
            sb.AppendLine("</files>");
            if(Miscellaneous?.Any() == true)
            {
                sb.AppendLine("<miscellaneous>");
                foreach(var item in Miscellaneous)
                {
                    sb.AppendLine(item.ToXML());
                }
                sb.AppendLine("</miscellaneous>");
            }
            sb.AppendLine("</repository>");
            return sb.ToString();
        }

    }
}