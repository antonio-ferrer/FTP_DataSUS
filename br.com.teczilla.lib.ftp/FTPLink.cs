using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace br.com.teczilla.lib.ftp
{
    public class FTPLink
    {

        private readonly Regex _rxSplitUrl;
        private readonly Regex _rxFTPLink;

        public string URL { get; set; }

        

        public string GetLinkName()
        {
           return _rxSplitUrl.Matches(this.URL)?.Cast<Match>()?.LastOrDefault()?.Groups[1]?.Value;
        }

        internal FTPLink() {

            _rxSplitUrl = new Regex(@"\/([^/]+)");
            _rxFTPLink = new Regex(@"^ftps?\:\/\/((\w+)\.?\/?)+", RegexOptions.IgnoreCase);
        }

        public FTPLink(string url) : this()
        {
            this.URL = _rxFTPLink.IsMatch(url) ? url : throw new ArgumentException("invalid ftp url");
        }

        public static implicit operator string (FTPLink lnk)
        {
            return lnk.URL;
        }

        public static implicit operator FTPLink (string url)
        {
            return new FTPLink(url);
        }
    }
}
