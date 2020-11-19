using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace br.com.teczilla.lib.dbf
{
    public class DBConvert
    {
        private static string _workingDirectory;

        public static string GetWorkingDirectory()
        {
            if (!string.IsNullOrEmpty(_workingDirectory))
            {
                return _workingDirectory;
            }
            _workingDirectory = ConfigurationManager.AppSettings["working-directory"];
            if (string.IsNullOrWhiteSpace(_workingDirectory))
                _workingDirectory = @"c:\datasus\tmp";

            _workingDirectory = Path.Combine(_workingDirectory, "d"+Path.GetRandomFileName().Replace(".", ""));
            if (Directory.Exists(_workingDirectory))
                Directory.CreateDirectory(_workingDirectory);
            return _workingDirectory;
        }

        public static void ClearWorkingDirectory()
        {
            if (string.IsNullOrEmpty(_workingDirectory) || !Directory.Exists(_workingDirectory))
                return;
            var files = Directory.GetFiles(_workingDirectory, "*", SearchOption.AllDirectories);
            foreach (var f in files)
                File.Delete(f);
        }

        public static void PurgeWorkingDirectory()
        {
            ClearWorkingDirectory();
            if (Directory.Exists(_workingDirectory))
                Directory.Delete(_workingDirectory, true);
            _workingDirectory = null;
        }

        public DBConvert(string directory)
        {
            this.DirectoryTarget = directory;
        }

        public DBConvert() 
        {
            this.DirectoryTarget = GetWorkingDirectory();
        }

        public string DirectoryTarget { get; }


        private string changeName(string dbc)
        {
            return dbc.ToLower().TrimEnd('c') + "f";
        }

        public bool ConvertDBC2DBF(FileInfo[] dbcFiles, out IEnumerable<FileInfo> dbfFiles, bool deleteDBC = false)
        {
            List<FileInfo> dbfs = new List<FileInfo>();
            dbfFiles = null;
            var wk = GetWorkingDirectory();
            var tool = Path.Combine(Util.GetExecPath(), "dbc", "dbf2dbc.exe");
            if (!File.Exists(tool))
                throw new FileNotFoundException(tool);
            foreach (var f in dbcFiles)
            {
                Util.Run(tool, $"\"{f.FullName}\" \"{wk}\"", wait: true);
                FileInfo dbfFile;
                File.Move(Path.Combine(wk, changeName(f.Name)), (dbfFile = new FileInfo(Path.Combine(DirectoryTarget, changeName(f.Name)))).FullName);
                if (deleteDBC)
                    f.Delete();
                dbfs.Add(dbfFile);
            }
            dbfFiles = dbfs;
            return true;
        }
    }
}
