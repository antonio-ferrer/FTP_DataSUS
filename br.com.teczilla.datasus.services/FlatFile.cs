using br.com.teczilla.lib.ftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace br.com.teczilla.datasus.services
{
    public class FlatFile : IFTPFile
    {
        protected XElement _xml;

        public virtual string Name { get; set; }
        public ulong FileSize { get;  set; }
        public DateTime Date { get; set; }
        public string URL { get; set; }

        public FlatFile() { }

        public FlatFile(XElement xml)
        {
            this._xml = xml;
            Name = xml.Attribute("name").Value;
            Date = DateTime.Parse(xml.Attribute("date").Value);
            FileSize = ulong.Parse(xml.Attribute("size").Value);
            URL = xml.Element("url").Value;
        }

        public virtual string ToXML()
        {
            if(_xml == null)
            {
                _xml = new XElement("file",
                    new XAttribute("name", Name),
                    new XAttribute("date", Date.ToString("yyyy-MM-dd HH:mm:ss")),
                    new XAttribute("size", FileSize),
                    new XElement("url", new XCData(URL)));
            }
            return _xml.ToString();
        }
    }

    public class CachedFile : FlatFile,  IFTPFile
    {

        private string _LocalPath;
        public string LocalPath {
            get => _LocalPath;
            set
            {
                if (value != null)
                {
                    var dir = new FileInfo(value).Directory.FullName;
                    _LocalPath = Path.Combine(dir, GetSafeName());
                }
                else
                    _LocalPath = null;
            }
        }
        private string _name;
        public override string Name { get => _name; set => _name = value; }

        string IFTPFile.Name { get => GetSafeName(); set => base.Name = value; }
        ulong IFTPFile.FileSize { get => this.FileSize; set => this.FileSize = value; }
        DateTime IFTPFile.Date { get => this.Date; set => this.Date = value; }
        string IFTPFile.URL { get => this.URL; set => this.URL = value; }

        public CachedFile() : base() { }

        public CachedFile(XElement xml) : base(xml) 
        {
            LocalPath = xml.Element("local-path")?.Value;
        }

        public override string ToXML()
        {
            XElement xml = XElement.Parse( base.ToXML());
            if (xml.Element("local-path") != null)
            {
                xml.Element("local-path").Remove();
            }
            xml.Add(new XElement("local-path", new XCData(LocalPath)));
            return xml.ToString();
        }

        public string GetSafeName()
        {
            return $"{GetHashFileCode(this)}_{_name}";
        }

        public static string GetHashFile(IFTPFile file)
        {
            string name = (file as CachedFile)?._name ?? file.Name;
            return $"{name}:{file.URL.ToLower()}:{file.FileSize}:{file.Date:yyyyMMddHHmmss}";
        }

        public static string GetHashFileCode(IFTPFile file)
        {
            int value =  GetHashFile(file).GetHashCode();
            if (value < 0)
                return "N" + (value *= -1);
            else
                return value.ToString();
        }

        string IFTPFile.ToXML()
        {
            return this.ToXML();
        }
    }
}
