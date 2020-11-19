using br.com.teczilla.datasus.services;
using br.com.teczilla.datasus.view.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using br.com.teczilla.lib;
using System.Xml.Linq;
using br.com.teczilla.lib.ftp;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using br.com.teczilla.lib.dbf;
using System.Configuration;

namespace br.com.teczilla.datasus
{
    public partial class FTPDiscoverForm : Form
    {
        public FTPDiscoverForm()
        {
            InitializeComponent();
            this.Load += FTPDiscoverForm_Load;
        }

        private void FTPDiscoverForm_Load(object sender, EventArgs e)
        {
            dgFTP.AutoGenerateColumns = false;
            tbxFTPURL.Text = ConfigurationManager.AppSettings["ftp-discover-root"];
        }

        private void DiscoverRepositories()
        {
            tabExplorer.Text = "Explorar";
            DiscoverRepository.CurrentRepository = null;
            //webBrowser.Navigate("about:blank");
            FormProgress.Run(() =>
            {
                DiscoverRepository dr = DiscoverRepository.GetInstance(tbxFTPURL.Text);
                var repositories = dr.Load(!chkUseCache.Checked);
                var rep = repositories.FirstOrDefault();
                XElement xml = XElement.Parse(rep.ToXML());
                this.ThreadSafeExec(() => {
                    dgFTP.DataSource = repositories.Select(r => new { Name = r.Name, FilesCount = r.Files?.Count(), FTPLink = r.URL }).ToArray();
                    chkUseCache.Checked = true;
                });
            });
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DiscoverRepositories();
        }

        private void dgFTP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colEdit.Index)
                return;
            string link = dgFTP.Rows[e.RowIndex].Cells[0].Value.ToString();
            var rep = DiscoverRepository.CurrentRepositories.FirstOrDefault(r => r.URL == link);
            DiscoverRepository.CurrentRepository = rep;
            tabExplorer.Text = rep.Name;
            tabControl.SelectedTab = tabExplorer;
            dgFTP.ClearSelection();
        }

        private void LoadHome()
        {
            tabControl.SelectedTab = tabHome;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var repository = DiscoverRepository.CurrentRepository;
            if (repository == null && tabControl.SelectedTab != tabHome && tabControl.SelectedTab != tabPageMembers)
            {
                LoadHome();
                MessageBox.Show("Selecione um repositório!", "Repositório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (tabControl.SelectedIndex)
            {
                case 1:
                    {
                        FillRepository();
                        FillMiscellaneous();
                    }
                    break;
                case 2:
                    {
                        var members = new[] { 
                            new { 
                                Nome = "Antonio Reynaldo Ferrer Junior",
                                RM = "83398",
                                GIT = "antonio-ferrer"
                            },
                            new
                            {
                                Nome = "Sidnei Gomes",
                                RM = "82128",
                                GIT = "SidneiVGomes"
                            },
                            new
                            {
                                Nome = "Victor Ribeiro",
                                RM = "81969",
                                GIT = "victorrib01"
                            },
                            new
                            {
                                Nome = "Wallace Santos de Sousa",
                                RM = "82307",
                                GIT = "Wallaceads"
                            },
                            new
                            {
                                Nome = "Henrique Roma de Lima",
                                RM = "83324",
                                GIT = "hrlima7"
                            }
                        
                        };
                        dgMembers.DataSource = members;
                        AutoResizeGrid(dgMembers);
                            
                    }
                    break;
            }
        }

        private void FillRepository()
        {
            var filter = FilterManager.ReverseFilter(DiscoverRepository.CurrentRepository.Files);
            fileFilter.SetFilter(filter);
            fileFilter_OnSearch(new FileFilterParameters(filter));
        }

        private void FillMiscellaneous()
        {
            dgMiscellaneous.AutoGenerateColumns = false;
            var data = DiscoverRepository.CurrentRepository?.Miscellaneous?
                .Select(m => new {
                    Name = m.Name,
                    Date = m.Date.ToString("dd/MM/yy HH:mm"),
                    URL = m.URL,
                    Size = Util.GetFriendlySize(m.FileSize)
                })?.ToArray();
            if (data == null)
                dgMiscellaneous.DataSource = null;
            else
                dgMiscellaneous.DataSource = data;

            AutoResizeGrid(dgMiscellaneous);
        }

        private void AutoResizeGrid(DataGridView dg)
        {
            Thread.Sleep(200);
            Application.DoEvents();
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dg.AutoSize = true;
            dg.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void dgMiscellaneous_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var disc = DiscoverRepository.GetInstance();
            var rep = DiscoverRepository.CurrentRepository;
            var item = DiscoverRepository.CurrentRepository.Miscellaneous.ToArray()[e.RowIndex];
            if(e.ColumnIndex == 0)
            {
                string path = "";
                FormProgress.Run(() =>
                {
                    path = disc.DownloadCache(rep.Name, DiscoveredRepositoryCache.Miscellaneous, new IFTPFile[] { item })?.FirstOrDefault()?.LocalPath;
                },
                (ex) =>
                {
                    if (ex == null) Process.Start(path);
                    else MessageBox.Show("Ocorreu a seguinte falha:\r\n" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
        }

        private void fileFilter_OnSearch(FileFilterParameters obj)
        {
            var files = DiscoverRepository.CurrentRepository.Files.ApplyFilter(obj.ToRepositoryFilter());
            var data = files.Select(f => new
            {
                Nome = f.Name,
                Data = f.Date.ToString("dd/MM/yy HH:mm"),
                Tamanho = Util.GetFriendlySize(f.FileSize),
                f.URL
            })?.OrderBy(d => d.Nome)?.ToArray();
            dgFiles.AutoGenerateColumns = true;
            dgFiles.DataSource = data;
            dgFiles.ClearSelection();
            fileFilter.Count = data.Count();
            AutoResizeGrid(dgFiles);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if(dgFiles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione ao menos um arquivo para fazer download!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var filesToDownload = GetSelectedFiles();
            var disc = DiscoverRepository.GetInstance();
            var rep = DiscoverRepository.CurrentRepository;
            FormProgress.Run(() => {
                disc.DownloadCache(rep.Name, DiscoveredRepositoryCache.Files, filesToDownload);
            },(ex)=> {
                if (ex == null)
                    MessageBox.Show("Arquivos baixados com sucesso", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Ocorreu a sequinte excessão:\r\n" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
            dgFiles.ClearSelection();
        }

        private IEnumerable<IFTPFile> GetSelectedFiles(string extension = null)
        {
            List<IFTPFile> selection = new List<IFTPFile>();
            var rep = DiscoverRepository.CurrentRepository;
            var allFiles = rep.Files;
            foreach (DataGridViewRow row in dgFiles.SelectedRows)
                selection.Add(allFiles.First(f => f.URL.ToLower() == row.Cells[3].Value.ToString().ToLower()));
            return selection?.Where(f=>extension == null || f.Name.ToLower().EndsWith(extension.ToLower()))?.ToArray();
        }

        private void btnShowDirectory_Click(object sender, EventArgs e)
        {
            var disc = DiscoverRepository.GetInstance();
            var rep = DiscoverRepository.CurrentRepository;
            string path = disc.GetRepositoryWorkingFolder(rep, DiscoveredRepositoryCache.Files);
            Process.Start("explorer", path);
        }

        private void btnCopyTo_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;
            var filesToDownload = GetSelectedFiles();
            var disc = DiscoverRepository.GetInstance();
            var rep = DiscoverRepository.CurrentRepository;
            FormProgress.Run(() => {
                var download = disc.DownloadCache(rep.Name, DiscoveredRepositoryCache.Files, filesToDownload);
                disc.CopyCacheTo(download, folderBrowserDialog1.SelectedPath);
            }, (ex) => {
                if (ex == null)
                {
                    MessageBox.Show("Arquivos copiados com sucesso", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(folderBrowserDialog1.SelectedPath);
                }
                else
                    MessageBox.Show("Ocorreu a sequinte excessão:\r\n" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            });
            dgFiles.ClearSelection();
        }
        /*
        private void ExportDBF(Action<IEnumerable<FileInfo>> callBack)
        {
            var filesToDownload = GetSelectedFiles();
            var disc = DiscoverRepository.GetInstance();
            var rep = DiscoverRepository.CurrentRepository;
            var convert = new DBConvert(folderBrowserDialog1.SelectedPath);
            var download = disc.DownloadCache(rep.Name, DiscoveredRepositoryCache.Files, filesToDownload);
            var localFiles = disc.CopyCacheTo(download, folderBrowserDialog1.SelectedPath);
            convert.ConvertDBC2DBF(localFiles.ToArray());
            foreach (var lf in localFiles)
                lf.Delete();
            callBack?.Invoke( localFiles.Select(f => new FileInfo(f.FullName.ToLower().TrimEnd('c') + "f"))?.ToArray());
            //return convert;
        }

        private void ExportLocalDBF(Action<IEnumerable<FileInfo>> callBack)
        {
            var filesToDownload = GetSelectedFiles();
            var disc = DiscoverRepository.GetInstance();
            var rep = DiscoverRepository.CurrentRepository;
            var wk = Path.Combine(@"c:\temp\sus", rep.Name);
            if (!Directory.Exists(wk))
                Directory.CreateDirectory(wk);
            var convert = new DBConvert(wk);
            var download = disc.DownloadCache(rep.Name, DiscoveredRepositoryCache.Files, filesToDownload);
            var localFiles = disc.CopyCacheTo(download, wk);
            convert.ConvertDBC2DBF(localFiles.ToArray());
            foreach (var lf in localFiles)
                lf.Delete();
            callBack?.Invoke(localFiles.Select(f => new FileInfo(f.FullName.ToLower().TrimEnd('c') + "f"))?.ToArray());
            //return convert;
        }*/

        private void btnExport_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = @"C:\";
            var selected = GetSelectedFiles("dbc");
            if ((selected?.Count() ?? 0) == 0)
            {
                MessageBox.Show("Selecione ao menos um arquivo compatível (.dbc)!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var files = GetSelectedFiles().Where(f => f.Name.ToLower().EndsWith("dbc"));
            if(files?.Count() != selected?.Count())
            {
                MessageBox.Show("Apenas arquivos no formato DBC podem ser exportados para outros formatos\r\nOutras extensões serão ignoradas no processo", 
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string type = "";
            FormExport.OpenDialog((format) => {
                type = format;
            });
            if (string.IsNullOrEmpty(type))
                return;
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;
            var workingFolder = DBConvert.GetWorkingDirectory();
            var filesToDownload = GetSelectedFiles();
            var disc = DiscoverRepository.GetInstance();
            var rep = DiscoverRepository.CurrentRepository;
            type = Regex.Match(type, @"\w+", RegexOptions.IgnoreCase).Value.ToUpper();

            IEnumerable<FileInfo> dbfs = null;

            Action callbackExport = () =>
            {
                disc.ExportFiles2DBF(filesToDownload, (d) => dbfs = d, workingFolder);
            };
            var tableManager = new DBFReader(workingFolder, DBVersion.Default);
            bool tdbf = false;
            switch (type)
            {
                case "DBF":
                    tdbf = true;
                    callbackExport += () => {
                        tdbf = true;
                    };
                    break;

                case "XML":
                    callbackExport += () =>
                    {
                        if (dbfs?.Any() != true)
                            return;
                        foreach(var dbf in dbfs)
                        {
                            tableManager.ToXML(dbf.Name);
                        }
                    };
                    break;

                case "CSV":
                    callbackExport += () =>
                    {
                        if (dbfs?.Any() != true)
                            return;
                        foreach (var dbf in dbfs)
                        {
                            tableManager.ToCSV(dbf.Name);
                        }
                    };
                    break;

                case "JSON":
                    callbackExport += () =>
                    {
                        if (dbfs?.Any() != true)
                            return;
                        foreach (var dbf in dbfs)
                        {
                            tableManager.ToJSON(dbf.Name);
                        }
                    };
                    break;
            }
            if (!tdbf)
            {
                callbackExport += () =>
                {
                    if (dbfs?.Any() != true)
                        return;
                    foreach (var dbf in dbfs)
                    {
                        dbf.Delete();
                    }
                };
            }
            else
            {
                callbackExport += () =>
                {
                    if (dbfs?.Any() != true)
                        return;
                    foreach (var dbf in dbfs)
                    {
                        dbf.MoveTo(Path.Combine(folderBrowserDialog1.SelectedPath, dbf.Name));
                    }
                };
            }
            callbackExport += () =>
            {
                tableManager.Dispose();
                //MessageBox.Show("Arquivos exportados com sucesso", "Conversão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("explorer", folderBrowserDialog1.SelectedPath);
            };
            

            FormProgress.Run(callbackExport, (ex) => 
            {
                if(ex != null)
                {
                    MessageBox.Show("Ocorreu a sequinte excessão:\r\n" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });
        }

        private void ShowError(Exception ex)
        {
            if (ex == null) return;
            MessageBox.Show("Erro ao realizar operação!\r\n" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            var files = GetSelectedFiles("dbc");
            if(files == null || !files.Any())
            {
                MessageBox.Show("Selecione ao menos um arquivo compatível (.dbc)", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            IEnumerable<FileInfo> dbfs = null;
            FormProgress.Run(() =>
            {
                DiscoverRepository.GetInstance().ExportFiles2DBF(files, f=>dbfs=f);
            }, ShowError);

            if(dbfs?.Any() == true)
            {
                var wk = dbfs.First().Directory.FullName;
                FormViewTable.ShowTables(wk, dbfs.Select(f => f.Name).ToArray());
            }
        }

        private void dgMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 2)
                return;
            //https://github.com/antonio-ferrer
            Process.Start(@"https://github.com/" + dgMembers[2, e.RowIndex].Value.ToString());
        }

        private void FTPDiscoverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBConvert.PurgeWorkingDirectory();
        }
    }
}
