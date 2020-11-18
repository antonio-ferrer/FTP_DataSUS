using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace br.com.teczilla.lib.dbf
{
    public class DBConvert
    {
        /*
         program: 'dbf2dbc',
            params: '"$dw0$file0" "$dw0$directory"'
         */

        public DBConvert(string directory)
        {
            this.Directory = directory;
        }

        public string Directory { get; }

        public bool DBC2DBF(FileInfo[] dbcFiles)
        {
            var localPath = Path.Combine(Util.GetExecPath(), "dbc", "dbf2dbc.exe");
            if (!File.Exists(localPath))
                throw new FileNotFoundException(localPath);
            foreach (var f in dbcFiles)
                Util.Run(localPath, $"\"{f.FullName}\" \"{this.Directory}\"", wait: true);
            return true;
        }
    }
}
