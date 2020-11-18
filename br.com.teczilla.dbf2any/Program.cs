using System;

namespace br.com.teczilla.dbf2any
{
    class Program
    {



        static Program()
        {
        }

        static void Main(string[] args)
        {
            Present();
            Console.ReadLine();

        }

        private static void Present()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("*              DBC 2 ANY                *");
            Console.WriteLine("*****************************************");
            Console.WriteLine();
            ConfigHelper.Wait();
            Console.WriteLine("Uma dádiva dos ninjas apresentada por\r\n\r\n");
            Console.WriteLine(AsciiArt.TecZillaSmall);
            Console.WriteLine("www.teczilla.com.br");

        }

        private static void ShowHelp()
        {
            
        }
    }
}
