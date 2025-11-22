namespace LFsystem.Views.Pages
{
    partial class ManageItems
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
            if (disposing)
            {
                titleFont?.Dispose();
                descFont?.Dispose();
                statusFont?.Dispose();
                searchTimer?.Dispose();
                components?.Dispose(); // always dispose designer components
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            lblManageItems = new Label();
            lblRole = new Label();
            pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            lblDepartment = new Label();
            lblLocation = new Label();
            lblCategory = new Label();
            lblStatus = new Label();
            cmbDepartment = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbLocation = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            searchBox = new Guna.UI2.WinForms.Guna2TextBox();
            searchfilter = new Label();
            pictureBox1 = new PictureBox();
            pnlTable = new Panel();
            tblItems = new Guna.UI2.WinForms.Guna2DataGridView();
            btnClearFilter = new Guna.UI2.WinForms.Guna2Button();
            panelPagination = new Panel();
            lblPageInfo = new Label();
            btnNextPage = new Guna.UI2.WinForms.Guna2Button();
            btnPreviousPage = new Guna.UI2.WinForms.Guna2Button();
            colItemId = new DataGridViewTextBoxColumn();
            colReportedById = new DataGridViewTextBoxColumn();
            colItem = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colLocation = new DataGridViewTextBoxColumn();
            colDepartment = new DataGridViewTextBoxColumn();
            colReportedBy = new DataGridViewTextBoxColumn();
            colDateTime = new DataGridViewTextBoxColumn();
            colActions = new DataGridViewButtonColumn();
            colDescription = new DataGridViewTextBoxColumn();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tblItems).BeginInit();
            panelPagination.SuspendLayout();
            SuspendLayout();
            // 
            // lblManageItems
            // 
            lblManageItems.AutoSize = true;
            lblManageItems.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManageItems.ForeColor = SystemColors.HotTrack;
            lblManageItems.Location = new Point(46, 29);
            lblManageItems.Name = "lblManageItems";
            lblManageItems.Size = new Size(143, 41);
            lblManageItems.TabIndex = 2;
            lblManageItems.Text = "All Items";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.ForeColor = Color.Gray;
            lblRole.Location = new Point(46, 70);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(448, 25);
            lblRole.TabIndex = 3;
            lblRole.Text = "View and manage all reported lost and found items";
            // 
            // pnlFilter
            // 
            pnlFilter.BorderColor = Color.DimGray;
            pnlFilter.BorderRadius = 20;
            pnlFilter.BorderThickness = 1;
            pnlFilter.Controls.Add(lblDepartment);
            pnlFilter.Controls.Add(lblLocation);
            pnlFilter.Controls.Add(lblCategory);
            pnlFilter.Controls.Add(lblStatus);
            pnlFilter.Controls.Add(cmbDepartment);
            pnlFilter.Controls.Add(cmbLocation);
            pnlFilter.Controls.Add(cmbCategory);
            pnlFilter.Controls.Add(cmbStatus);
            pnlFilter.Controls.Add(searchBox);
            pnlFilter.Controls.Add(searchfilter);
            pnlFilter.Controls.Add(pictureBox1);
            pnlFilter.CustomizableEdges = customizableEdges11;
            pnlFilter.Location = new Point(46, 109);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlFilter.Size = new Size(1112, 114);
            pnlFilter.TabIndex = 4;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartment.ForeColor = Color.Black;
            lblDepartment.Location = new Point(897, 34);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(101, 19);
            lblDepartment.TabIndex = 12;
            lblDepartment.Text = "Department";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLocation.ForeColor = Color.Black;
            lblLocation.Location = new Point(682, 34);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(74, 19);
            lblLocation.TabIndex = 11;
            lblLocation.Text = "Location";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategory.ForeColor = Color.Black;
            lblCategory.Location = new Point(484, 34);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(78, 19);
            lblCategory.TabIndex = 10;
            lblCategory.Text = "Category";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(292, 34);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(56, 19);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Status";
            // 
            // cmbDepartment
            // 
            cmbDepartment.BackColor = Color.Transparent;
            cmbDepartment.BorderRadius = 10;
            cmbDepartment.CustomizableEdges = customizableEdges1;
            cmbDepartment.DrawMode = DrawMode.OwnerDrawFixed;
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FillColor = Color.Gainsboro;
            cmbDepartment.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbDepartment.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbDepartment.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbDepartment.ForeColor = Color.FromArgb(68, 88, 112);
            cmbDepartment.ItemHeight = 30;
            cmbDepartment.Location = new Point(897, 56);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbDepartment.Size = new Size(198, 36);
            cmbDepartment.TabIndex = 8;
            // 
            // cmbLocation
            // 
            cmbLocation.BackColor = Color.Transparent;
            cmbLocation.BorderRadius = 10;
            cmbLocation.CustomizableEdges = customizableEdges3;
            cmbLocation.DrawMode = DrawMode.OwnerDrawFixed;
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocation.FillColor = Color.Gainsboro;
            cmbLocation.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbLocation.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbLocation.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbLocation.ForeColor = Color.FromArgb(68, 88, 112);
            cmbLocation.ItemHeight = 30;
            cmbLocation.Location = new Point(682, 57);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbLocation.Size = new Size(188, 36);
            cmbLocation.TabIndex = 7;
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.Transparent;
            cmbCategory.BorderRadius = 10;
            cmbCategory.CustomizableEdges = customizableEdges5;
            cmbCategory.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FillColor = Color.Gainsboro;
            cmbCategory.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbCategory.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbCategory.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbCategory.ForeColor = Color.FromArgb(68, 88, 112);
            cmbCategory.ItemHeight = 30;
            cmbCategory.Location = new Point(484, 57);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbCategory.Size = new Size(166, 36);
            cmbCategory.TabIndex = 6;
            // 
            // cmbStatus
            // 
            cmbStatus.BackColor = Color.Transparent;
            cmbStatus.BorderRadius = 10;
            cmbStatus.CustomizableEdges = customizableEdges7;
            cmbStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FillColor = Color.Gainsboro;
            cmbStatus.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbStatus.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbStatus.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbStatus.ForeColor = Color.FromArgb(68, 88, 112);
            cmbStatus.ItemHeight = 30;
            cmbStatus.Location = new Point(292, 56);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cmbStatus.Size = new Size(166, 36);
            cmbStatus.TabIndex = 5;
            // 
            // searchBox
            // 
            searchBox.BorderRadius = 10;
            searchBox.CustomizableEdges = customizableEdges9;
            searchBox.DefaultText = "";
            searchBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            searchBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            searchBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            searchBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            searchBox.FillColor = Color.Gainsboro;
            searchBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            searchBox.Font = new Font("Segoe UI", 9F);
            searchBox.ForeColor = Color.Black;
            searchBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            searchBox.Location = new Point(21, 57);
            searchBox.Margin = new Padding(3, 4, 3, 4);
            searchBox.Name = "searchBox";
            searchBox.PlaceholderForeColor = Color.FromArgb(64, 64, 64);
            searchBox.PlaceholderText = "⌕  Seach items, descriptions";
            searchBox.SelectedText = "";
            searchBox.ShadowDecoration.CustomizableEdges = customizableEdges10;
            searchBox.Size = new Size(241, 35);
            searchBox.TabIndex = 4;
            // 
            // searchfilter
            // 
            searchfilter.AutoSize = true;
            searchfilter.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchfilter.ForeColor = Color.Black;
            searchfilter.Location = new Point(58, 18);
            searchfilter.Name = "searchfilter";
            searchfilter.Size = new Size(126, 19);
            searchfilter.TabIndex = 3;
            searchfilter.Text = "Search and Filter";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.filter_icon;
            pictureBox1.Location = new Point(21, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(31, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlTable
            // 
            pnlTable.Controls.Add(tblItems);
            pnlTable.Location = new Point(46, 243);
            pnlTable.Name = "pnlTable";
            pnlTable.Size = new Size(1371, 575);
            pnlTable.TabIndex = 5;
            // 
            // tblItems
            // 
            tblItems.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            tblItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            tblItems.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            tblItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            tblItems.ColumnHeadersHeight = 50;
            tblItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tblItems.Columns.AddRange(new DataGridViewColumn[] { colItemId, colReportedById, colItem, colCategory, colType, colStatus, colLocation, colDepartment, colReportedBy, colDateTime, colActions, colDescription });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            tblItems.DefaultCellStyle = dataGridViewCellStyle9;
            tblItems.Dock = DockStyle.Fill;
            tblItems.GridColor = Color.FromArgb(231, 229, 255);
            tblItems.Location = new Point(0, 0);
            tblItems.Name = "tblItems";
            tblItems.RowHeadersVisible = false;
            tblItems.RowHeadersWidth = 51;
            tblItems.RowTemplate.Height = 100;
            tblItems.RowTemplate.ReadOnly = true;
            tblItems.Size = new Size(1371, 575);
            tblItems.TabIndex = 0;
            tblItems.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            tblItems.ThemeStyle.AlternatingRowsStyle.Font = null;
            tblItems.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            tblItems.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            tblItems.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            tblItems.ThemeStyle.BackColor = Color.White;
            tblItems.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            tblItems.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            tblItems.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            tblItems.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            tblItems.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            tblItems.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            tblItems.ThemeStyle.HeaderStyle.Height = 50;
            tblItems.ThemeStyle.ReadOnly = false;
            tblItems.ThemeStyle.RowsStyle.BackColor = Color.White;
            tblItems.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tblItems.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            tblItems.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            tblItems.ThemeStyle.RowsStyle.Height = 100;
            tblItems.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            tblItems.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // btnClearFilter
            // 
            btnClearFilter.BorderColor = Color.Transparent;
            btnClearFilter.BorderRadius = 20;
            btnClearFilter.BorderThickness = 1;
            btnClearFilter.Cursor = Cursors.Hand;
            btnClearFilter.CustomizableEdges = customizableEdges13;
            btnClearFilter.DisabledState.BorderColor = Color.DarkGray;
            btnClearFilter.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClearFilter.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClearFilter.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClearFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearFilter.ForeColor = Color.White;
            btnClearFilter.Location = new Point(1237, 156);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnClearFilter.Size = new Size(180, 45);
            btnClearFilter.TabIndex = 1;
            btnClearFilter.Text = "Clear FIlter";
            btnClearFilter.Click += BtnClearFilter_Click;
            // 
            // panelPagination
            // 
            panelPagination.Controls.Add(lblPageInfo);
            panelPagination.Controls.Add(btnNextPage);
            panelPagination.Controls.Add(btnPreviousPage);
            panelPagination.Location = new Point(1143, 838);
            panelPagination.Name = "panelPagination";
            panelPagination.Size = new Size(274, 40);
            panelPagination.TabIndex = 6;
            // 
            // lblPageInfo
            // 
            lblPageInfo.AutoSize = true;
            lblPageInfo.Location = new Point(100, 11);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(83, 20);
            lblPageInfo.TabIndex = 7;
            lblPageInfo.Text = "Page 1 of 1";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.Right;
            btnNextPage.BorderRadius = 8;
            btnNextPage.CustomizableEdges = customizableEdges15;
            btnNextPage.DisabledState.BorderColor = Color.DarkGray;
            btnNextPage.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNextPage.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNextPage.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNextPage.Font = new Font("Segoe UI", 9F);
            btnNextPage.ForeColor = Color.White;
            btnNextPage.Location = new Point(189, 5);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnNextPage.Size = new Size(75, 30);
            btnNextPage.TabIndex = 1;
            btnNextPage.Text = "Next";
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Anchor = AnchorStyles.Left;
            btnPreviousPage.BorderRadius = 8;
            btnPreviousPage.CustomizableEdges = customizableEdges17;
            btnPreviousPage.DisabledState.BorderColor = Color.DarkGray;
            btnPreviousPage.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPreviousPage.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPreviousPage.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPreviousPage.Font = new Font("Segoe UI", 9F);
            btnPreviousPage.ForeColor = Color.White;
            btnPreviousPage.Location = new Point(10, 5);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnPreviousPage.Size = new Size(75, 30);
            btnPreviousPage.TabIndex = 0;
            btnPreviousPage.Text = "Prev";
            // 
            // colItemId
            // 
            colItemId.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colItemId.HeaderText = "Id";
            colItemId.MinimumWidth = 6;
            colItemId.Name = "colItemId";
            colItemId.Width = 70;
            // 
            // colReportedById
            // 
            colReportedById.HeaderText = "ReportedById";
            colReportedById.MinimumWidth = 6;
            colReportedById.Name = "colReportedById";
            colReportedById.Visible = false;
            // 
            // colItem
            // 
            colItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colItem.DefaultCellStyle = dataGridViewCellStyle3;
            colItem.FillWeight = 598.930542F;
            colItem.HeaderText = "Item";
            colItem.MinimumWidth = 6;
            colItem.Name = "colItem";
            colItem.Width = 250;
            // 
            // colCategory
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCategory.DefaultCellStyle = dataGridViewCellStyle4;
            colCategory.FillWeight = 28.7242069F;
            colCategory.HeaderText = "Category";
            colCategory.MinimumWidth = 6;
            colCategory.Name = "colCategory";
            // 
            // colType
            // 
            colType.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colType.HeaderText = "Type";
            colType.MinimumWidth = 6;
            colType.Name = "colType";
            colType.Width = 92;
            // 
            // colStatus
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStatus.DefaultCellStyle = dataGridViewCellStyle5;
            colStatus.FillWeight = 28.7242069F;
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            // 
            // colLocation
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colLocation.DefaultCellStyle = dataGridViewCellStyle6;
            colLocation.FillWeight = 28.7242069F;
            colLocation.HeaderText = "Location";
            colLocation.MinimumWidth = 6;
            colLocation.Name = "colLocation";
            // 
            // colDepartment
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDepartment.DefaultCellStyle = dataGridViewCellStyle7;
            colDepartment.FillWeight = 28.7242069F;
            colDepartment.HeaderText = "Department";
            colDepartment.MinimumWidth = 6;
            colDepartment.Name = "colDepartment";
            // 
            // colReportedBy
            // 
            colReportedBy.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colReportedBy.DefaultCellStyle = dataGridViewCellStyle8;
            colReportedBy.FillWeight = 28.7242069F;
            colReportedBy.HeaderText = "Reported By";
            colReportedBy.MinimumWidth = 6;
            colReportedBy.Name = "colReportedBy";
            colReportedBy.Width = 120;
            // 
            // colDateTime
            // 
            colDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colDateTime.FillWeight = 28.7242069F;
            colDateTime.HeaderText = "Date & Time";
            colDateTime.MinimumWidth = 6;
            colDateTime.Name = "colDateTime";
            colDateTime.Width = 120;
            // 
            // colActions
            // 
            colActions.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colActions.FillWeight = 28.7242069F;
            colActions.HeaderText = "Actions";
            colActions.MinimumWidth = 6;
            colActions.Name = "colActions";
            colActions.Width = 160;
            // 
            // colDescription
            // 
            colDescription.HeaderText = "";
            colDescription.MinimumWidth = 6;
            colDescription.Name = "colDescription";
            colDescription.Visible = false;
            // 
            // ManageItems
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelPagination);
            Controls.Add(btnClearFilter);
            Controls.Add(pnlTable);
            Controls.Add(pnlFilter);
            Controls.Add(lblRole);
            Controls.Add(lblManageItems);
            Name = "ManageItems";
            Size = new Size(1400, 1000);
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tblItems).EndInit();
            panelPagination.ResumeLayout(false);
            panelPagination.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblManageItems;
        private Label lblRole;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDepartment;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLocation;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategory;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private Guna.UI2.WinForms.Guna2TextBox searchBox;
        private Label searchfilter;
        private Label lblDepartment;
        private Label lblLocation;
        private Label lblCategory;
        private Label lblStatus;
        private Panel pnlTable;
        private Guna.UI2.WinForms.Guna2DataGridView tblItems;
        private Guna.UI2.WinForms.Guna2Button btnClearFilter;
        private Panel panelPagination;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2Button btnPreviousPage;
        private Label lblPageInfo;
        private DataGridViewTextBoxColumn colItemId;
        private DataGridViewTextBoxColumn colReportedById;
        private DataGridViewTextBoxColumn colItem;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn colDepartment;
        private DataGridViewTextBoxColumn colReportedBy;
        private DataGridViewTextBoxColumn colDateTime;
        private DataGridViewButtonColumn colActions;
        private DataGridViewTextBoxColumn colDescription;
    }
}
