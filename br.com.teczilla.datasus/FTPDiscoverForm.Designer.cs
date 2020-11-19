namespace br.com.teczilla.datasus
{
    partial class FTPDiscoverForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTPDiscoverForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.chkUseCache = new System.Windows.Forms.CheckBox();
            this.grpRepositories = new System.Windows.Forms.GroupBox();
            this.tabControlRepositories = new System.Windows.Forms.TabControl();
            this.tabRepo = new System.Windows.Forms.TabPage();
            this.dgFTP = new System.Windows.Forms.DataGridView();
            this.colFTPLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbxFTPURL = new System.Windows.Forms.TextBox();
            this.lblRootLink = new System.Windows.Forms.Label();
            this.tabExplorer = new System.Windows.Forms.TabPage();
            this.tabControlExplorer = new System.Windows.Forms.TabControl();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.grpFiles = new System.Windows.Forms.GroupBox();
            this.btnShowDirectory = new System.Windows.Forms.Button();
            this.btnCopyTo = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.fileFilter = new br.com.teczilla.datasus.view.controls.FileFilter();
            this.tabMiscellaneous = new System.Windows.Forms.TabPage();
            this.dgMiscellaneous = new System.Windows.Forms.DataGridView();
            this.colMiscName = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colMiscSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMiscDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMiscURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageMembers = new System.Windows.Forms.TabPage();
            this.dgMembers = new System.Windows.Forms.DataGridView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.grpRepositories.SuspendLayout();
            this.tabControlRepositories.SuspendLayout();
            this.tabRepo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFTP)).BeginInit();
            this.tabExplorer.SuspendLayout();
            this.tabControlExplorer.SuspendLayout();
            this.tabFiles.SuspendLayout();
            this.grpFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.grpFiltros.SuspendLayout();
            this.tabMiscellaneous.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMiscellaneous)).BeginInit();
            this.tabPageMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabHome);
            this.tabControl.Controls.Add(this.tabExplorer);
            this.tabControl.Controls.Add(this.tabPageMembers);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(855, 551);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.chkUseCache);
            this.tabHome.Controls.Add(this.grpRepositories);
            this.tabHome.Controls.Add(this.btnLoad);
            this.tabHome.Controls.Add(this.tbxFTPURL);
            this.tabHome.Controls.Add(this.lblRootLink);
            this.tabHome.Location = new System.Drawing.Point(4, 22);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(847, 525);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // chkUseCache
            // 
            this.chkUseCache.AutoSize = true;
            this.chkUseCache.Checked = true;
            this.chkUseCache.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseCache.Location = new System.Drawing.Point(689, 18);
            this.chkUseCache.Name = "chkUseCache";
            this.chkUseCache.Size = new System.Drawing.Size(81, 17);
            this.chkUseCache.TabIndex = 4;
            this.chkUseCache.Text = "Usar cache";
            this.chkUseCache.UseVisualStyleBackColor = true;
            // 
            // grpRepositories
            // 
            this.grpRepositories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRepositories.Controls.Add(this.tabControlRepositories);
            this.grpRepositories.Location = new System.Drawing.Point(8, 43);
            this.grpRepositories.Name = "grpRepositories";
            this.grpRepositories.Size = new System.Drawing.Size(833, 474);
            this.grpRepositories.TabIndex = 3;
            this.grpRepositories.TabStop = false;
            // 
            // tabControlRepositories
            // 
            this.tabControlRepositories.Controls.Add(this.tabRepo);
            this.tabControlRepositories.Location = new System.Drawing.Point(6, 19);
            this.tabControlRepositories.Name = "tabControlRepositories";
            this.tabControlRepositories.SelectedIndex = 0;
            this.tabControlRepositories.Size = new System.Drawing.Size(821, 449);
            this.tabControlRepositories.TabIndex = 1;
            // 
            // tabRepo
            // 
            this.tabRepo.Controls.Add(this.dgFTP);
            this.tabRepo.Location = new System.Drawing.Point(4, 22);
            this.tabRepo.Name = "tabRepo";
            this.tabRepo.Padding = new System.Windows.Forms.Padding(3);
            this.tabRepo.Size = new System.Drawing.Size(813, 423);
            this.tabRepo.TabIndex = 0;
            this.tabRepo.Text = "Repositórios";
            this.tabRepo.UseVisualStyleBackColor = true;
            // 
            // dgFTP
            // 
            this.dgFTP.AllowUserToAddRows = false;
            this.dgFTP.AllowUserToDeleteRows = false;
            this.dgFTP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFTP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFTP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFTP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFTPLink,
            this.colNome,
            this.colFiles,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFTP.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgFTP.Location = new System.Drawing.Point(6, 6);
            this.dgFTP.Name = "dgFTP";
            this.dgFTP.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFTP.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgFTP.Size = new System.Drawing.Size(801, 411);
            this.dgFTP.TabIndex = 0;
            this.dgFTP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFTP_CellClick);
            // 
            // colFTPLink
            // 
            this.colFTPLink.DataPropertyName = "FTPLink";
            this.colFTPLink.HeaderText = "";
            this.colFTPLink.Name = "colFTPLink";
            this.colFTPLink.ReadOnly = true;
            this.colFTPLink.Visible = false;
            // 
            // colNome
            // 
            this.colNome.DataPropertyName = "Name";
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 250;
            // 
            // colFiles
            // 
            this.colFiles.DataPropertyName = "FilesCount";
            this.colFiles.HeaderText = "Arquivos";
            this.colFiles.Name = "colFiles";
            this.colFiles.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.Text = "Explorar";
            this.colEdit.UseColumnTextForButtonValue = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(595, 14);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Listar";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tbxFTPURL
            // 
            this.tbxFTPURL.Location = new System.Drawing.Point(88, 16);
            this.tbxFTPURL.Name = "tbxFTPURL";
            this.tbxFTPURL.Size = new System.Drawing.Size(501, 20);
            this.tbxFTPURL.TabIndex = 1;
            this.tbxFTPURL.Text = "ftp://ftp.datasus.gov.br/dissemin/publicos";
            // 
            // lblRootLink
            // 
            this.lblRootLink.AutoSize = true;
            this.lblRootLink.Location = new System.Drawing.Point(7, 19);
            this.lblRootLink.Name = "lblRootLink";
            this.lblRootLink.Size = new System.Drawing.Size(79, 13);
            this.lblRootLink.TabIndex = 0;
            this.lblRootLink.Text = "Endereço FTP:";
            // 
            // tabExplorer
            // 
            this.tabExplorer.Controls.Add(this.tabControlExplorer);
            this.tabExplorer.Location = new System.Drawing.Point(4, 22);
            this.tabExplorer.Name = "tabExplorer";
            this.tabExplorer.Padding = new System.Windows.Forms.Padding(3);
            this.tabExplorer.Size = new System.Drawing.Size(847, 525);
            this.tabExplorer.TabIndex = 1;
            this.tabExplorer.Text = "Explorar";
            this.tabExplorer.UseVisualStyleBackColor = true;
            // 
            // tabControlExplorer
            // 
            this.tabControlExplorer.Controls.Add(this.tabFiles);
            this.tabControlExplorer.Controls.Add(this.tabMiscellaneous);
            this.tabControlExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlExplorer.Location = new System.Drawing.Point(3, 3);
            this.tabControlExplorer.Name = "tabControlExplorer";
            this.tabControlExplorer.SelectedIndex = 0;
            this.tabControlExplorer.Size = new System.Drawing.Size(841, 519);
            this.tabControlExplorer.TabIndex = 0;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.grpFiles);
            this.tabFiles.Controls.Add(this.grpFiltros);
            this.tabFiles.Location = new System.Drawing.Point(4, 22);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiles.Size = new System.Drawing.Size(833, 493);
            this.tabFiles.TabIndex = 0;
            this.tabFiles.Text = "Repositório";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // grpFiles
            // 
            this.grpFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiles.Controls.Add(this.btnShowDirectory);
            this.grpFiles.Controls.Add(this.btnCopyTo);
            this.grpFiles.Controls.Add(this.btnExport);
            this.grpFiles.Controls.Add(this.btnQuery);
            this.grpFiles.Controls.Add(this.btnDownload);
            this.grpFiles.Controls.Add(this.dgFiles);
            this.grpFiles.Location = new System.Drawing.Point(6, 251);
            this.grpFiles.Name = "grpFiles";
            this.grpFiles.Size = new System.Drawing.Size(821, 241);
            this.grpFiles.TabIndex = 1;
            this.grpFiles.TabStop = false;
            this.grpFiles.Text = "Arquivos";
            // 
            // btnShowDirectory
            // 
            this.btnShowDirectory.Location = new System.Drawing.Point(330, 23);
            this.btnShowDirectory.Name = "btnShowDirectory";
            this.btnShowDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnShowDirectory.TabIndex = 5;
            this.btnShowDirectory.Text = "Ver diretório";
            this.btnShowDirectory.UseVisualStyleBackColor = true;
            this.btnShowDirectory.Visible = false;
            this.btnShowDirectory.Click += new System.EventHandler(this.btnShowDirectory_Click);
            // 
            // btnCopyTo
            // 
            this.btnCopyTo.Location = new System.Drawing.Point(6, 23);
            this.btnCopyTo.Name = "btnCopyTo";
            this.btnCopyTo.Size = new System.Drawing.Size(75, 23);
            this.btnCopyTo.TabIndex = 4;
            this.btnCopyTo.Text = "Copiar para";
            this.btnCopyTo.UseVisualStyleBackColor = true;
            this.btnCopyTo.Click += new System.EventHandler(this.btnCopyTo_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(87, 23);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Exportar";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(168, 23);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "Ver Tabela";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(411, 23);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Visible = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // dgFiles
            // 
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.AllowUserToDeleteRows = false;
            this.dgFiles.AllowUserToOrderColumns = true;
            this.dgFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.Location = new System.Drawing.Point(3, 61);
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.ReadOnly = true;
            this.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFiles.Size = new System.Drawing.Size(815, 177);
            this.dgFiles.TabIndex = 0;
            // 
            // grpFiltros
            // 
            this.grpFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltros.Controls.Add(this.fileFilter);
            this.grpFiltros.Location = new System.Drawing.Point(6, 6);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(821, 239);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // fileFilter
            // 
            this.fileFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileFilter.CausesValidation = false;
            this.fileFilter.Count = 0;
            this.fileFilter.Location = new System.Drawing.Point(6, 19);
            this.fileFilter.Name = "fileFilter";
            this.fileFilter.Size = new System.Drawing.Size(809, 212);
            this.fileFilter.TabIndex = 0;
            this.fileFilter.OnSearch += new System.Action<br.com.teczilla.datasus.view.controls.FileFilterParameters>(this.fileFilter_OnSearch);
            // 
            // tabMiscellaneous
            // 
            this.tabMiscellaneous.Controls.Add(this.dgMiscellaneous);
            this.tabMiscellaneous.Location = new System.Drawing.Point(4, 22);
            this.tabMiscellaneous.Name = "tabMiscellaneous";
            this.tabMiscellaneous.Padding = new System.Windows.Forms.Padding(3);
            this.tabMiscellaneous.Size = new System.Drawing.Size(833, 493);
            this.tabMiscellaneous.TabIndex = 1;
            this.tabMiscellaneous.Text = "Complementos";
            this.tabMiscellaneous.UseVisualStyleBackColor = true;
            // 
            // dgMiscellaneous
            // 
            this.dgMiscellaneous.AllowUserToAddRows = false;
            this.dgMiscellaneous.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMiscellaneous.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgMiscellaneous.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMiscellaneous.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMiscName,
            this.colMiscSize,
            this.colMiscDate,
            this.colMiscURL});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMiscellaneous.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgMiscellaneous.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMiscellaneous.Location = new System.Drawing.Point(3, 3);
            this.dgMiscellaneous.Name = "dgMiscellaneous";
            this.dgMiscellaneous.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMiscellaneous.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgMiscellaneous.Size = new System.Drawing.Size(827, 487);
            this.dgMiscellaneous.TabIndex = 0;
            this.dgMiscellaneous.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMiscellaneous_CellClick);
            // 
            // colMiscName
            // 
            this.colMiscName.DataPropertyName = "Name";
            this.colMiscName.HeaderText = "Nome";
            this.colMiscName.Name = "colMiscName";
            this.colMiscName.ReadOnly = true;
            this.colMiscName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMiscName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colMiscSize
            // 
            this.colMiscSize.DataPropertyName = "Size";
            this.colMiscSize.HeaderText = "Tamanho";
            this.colMiscSize.Name = "colMiscSize";
            this.colMiscSize.ReadOnly = true;
            // 
            // colMiscDate
            // 
            this.colMiscDate.DataPropertyName = "Date";
            this.colMiscDate.HeaderText = "Data";
            this.colMiscDate.Name = "colMiscDate";
            this.colMiscDate.ReadOnly = true;
            // 
            // colMiscURL
            // 
            this.colMiscURL.DataPropertyName = "URL";
            this.colMiscURL.HeaderText = "URL";
            this.colMiscURL.Name = "colMiscURL";
            this.colMiscURL.ReadOnly = true;
            // 
            // tabPageMembers
            // 
            this.tabPageMembers.Controls.Add(this.dgMembers);
            this.tabPageMembers.Location = new System.Drawing.Point(4, 22);
            this.tabPageMembers.Name = "tabPageMembers";
            this.tabPageMembers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMembers.Size = new System.Drawing.Size(847, 525);
            this.tabPageMembers.TabIndex = 2;
            this.tabPageMembers.Text = "Grupo +Vida";
            this.tabPageMembers.UseVisualStyleBackColor = true;
            // 
            // dgMembers
            // 
            this.dgMembers.AllowUserToAddRows = false;
            this.dgMembers.AllowUserToDeleteRows = false;
            this.dgMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMembers.Location = new System.Drawing.Point(3, 3);
            this.dgMembers.Name = "dgMembers";
            this.dgMembers.ReadOnly = true;
            this.dgMembers.Size = new System.Drawing.Size(841, 519);
            this.dgMembers.TabIndex = 0;
            this.dgMembers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMembers_CellContentClick);
            // 
            // FTPDiscoverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 551);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FTPDiscoverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTPDataSUS - Discover [Grupo +Vida] - (FIAP/Sanofi Challenge) * USO COMERCIAL PRO" +
    "BIDO *";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTPDiscoverForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabHome.PerformLayout();
            this.grpRepositories.ResumeLayout(false);
            this.tabControlRepositories.ResumeLayout(false);
            this.tabRepo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFTP)).EndInit();
            this.tabExplorer.ResumeLayout(false);
            this.tabControlExplorer.ResumeLayout(false);
            this.tabFiles.ResumeLayout(false);
            this.grpFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.grpFiltros.ResumeLayout(false);
            this.tabMiscellaneous.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMiscellaneous)).EndInit();
            this.tabPageMembers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMembers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.GroupBox grpRepositories;
        private System.Windows.Forms.DataGridView dgFTP;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox tbxFTPURL;
        private System.Windows.Forms.Label lblRootLink;
        private System.Windows.Forms.CheckBox chkUseCache;
        private System.Windows.Forms.TabPage tabExplorer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFTPLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFiles;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.TabControl tabControlRepositories;
        private System.Windows.Forms.TabPage tabRepo;
        private System.Windows.Forms.TabControl tabControlExplorer;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.TabPage tabMiscellaneous;
        private System.Windows.Forms.DataGridView dgMiscellaneous;
        private System.Windows.Forms.DataGridViewButtonColumn colMiscName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMiscSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMiscDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMiscURL;
        private System.Windows.Forms.GroupBox grpFiltros;
        private view.controls.FileFilter fileFilter;
        private System.Windows.Forms.GroupBox grpFiles;
        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.Button btnCopyTo;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnShowDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabPage tabPageMembers;
        private System.Windows.Forms.DataGridView dgMembers;
    }
}