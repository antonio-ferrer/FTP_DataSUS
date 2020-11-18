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

namespace br.com.teczilla.datasus.view.controls
{
    public partial class FormExport : Form
    {
        public FormExport()
        {
            InitializeComponent();
            this.Load += FormExport_Load;
        }

        private void FormExport_Load(object sender, EventArgs e)
        {
            this.btnOK.Click += BtnOK_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Action<string> OK;

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Thread.Sleep(200);
                if (this.InvokeRequired)
                    this.Invoke(new Action(this.Close));
                else
                    this.Close();
            });
            OK?.Invoke(cboFormats.SelectedItem.ToString());
        }

        public static void OpenDialog(Action<string> callback)
        {
            FormExport fe = new FormExport() { OK = callback};
            fe.ShowDialog();
        }
    }
}
