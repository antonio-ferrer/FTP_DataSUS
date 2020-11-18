using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanofi_Prototipo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
        }

        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("http://www2.datasus.gov.br/DATASUS/index.php?area=0901");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(chromeBrowser.Address);
            //BaixarArquivoFTP(@"ftp://ftp.datasus.gov.br/dissemin/publicos/SIASUS/199407_200712/Dados/", "", "", "");

            var r = ListFiles(@"ftp://ftp.datasus.gov.br/dissemin/publicos/SIASUS/199407_200712/Dados/");
        }

        private List<string> ListFiles(string url)
        {
            try
            {
                //ftp://ftp.datasus.gov.br/dissemin/publicos/
                //files: ftp://ftp.datasus.gov.br/dissemin/publicos/SIASUS/199407_200712/Dados/
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                // WebRequestMethods.Ftp.GetFileSize;

                request.Credentials = new NetworkCredential("anonymous", "");
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void BaixarArquivoFTP(string url, string local, string usuario, string senha)
        {
            try
            {

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(url));
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                //request.Credentials = new NetworkCredential(usuario, senha);
                request.UseBinary = true;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    using (Stream rs = response.GetResponseStream())
                    {
                        using (FileStream ws = new FileStream(local, FileMode.Create))
                        {
                            byte[] buffer = new byte[2048];
                            int bytesRead = rs.Read(buffer, 0, buffer.Length);
                            while (bytesRead > 0)
                            {
                                ws.Write(buffer, 0, bytesRead);
                                bytesRead = rs.Read(buffer, 0, buffer.Length);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
