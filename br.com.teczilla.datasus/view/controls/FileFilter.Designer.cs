
namespace br.com.teczilla.datasus.view.controls
{
    partial class FileFilter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.tbxMinYear = new System.Windows.Forms.NumericUpDown();
            this.tbxMaxYear = new System.Windows.Forms.NumericUpDown();
            this.chkUF = new System.Windows.Forms.CheckBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkYear = new System.Windows.Forms.CheckBox();
            this.chkMonth = new System.Windows.Forms.CheckBox();
            this.lsbMonth = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsbUF = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.cboPrefix = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMaxYear)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(14, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(42, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Prefixo:";
            // 
            // tbxMinYear
            // 
            this.tbxMinYear.Location = new System.Drawing.Point(73, 19);
            this.tbxMinYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.tbxMinYear.Minimum = new decimal(new int[] {
            1970,
            0,
            0,
            0});
            this.tbxMinYear.Name = "tbxMinYear";
            this.tbxMinYear.Size = new System.Drawing.Size(67, 20);
            this.tbxMinYear.TabIndex = 3;
            this.tbxMinYear.Value = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            // 
            // tbxMaxYear
            // 
            this.tbxMaxYear.Location = new System.Drawing.Point(165, 19);
            this.tbxMaxYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.tbxMaxYear.Minimum = new decimal(new int[] {
            1970,
            0,
            0,
            0});
            this.tbxMaxYear.Name = "tbxMaxYear";
            this.tbxMaxYear.Size = new System.Drawing.Size(67, 20);
            this.tbxMaxYear.TabIndex = 4;
            this.tbxMaxYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // chkUF
            // 
            this.chkUF.AutoSize = true;
            this.chkUF.Location = new System.Drawing.Point(6, 19);
            this.chkUF.Name = "chkUF";
            this.chkUF.Size = new System.Drawing.Size(59, 17);
            this.chkUF.TabIndex = 5;
            this.chkUF.Text = "Estado";
            this.chkUF.UseVisualStyleBackColor = true;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(146, 23);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(13, 13);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "à";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkYear);
            this.groupBox1.Controls.Add(this.chkMonth);
            this.groupBox1.Controls.Add(this.lsbMonth);
            this.groupBox1.Controls.Add(this.tbxMaxYear);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.tbxMinYear);
            this.groupBox1.Location = new System.Drawing.Point(8, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 164);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Período";
            // 
            // chkYear
            // 
            this.chkYear.AutoSize = true;
            this.chkYear.Location = new System.Drawing.Point(6, 22);
            this.chkYear.Name = "chkYear";
            this.chkYear.Size = new System.Drawing.Size(45, 17);
            this.chkYear.TabIndex = 11;
            this.chkYear.Text = "Ano";
            this.chkYear.UseVisualStyleBackColor = true;
            // 
            // chkMonth
            // 
            this.chkMonth.AutoSize = true;
            this.chkMonth.Location = new System.Drawing.Point(6, 53);
            this.chkMonth.Name = "chkMonth";
            this.chkMonth.Size = new System.Drawing.Size(46, 17);
            this.chkMonth.TabIndex = 10;
            this.chkMonth.Text = "Mês";
            this.chkMonth.UseVisualStyleBackColor = true;
            // 
            // lsbMonth
            // 
            this.lsbMonth.FormattingEnabled = true;
            this.lsbMonth.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.lsbMonth.Location = new System.Drawing.Point(6, 76);
            this.lsbMonth.MultiColumn = true;
            this.lsbMonth.Name = "lsbMonth";
            this.lsbMonth.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbMonth.Size = new System.Drawing.Size(313, 82);
            this.lsbMonth.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lsbUF);
            this.groupBox2.Controls.Add(this.chkUF);
            this.groupBox2.Location = new System.Drawing.Point(339, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 164);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UF";
            // 
            // lsbUF
            // 
            this.lsbUF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbUF.FormattingEnabled = true;
            this.lsbUF.Location = new System.Drawing.Point(6, 49);
            this.lsbUF.MultiColumn = true;
            this.lsbUF.Name = "lsbUF";
            this.lsbUF.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbUF.Size = new System.Drawing.Size(325, 108);
            this.lsbUF.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(345, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(426, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(570, 14);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 12;
            // 
            // cboPrefix
            // 
            this.cboPrefix.FormattingEnabled = true;
            this.cboPrefix.Location = new System.Drawing.Point(62, 11);
            this.cboPrefix.Name = "cboPrefix";
            this.cboPrefix.Size = new System.Drawing.Size(265, 21);
            this.cboPrefix.TabIndex = 13;
            // 
            // FileFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CausesValidation = false;
            this.Controls.Add(this.cboPrefix);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblName);
            this.Name = "FileFilter";
            this.Size = new System.Drawing.Size(685, 212);
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMaxYear)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.NumericUpDown tbxMinYear;
        private System.Windows.Forms.NumericUpDown tbxMaxYear;
        private System.Windows.Forms.CheckBox chkUF;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkYear;
        private System.Windows.Forms.CheckBox chkMonth;
        private System.Windows.Forms.ListBox lsbMonth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lsbUF;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ComboBox cboPrefix;
    }
}
