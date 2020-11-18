using br.com.teczilla.teczftp.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace br.com.teczilla.teczftp
{
    class Program
    {
        private static string _lastFile;
       
        static void Main(string[] args)
        {
            InstallUtil();
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("= TECZFTP - Download de arquivos ftp =");
            Console.WriteLine("======================================\r\n");
            Console.WriteLine("\r\n<<FIAP Challenge - SANOFI - Grupo +Vida>>\r\n");
            Console.WriteLine("\tAntonio Ferrer (83398)");
            Console.WriteLine("\tHenrique Lima (83324)");
            Console.WriteLine("\tSidnei (82128)");
            Console.WriteLine("\tVictor Ribeiro (81969)");
            Console.WriteLine("\tWallace Sousa (82307)");
            Util.Wait();
            Console.Clear();
            Console.WriteLine("Atenção!");
            Console.WriteLine("Programa para uso estritamente acadêmico");
            Console.WriteLine("Não deve ser usado para outros fins comerciais sem o consentimento de seu(s) criador(es)");
            Util.Wait();
            Console.WriteLine("Pressione [C] para informações de contato ou aguarde...");
            var tsk = Task.Run(() =>
            {
                if(Console.ReadLine().ToUpper() == "C")
                {
                    Console.WriteLine("Antonio R. Ferrer - antonio.ferrer@gmx.com");
                    Process.Start("mailto:antonio.ferrer@gmx.com");
                }
            });
            tsk.Wait(TimeSpan.FromSeconds(3));

            Console.Clear();
            string configJs = args.FirstOrDefault() ?? "todo.js";

            if (!System.IO.File.Exists(configJs))
            {
                Console.WriteLine("arquivo de configuração não encontrado!");
                Console.WriteLine("a aplicação será encerrada");
                Util.Wait();
                return;
            }
            Console.WriteLine("Carregando informações de " + configJs);
            string config = System.IO.File.ReadAllText(configJs);
            JsonConfig jsonConfig = JsonConvert.DeserializeObject<JsonConfig>(config);
            if(jsonConfig != null && jsonConfig?.Downloads?.Count > 0)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Iniciando downloads...");
                    Util.Wait();
                    Console.Clear();
                    Console.WriteLine("@Start " + DateTime.Now + "\r\n\r\n");
                    DownloadManager dm = new DownloadManager(jsonConfig);
                    dm.Download(Progress);
                    Console.WriteLine("\r\n\r\n@End " + DateTime.Now);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Ocorreu o erro:\r\n" + ex);
                }
            }
            Console.WriteLine("\r\n\r\nO programa será encerrado em 3 segundos...");
            Util.Wait();
            
        }

        private static void InstallUtil()
        {
            if (!File.Exists("dbf2dbc.exe"))
            {
                //Properties.Resources.dbf2dbc
                File.WriteAllBytes("dbf2dbc.exe", Properties.Resources.dbf2dbc);
                File.WriteAllBytes("IMPBORL.dll", Properties.Resources.IMPBORL);
            }
            
        }


        private static void Progress(string file, float percent) 
        {
            
            Console.SetCursorPosition(0, 5);
            if (_lastFile == file)
            {
                Console.Write(percent.ToString("0.00") + "%                                   ");
            }
            else
            {
                _lastFile = file;
                Console.WriteLine("\r\nbaixando arquivo " + file + "                   ");
            }
            if(percent == 100)
            {
                Console.WriteLine("\r\nDownload concluído\r\n");
            }
        }

    }
}
