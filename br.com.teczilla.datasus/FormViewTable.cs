using br.com.teczilla.datasus.view.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace br.com.teczilla.datasus
{
    public partial class FormViewTable : Form
    {
        public FormViewTable()
        {
            InitializeComponent();
            this.Load += FormViewTable_Load;
            this.FormClosing += FormViewTable_FormClosing;
        }

        private void FormViewTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dbfs = System.IO.Directory.GetFiles(DirectoryPath, "*.DBF");
            if (dbfs?.Any() == true)
                foreach (var f in dbfs)
                    File.Delete(f);
        }

        private void FormViewTable_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            FormProgress.Run(LoadTables, (ex) =>
            {
                if (ex != null)
                    MessageBox.Show("Não possível carregar os dados da tabela!\r\n"+ ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        private void LoadTables()
        {
            using(var tableManager = new br.com.teczilla.lib.dbf.DBFReader(DirectoryPath, lib.dbf.DBVersion.Default))
            {
                foreach(var table in Tables)
                {
                    var content = tableManager.GetTable(table);
                    
                    var tab = new TabPage(table);
                    DataGridView grid = new DataGridView { AutoGenerateColumns = true };
                    tab.Controls.Add(grid);
                    grid.Dock = DockStyle.Fill;
                    grid.DataSource = content;
                    AddTab(tab);
                }
            }
        }

        private void AddTab(TabPage tab)
        {
            if (InvokeRequired)
                Invoke(new Action(() => tabControl1.TabPages.Add(tab)));
            else
                tabControl1.TabPages.Add(tab);
        }

        private string DirectoryPath { get; set; }

        private string[] Tables { get; set; }

        public static void ShowTables(string directoryPath, string[] tables)
        {
            FormViewTable form = new FormViewTable();
            form.DirectoryPath = directoryPath;
            form.Tables = tables;
            form.ShowDialog();
            
        }
    }
}
