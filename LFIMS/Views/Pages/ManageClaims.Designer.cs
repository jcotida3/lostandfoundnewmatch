namespace LFsystem.Views.Pages
{
    partial class ManageClaims
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2DataGridView dgvClaims;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.dgvClaims = new Guna.UI2.WinForms.Guna2DataGridView();

            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaims)).BeginInit();
            this.SuspendLayout();

            // panelMain
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Padding = new System.Windows.Forms.Padding(12);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.txtSearch);
            this.panelMain.Controls.Add(this.btnRefresh);
            this.panelMain.Controls.Add(this.dgvClaims);

            // lblTitle
            this.lblTitle.Text = "Manage Claims";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 12);

            // txtSearch
            this.txtSearch.PlaceholderText = "Search name / contact / notes...";
            this.txtSearch.Location = new System.Drawing.Point(16, 60);
            this.txtSearch.Size = new System.Drawing.Size(420, 38);
            this.txtSearch.BorderRadius = 6;

            // btnRefresh
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(450, 60);
            this.btnRefresh.Size = new System.Drawing.Size(100, 38);
            this.btnRefresh.BorderRadius = 6;

            // dgvClaims
            this.dgvClaims.Location = new System.Drawing.Point(16, 110);
            this.dgvClaims.Size = new System.Drawing.Size(920, 470);
            this.dgvClaims.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvClaims.ReadOnly = true;
            this.dgvClaims.RowHeadersVisible = false;
            this.dgvClaims.AllowUserToAddRows = false;
            this.dgvClaims.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // UserControl
            this.Controls.Add(this.panelMain);
            this.Size = new System.Drawing.Size(960, 600);

            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaims)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
