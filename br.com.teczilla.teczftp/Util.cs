using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace br.com.teczilla.teczftp
{
    public static class Util
    {
        public static void Wait(uint segundos)
        {
            Wait(TimeSpan.FromSeconds(segundos));
        }
        public static void Wait(TimeSpan? time = null)
        {
            time = time ?? TimeSpan.FromSeconds(3);
            DateTime max = DateTime.Now.Add(time.Value);
            while (DateTime.Now <= max)
            {
                Thread.Sleep(100);
            }
        }

        public static bool FailSafeExec(Action fx, bool autoWarning = true)
        {
            try
            {
                fx();
                return true;
            }
            catch(Exception ex)
            {
                if (autoWarning)
                {
                    Console.Clear();
                    Console.WriteLine("## Ocorreu a seguinte falha:\r\n\r\n{0}", ex);
                }
                return false;
            }
        }

    }
}
