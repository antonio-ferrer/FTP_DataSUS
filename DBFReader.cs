using System;
using System.Collections.Generic;
using System.Text;

namespace br.com.teczilla.lib.dbf
{
    public class DBFReader : IDisposable
    {

       // private OleDbConnection 

        public string FilePath
        {
            get;
            private set;
        }

        public DBFReader(string filePath, DBVersion version)
        {

        }



        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
