using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace br.com.teczilla.lib.ftp
{
    public class FTPDirectory : FTPLink
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        private readonly List<FTPDirectory> _directories;

        private readonly List<FTPFile> _files;

        internal FTPDirectory() { }

        public FTPDirectory(string name, DateTime date, FTPLink parent)
        {
            this.Name = name;
            this.Date = date;
            _directories = new List<FTPDirectory>();
            _files = new List<FTPFile>();
            this.URL = parent.URL + "/" + (name ?? "");
        }

        public FTPDirectory(FTPLink self)
        {
            this.Name = self.GetLinkName();
            this.Date = default;
            _directories = new List<FTPDirectory>();
            _files = new List<FTPFile>();
            this.URL = self.URL.TrimEnd('/');
        }

        public bool IsEmpty
        {
            get => !(_directories.Any() || _files.Any());
        }

        public IEnumerable<FTPFile> GetFiles()
        {
            return _files.ToArray();
        }

        public IEnumerable<FTPDirectory> GetDirectories()
        {
            return _directories.ToArray();
        }

        internal FTPDirectory AddContent(FTPDirectory directory)
        {
            this._directories.Add(directory);
            return this;
        }

        internal FTPDirectory AddContent(FTPFile file)
        {
            this._files.Add(file);
            return this;
        }

        internal FTPDirectory ClearContent()
        {
            this._files.Clear();
            this._directories.Clear();
            return this;
        }

        public FTPLink this[string name]
        {
            get
            {
                FTPLink link = _directories.FirstOrDefault(d => StringComparer.OrdinalIgnoreCase.Equals(d.Name, name));
                return link ?? _files.FirstOrDefault(f => StringComparer.OrdinalIgnoreCase.Equals(f.Name, name));
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
