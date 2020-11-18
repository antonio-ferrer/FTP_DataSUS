using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace br.com.teczilla.datasus.view.controls
{
    public partial class FormProgress : Form
    {
        public FormProgress()
        {
            InitializeComponent();
        }

        public static void Run(Action act, Action<Exception> finish = null)
        {
            FormProgress fp = new FormProgress();
            fp.Load += (s, e) =>
            {
                fp.customProgress1.Config(act, 
                    (ex)=>
                    {
                        fp.customProgress1.ThreadSafeExec(fp.Close);
                        finish?.Invoke(ex);
                    });
                fp.customProgress1.Start();
            };
            fp.ShowDialog();
        }

       
    }
}
