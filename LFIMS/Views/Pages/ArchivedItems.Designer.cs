namespace LFsystem.Views.Pages
{
    partial class ArchivedItems
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblArchive = new Label();
            lblArchiveSub = new Label();
            lblRejected = new Label();
            dgvRejected = new Guna.UI2.WinForms.Guna2DataGridView();
            colItemID = new DataGridViewTextBoxColumn();
            colReportedById = new DataGridViewTextBoxColumn();
            colItem = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colLocation = new DataGridViewTextBoxColumn();
            colReportedBy = new DataGridViewTextBoxColumn();
            colDateTime = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colTimeRemaining = new DataGridViewTextBoxColumn();
            colView = new DataGridViewButtonColumn();
            lblDeleted = new Label();
            dgvDeleted = new Guna.UI2.WinForms.Guna2DataGridView();
            panelPagination = new Panel();
            lblPageInfo = new Label();
            btnNextPage = new Guna.UI2.WinForms.Guna2Button();
            btnPreviousPage = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvRejected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDeleted).BeginInit();
            panelPagination.SuspendLayout();
            SuspendLayout();
            // 
            // lblArchive
            // 
            lblArchive.AutoSize = true;
            lblArchive.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblArchive.ForeColor = SystemColors.HotTrack;
            lblArchive.Location = new Point(30, 20);
            lblArchive.Name = "lblArchive";
            lblArchive.Size = new Size(229, 41);
            lblArchive.TabIndex = 0;
            lblArchive.Text = "Archived Items";
            // 
            // lblArchiveSub
            // 
            lblArchiveSub.AutoSize = true;
            lblArchiveSub.Font = new Font("Segoe UI", 10.8F);
            lblArchiveSub.ForeColor = Color.Gray;
            lblArchiveSub.Location = new Point(30, 70);
            lblArchiveSub.Name = "lblArchiveSub";
            lblArchiveSub.Size = new Size(502, 25);
            lblArchiveSub.TabIndex = 1;
            lblArchiveSub.Text = "Manage items that were rejected or removed from the system";
            // 
            // lblRejected
            // 
            lblRejected.AutoSize = true;
            lblRejected.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRejected.ForeColor = Color.Black;
            lblRejected.Location = new Point(30, 110);
            lblRejected.Name = "lblRejected";
            lblRejected.Size = new Size(152, 28);
            lblRejected.TabIndex = 2;
            lblRejected.Text = "Rejected Items";
            // 
            // dgvRejected
            // 
            dgvRejected.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvRejected.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRejected.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRejected.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRejected.ColumnHeadersHeight = 50;
            dgvRejected.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvRejected.Columns.AddRange(new DataGridViewColumn[] { colItemID, colReportedById, colItem, colDescription, colType, colCategory, colLocation, colReportedBy, colDateTime, colStatus, colTimeRemaining, colView });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvRejected.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRejected.GridColor = Color.FromArgb(231, 229, 255);
            dgvRejected.Location = new Point(33, 141);
            dgvRejected.Name = "dgvRejected";
            dgvRejected.RowHeadersVisible = false;
            dgvRejected.RowHeadersWidth = 51;
            dgvRejected.RowTemplate.Height = 60;
            dgvRejected.Size = new Size(1507, 295);
            dgvRejected.TabIndex = 3;
            dgvRejected.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvRejected.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvRejected.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvRejected.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvRejected.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvRejected.ThemeStyle.BackColor = Color.White;
            dgvRejected.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvRejected.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvRejected.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRejected.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvRejected.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvRejected.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvRejected.ThemeStyle.HeaderStyle.Height = 50;
            dgvRejected.ThemeStyle.ReadOnly = false;
            dgvRejected.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvRejected.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRejected.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvRejected.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvRejected.ThemeStyle.RowsStyle.Height = 60;
            dgvRejected.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvRejected.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvRejected.CellContentClick += dgvRejected_CellContentClick;
            // 
            // colItemID
            // 
            colItemID.HeaderText = "Item ID";
            colItemID.MinimumWidth = 6;
            colItemID.Name = "colItemID";
            // 
            // colReportedById
            // 
            colReportedById.HeaderText = "Reporter ID";
            colReportedById.MinimumWidth = 6;
            colReportedById.Name = "colReportedById";
            colReportedById.Visible = false;
            // 
            // colItem
            // 
            colItem.HeaderText = "Title";
            colItem.MinimumWidth = 6;
            colItem.Name = "colItem";
            // 
            // colDescription
            // 
            colDescription.HeaderText = "Description";
            colDescription.MinimumWidth = 6;
            colDescription.Name = "colDescription";
            // 
            // colType
            // 
            colType.HeaderText = "Type";
            colType.MinimumWidth = 6;
            colType.Name = "colType";
            // 
            // colCategory
            // 
            colCategory.HeaderText = "Category";
            colCategory.MinimumWidth = 6;
            colCategory.Name = "colCategory";
            // 
            // colLocation
            // 
            colLocation.HeaderText = "Location";
            colLocation.MinimumWidth = 6;
            colLocation.Name = "colLocation";
            // 
            // colReportedBy
            // 
            colReportedBy.HeaderText = "Reported By";
            colReportedBy.MinimumWidth = 6;
            colReportedBy.Name = "colReportedBy";
            // 
            // colDateTime
            // 
            colDateTime.HeaderText = "Date Reported";
            colDateTime.MinimumWidth = 6;
            colDateTime.Name = "colDateTime";
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            // 
            // colTimeRemaining
            // 
            colTimeRemaining.HeaderText = "Time Remaining";
            colTimeRemaining.MinimumWidth = 6;
            colTimeRemaining.Name = "colTimeRemaining";
            // 
            // colView
            // 
            colView.HeaderText = "View";
            colView.MinimumWidth = 6;
            colView.Name = "colView";
            colView.ReadOnly = true;
            colView.Text = "View";
            colView.UseColumnTextForButtonValue = true;
            // 
            // lblDeleted
            // 
            lblDeleted.AutoSize = true;
            lblDeleted.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDeleted.ForeColor = Color.Black;
            lblDeleted.Location = new Point(27, 524);
            lblDeleted.Name = "lblDeleted";
            lblDeleted.Size = new Size(144, 28);
            lblDeleted.TabIndex = 4;
            lblDeleted.Text = "Deleted Items";
            // 
            // dgvDeleted
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvDeleted.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvDeleted.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvDeleted.ColumnHeadersHeight = 50;
            dgvDeleted.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvDeleted.DefaultCellStyle = dataGridViewCellStyle6;
            dgvDeleted.GridColor = Color.FromArgb(231, 229, 255);
            dgvDeleted.Location = new Point(27, 564);
            dgvDeleted.Name = "dgvDeleted";
            dgvDeleted.RowHeadersVisible = false;
            dgvDeleted.RowHeadersWidth = 51;
            dgvDeleted.RowTemplate.Height = 100;
            dgvDeleted.Size = new Size(1266, 250);
            dgvDeleted.TabIndex = 5;
            dgvDeleted.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvDeleted.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvDeleted.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvDeleted.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvDeleted.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvDeleted.ThemeStyle.BackColor = Color.White;
            dgvDeleted.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvDeleted.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvDeleted.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDeleted.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvDeleted.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvDeleted.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvDeleted.ThemeStyle.HeaderStyle.Height = 50;
            dgvDeleted.ThemeStyle.ReadOnly = false;
            dgvDeleted.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvDeleted.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDeleted.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvDeleted.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvDeleted.ThemeStyle.RowsStyle.Height = 100;
            dgvDeleted.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvDeleted.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // panelPagination
            // 
            panelPagination.Controls.Add(lblPageInfo);
            panelPagination.Controls.Add(btnNextPage);
            panelPagination.Controls.Add(btnPreviousPage);
            panelPagination.Location = new Point(1161, 453);
            panelPagination.Name = "panelPagination";
            panelPagination.Size = new Size(274, 40);
            panelPagination.TabIndex = 7;
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
            btnNextPage.CustomizableEdges = customizableEdges1;
            btnNextPage.DisabledState.BorderColor = Color.DarkGray;
            btnNextPage.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNextPage.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNextPage.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNextPage.Font = new Font("Segoe UI", 9F);
            btnNextPage.ForeColor = Color.White;
            btnNextPage.Location = new Point(196, 3);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnNextPage.Size = new Size(75, 30);
            btnNextPage.TabIndex = 1;
            btnNextPage.Text = "Next";
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Anchor = AnchorStyles.Left;
            btnPreviousPage.BorderRadius = 8;
            btnPreviousPage.CustomizableEdges = customizableEdges3;
            btnPreviousPage.DisabledState.BorderColor = Color.DarkGray;
            btnPreviousPage.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPreviousPage.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPreviousPage.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPreviousPage.Font = new Font("Segoe UI", 9F);
            btnPreviousPage.ForeColor = Color.White;
            btnPreviousPage.Location = new Point(3, 4);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPreviousPage.Size = new Size(75, 30);
            btnPreviousPage.TabIndex = 0;
            btnPreviousPage.Text = "Prev";
            btnPreviousPage.Click += btnPrevPage_Click;
            // 
            // ArchivedItems
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelPagination);
            Controls.Add(dgvDeleted);
            Controls.Add(lblDeleted);
            Controls.Add(dgvRejected);
            Controls.Add(lblRejected);
            Controls.Add(lblArchiveSub);
            Controls.Add(lblArchive);
            Name = "ArchivedItems";
            Size = new Size(1592, 734);
            ((System.ComponentModel.ISupportInitialize)dgvRejected).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDeleted).EndInit();
            panelPagination.ResumeLayout(false);
            panelPagination.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblArchive;
        private System.Windows.Forms.Label lblArchiveSub;
        private System.Windows.Forms.Label lblRejected;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRejected;
        private System.Windows.Forms.Label lblDeleted;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDeleted;
        private Panel panelPagination;
        private Label lblPageInfo;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2Button btnPreviousPage;
        private DataGridViewTextBoxColumn colItemID;
        private DataGridViewTextBoxColumn colReportedById;
        private DataGridViewTextBoxColumn colItem;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn colReportedBy;
        private DataGridViewTextBoxColumn colDateTime;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colTimeRemaining;
        private DataGridViewButtonColumn colView;
    }
}
