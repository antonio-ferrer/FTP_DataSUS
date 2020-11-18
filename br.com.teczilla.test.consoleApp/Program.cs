using br.com.teczilla.lib.dbf;
using br.com.teczilla.lib.ftp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace br.com.teczilla.test.consoleApp
{
    class Program
    {
        //C:\temp\SIASUS\PARS9809.dbf
        private static void testFTP()
        {
            Regex rxCMD = new Regex(@"^(?<proc>([a-z]\:\\)?([^\\]+\\)*\w+(\.\w{3})?)(\s(?<params>.+))?", RegexOptions.IgnoreCase);

            FTPManager ftp = new FTPManager(@"ftp://ftp.datasus.gov.br/dissemin/publicos/SIASUS");
            var dir = ftp.Load();
            //ftp://ftp.datasus.gov.br/dissemin/publicos/SIASUS/199407_200712/Dados/
            dir = ftp.Load(dir["199407_200712"]);
            dir = ftp.Load(dir["Dados"]);

            Console.Clear();
            Console.WriteLine("Efetuando download");
            ftp.Download(new System.IO.DirectoryInfo(@"c:\temp\SUS_SIAUS"), (f, p) => {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(f + " - " + p.ToString("0.00") + "%                                                 ");
            });

            Console.WriteLine("Todos os arquivos foram baixados");
            Console.ReadLine();

            var files = ftp.GetFiles();

            Console.Clear();
            Console.WriteLine("Efetuando download");
            var file = dir["PAAC0602.dbc"];
            ftp.Download(file as FTPFile, new System.IO.DirectoryInfo(@"C:\temp"), (p) =>
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(p.ToString("0.00") + "% ");
                Thread.Sleep(100);
            });
            Console.WriteLine("Download concluido");
            Console.ReadLine();

            foreach (var ftpFile in files)
            {
                Console.WriteLine(ftpFile.Name);
            }
        }

        private static void testDBF()
        {
            using(DBFReader dbf = new DBFReader(@"C:\temp\SIASUS", DBVersion.Default))
            {
                var table1 = dbf.GetTable("PARS9809.dbf");
                StringBuilder sb = new StringBuilder();
                foreach(DataColumn col in table1.Columns)
                {
                    sb.Append(col.ColumnName).Append(';');
                }
                sb.Length--;
                sb.AppendLine();
                int maxCol = table1.Columns.Count;
                object value;
                foreach(DataRow row in table1.Rows)
                {
                    for(int i =0; i < maxCol; i++)
                    {
                        value =  (value=row[i]) == null ? "" : Convert.IsDBNull(value) ? "" : value;
                        sb.Append(value).Append(';');
                    }
                    sb.Length--;
                    sb.AppendLine();
                }
                sb.Length -= 2;

            }
        }
        static void Main(string[] args)
        {

            testDBF();
        }
    }
}
