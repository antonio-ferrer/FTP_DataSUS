using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace br.com.teczilla.lib
{
    public static class Util
    {

        private static readonly CultureInfo _ptBR;
        private static readonly CultureInfo _enUS;

        static Util()
        {
            _ptBR = new CultureInfo("pt-BR");
            _enUS = new CultureInfo("en-US");
        }
        public static bool IsInLinux()
        {

            return !RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        }

        public static Process Run(string processPath, string arguments, bool wait = true)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = processPath;
            proc.StartInfo.Arguments = arguments;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            if(wait)
                proc.WaitForExit();
            return proc;
        }

        public static string Bash(string cmd)
        {
            var args = new ProcessStartInfo();
            if (IsInLinux())
            {
                args.FileName = "/bin/bash";
                args.Arguments = $"-c \"{cmd.Replace("\"", "\\\"")}\"";
            }
            else
            {
                args.FileName = "cmd";
                args.Arguments = $"/C {cmd}";
            }

            args.RedirectStandardOutput = true;
            args.UseShellExecute = false;
            args.CreateNoWindow = true;

            var process = new Process { StartInfo = args };

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }


        public static string GetFriendlySize(ulong size)
        {
            string unit = "B";
            decimal val = size;
            if(val > 1000 && (val /= 1024) > 1)
            {
                unit = "KB";
                if(val > 1000 && (val /= 1024) > 1)
                {
                    unit = "MB";
                    if(val > 1000 &&(val /= 1024) > 1)
                    {
                        unit = "GB";
                        if(val > 1000 && (val /= 1024) > 1)
                        {
                            unit = "TB";
                        }
                    }
                }
            }
            return val.ToString("0.00", _ptBR) + " "+ unit;
        }

        public static void Wait(int? seconds = null)
        {
            seconds = seconds ?? 3;
            Thread.Sleep(TimeSpan.FromSeconds(seconds.Value));
        }

        public static void ThreadSafeExec(this Control ctrl, Action fx, Action<Exception> onfail = null)
        {
            try
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new Action(fx));
                }
                else
                    fx();
            }
            catch (Exception ex)
            {
                onfail?.Invoke(ex);
            }
        }


        private static string _ExecPath;

        public static string GetExecPath()
        {
            return _ExecPath ?? (_ExecPath =
            new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).Directory.FullName);
        }

    }
}
