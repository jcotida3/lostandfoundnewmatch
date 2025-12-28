namespace LFsystem.Views.Components
{
    partial class ClaimCard
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblContact;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNotes;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2Button btnApprove;
        private Guna.UI2.WinForms.Guna2Button btnReject;
        private Guna.UI2.WinForms.Guna2Button btnRespond;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblContact = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNotes = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnApprove = new Guna.UI2.WinForms.Guna2Button();
            this.btnReject = new Guna.UI2.WinForms.Guna2Button();
            this.btnRespond = new Guna.UI2.WinForms.Guna2Button();
            this.pnlStatus = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderColor = System.Drawing.Color.LightGray;
            this.pnlMain.BorderThickness = 1;
            this.pnlMain.BorderRadius = 8;
            this.pnlMain.Controls.Add(this.pnlStatus);
            this.pnlMain.Controls.Add(this.guna2Separator1);
            this.pnlMain.Controls.Add(this.btnRespond);
            this.pnlMain.Controls.Add(this.btnReject);
            this.pnlMain.Controls.Add(this.btnApprove);
            this.pnlMain.Controls.Add(this.lblStatus);
            this.pnlMain.Controls.Add(this.lblDate);
            this.pnlMain.Controls.Add(this.lblNotes);
            this.pnlMain.Controls.Add(this.lblContact);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Size = new System.Drawing.Size(300, 240);
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);

            // pnlStatus
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStatus.Size = new System.Drawing.Size(8, 240);
            this.pnlStatus.FillColor = System.Drawing.Color.RoyalBlue;

            // lblName
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(25, 15);
            this.lblName.Text = "Claimant Name";

            // lblContact
            this.lblContact.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblContact.Location = new System.Drawing.Point(25, 50);
            this.lblContact.Text = "Contact: 123-456-7890";

            // lblNotes
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNotes.Location = new System.Drawing.Point(25, 75);
            this.lblNotes.MaximumSize = new System.Drawing.Size(250, 0); // Allow wrapping
            this.lblNotes.AutoSize = true;
            this.lblNotes.Text = "Notes: Some descriptive notes about the claim go here.";

            // lblStatus
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblStatus.Location = new System.Drawing.Point(25, 125);
            this.lblStatus.Text = "Status: Pending";

            // lblDate
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDate.Location = new System.Drawing.Point(25, 150);
            this.lblDate.Text = "2025-12-01 14:30";

            // guna2Separator1
            this.guna2Separator1.Location = new System.Drawing.Point(20, 175);
            this.guna2Separator1.Size = new System.Drawing.Size(260, 10);

            // btnApprove, btnReject, btnRespond (common properties)
            Action<Guna.UI2.WinForms.Guna2Button> setButtonDefaults = (btn) => {
                btn.BorderRadius = 6;
                btn.Size = new System.Drawing.Size(75, 32);
                btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            };

            // btnApprove
            setButtonDefaults(this.btnApprove);
            this.btnApprove.Text = "Approve";
            this.btnApprove.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnApprove.Location = new System.Drawing.Point(25, 190);

            // btnReject
            setButtonDefaults(this.btnReject);
            this.btnReject.Text = "Reject";
            this.btnReject.FillColor = System.Drawing.Color.Crimson;
            this.btnReject.Location = new System.Drawing.Point(110, 190);

            // btnRespond
            setButtonDefaults(this.btnRespond);
            this.btnRespond.Text = "Respond";
            this.btnRespond.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnRespond.Location = new System.Drawing.Point(195, 190);

            // UserControl
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(300, 240);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}

