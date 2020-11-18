using br.com.teczilla.datasus.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace br.com.teczilla.datasus.view.controls
{
    public partial class FileFilter : UserControl
    {
        public FileFilter()
        {
            InitializeComponent();
            this.Load += FileFilter_Load;
        }

        private RepositoryFilter _repositoryFilter;

        public FileFilter SetFilter(RepositoryFilter filter)
        {
            _repositoryFilter = filter;
            FillData();
            return this;
        }

        private void FillData()
        {
            if (_repositoryFilter == null)
                return;
            int minYear = _repositoryFilter.MinYear ?? 1990;
            int maxYear = _repositoryFilter.MaxYear ?? DateTime.Now.Year;
            tbxMaxYear.Maximum = tbxMinYear.Maximum = maxYear;
            tbxMinYear.Minimum = tbxMaxYear.Minimum = minYear;
            tbxMaxYear.Value =  maxYear;
            tbxMinYear.Value = minYear;

            lsbUF.Items.AddRange(_repositoryFilter.UFs);
            
            cboPrefix.Items.AddRange(_repositoryFilter.Prefixes.Distinct().ToArray());
            if ((_repositoryFilter.Unmatched?.Count() ?? 0) > 0)
                cboPrefix.Items.Add(_repositoryFilter.Unmatched);
            if ((_repositoryFilter.Months?.Count() ?? 0) == 0)
            {
                chkMonth.Enabled = false;
                lsbMonth.Enabled = false;
            }
        }

        private void FileFilter_Load(object sender, EventArgs e)
        {
            if(_repositoryFilter != null)
            {
                FillData();
            }
            else
            {
                tbxMinYear.Maximum = tbxMaxYear.Maximum = tbxMaxYear.Value = DateTime.Now.Year;
                var ufs = UFs.GetUFs();
                lsbUF.Items.AddRange(ufs);
            }
        }

        public event Action<FileFilterParameters> OnSearch;

        public void Clear()
        {
            lsbUF.SelectedIndex = -1;
            lsbMonth.SelectedIndex = -1;
            chkMonth.Checked = chkUF.Checked = chkYear.Checked = false;
            cboPrefix.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            OnSearch?.Invoke(new FileFilterParameters());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FileFilterParameters ffp = new FileFilterParameters(_repositoryFilter);
            if (chkYear.Checked)
            {
                ffp.MinYear = Convert.ToInt32(tbxMinYear.Value);
                ffp.MaxYear = Convert.ToInt32(tbxMaxYear.Value);
            }
            else ffp.MinYear = ffp.MaxYear = null;

            if (chkUF.Checked)
            {
                ffp.UFs = lsbUF.SelectedItems.Cast<string>().ToArray();
            }
            else ffp.UFs = null;

            if (chkMonth.Checked)
            {
                ffp.Months = lsbMonth.SelectedIndices.Cast<int>().Select(i => i + 1).ToArray();
            }
            else ffp.Months = null;

            if (cboPrefix.SelectedIndex >= 0)
                ffp.Term = new string[] { cboPrefix.SelectedItem.ToString() };
            else
                ffp.Term = _repositoryFilter.Prefixes;

            OnSearch?.Invoke(ffp);
        }

        public int? Count
        {
            get => int.Parse("0" +  Regex.Match( lblCount.Text, @"\d+").Value);
            set => lblCount.Text = (value ?? 0) > 0 ? value  == 1 ? "1 item" : value + " itens" : "";
        }

    }
}
