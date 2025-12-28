namespace LFsystem.Views.Pages
{
    partial class ManageClaims
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
            lblPendingClaims = new Label();
            dgvClaims = new Guna.UI2.WinForms.Guna2DataGridView();
            id = new DataGridViewTextBoxColumn();
            item_id = new DataGridViewTextBoxColumn();
            claimant_name = new DataGridViewTextBoxColumn();
            claimant_contact = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            claim_date = new DataGridViewTextBoxColumn();
            btnView = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvClaims).BeginInit();
            SuspendLayout();
            // 
            // lblPendingClaims
            // 
            lblPendingClaims.AutoSize = true;
            lblPendingClaims.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPendingClaims.ForeColor = SystemColors.HotTrack;
            lblPendingClaims.Location = new Point(40, 20);
            lblPendingClaims.Name = "lblPendingClaims";
            lblPendingClaims.Size = new Size(232, 41);
            lblPendingClaims.TabIndex = 0;
            lblPendingClaims.Text = "Claims Request";
            // 
            // dgvClaims
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvClaims.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.HotTrack;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvClaims.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvClaims.ColumnHeadersHeight = 35;
            dgvClaims.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvClaims.Columns.AddRange(new DataGridViewColumn[] { id, item_id, claimant_name, claimant_contact, status, claim_date, btnView });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvClaims.DefaultCellStyle = dataGridViewCellStyle3;
            dgvClaims.GridColor = Color.FromArgb(231, 229, 255);
            dgvClaims.Location = new Point(40, 80);
            dgvClaims.Name = "dgvClaims";
            dgvClaims.RowHeadersVisible = false;
            dgvClaims.RowHeadersWidth = 51;
            dgvClaims.Size = new Size(741, 434);
            dgvClaims.TabIndex = 1;
            dgvClaims.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvClaims.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvClaims.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvClaims.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvClaims.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvClaims.ThemeStyle.BackColor = Color.White;
            dgvClaims.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvClaims.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvClaims.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvClaims.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvClaims.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvClaims.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvClaims.ThemeStyle.HeaderStyle.Height = 35;
            dgvClaims.ThemeStyle.ReadOnly = false;
            dgvClaims.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvClaims.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClaims.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvClaims.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvClaims.ThemeStyle.RowsStyle.Height = 29;
            dgvClaims.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvClaims.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // id
            // 
            id.HeaderText = "Claim ID";
            id.MinimumWidth = 6;
            id.Name = "id";
            // 
            // item_id
            // 
            item_id.HeaderText = "Item ID";
            item_id.MinimumWidth = 6;
            item_id.Name = "item_id";
            // 
            // claimant_name
            // 
            claimant_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            claimant_name.HeaderText = "Claimant";
            claimant_name.MinimumWidth = 6;
            claimant_name.Name = "claimant_name";
            claimant_name.Width = 95;
            // 
            // claimant_contact
            // 
            claimant_contact.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            claimant_contact.HeaderText = "Contact";
            claimant_contact.MinimumWidth = 6;
            claimant_contact.Name = "claimant_contact";
            claimant_contact.Width = 87;
            // 
            // status
            // 
            status.HeaderText = "Status";
            status.MinimumWidth = 6;
            status.Name = "status";
            // 
            // claim_date
            // 
            claim_date.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            claim_date.HeaderText = "Date";
            claim_date.MinimumWidth = 6;
            claim_date.Name = "claim_date";
            claim_date.Width = 68;
            // 
            // btnView
            // 
            btnView.HeaderText = "View";
            btnView.MinimumWidth = 6;
            btnView.Name = "btnView";
            btnView.Text = "View";
            btnView.UseColumnTextForButtonValue = true;
            // 
            // ManageClaims
            // 
            BackColor = Color.White;
            Controls.Add(dgvClaims);
            Controls.Add(lblPendingClaims);
            Name = "ManageClaims";
            Size = new Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)dgvClaims).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPendingClaims;
        private Guna.UI2.WinForms.Guna2DataGridView dgvClaims;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn item_id;
        private DataGridViewTextBoxColumn claimant_name;
        private DataGridViewTextBoxColumn claimant_contact;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn claim_date;
        private DataGridViewButtonColumn btnView;
    }
}
