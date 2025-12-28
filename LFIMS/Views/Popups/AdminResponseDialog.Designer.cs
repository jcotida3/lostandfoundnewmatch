using Guna.UI2.WinForms;

namespace LFsystem.Views.Pages
{
    partial class AdminRespondDialog
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2HtmlLabel lblLabel;
        private Guna2TextBox txtRespondNotes;
        private Guna2ComboBox cmbStatus;
        private Guna2Button btnOk;
        private Guna2Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblLabel = new Guna2HtmlLabel();
            this.txtRespondNotes = new Guna2TextBox();
            this.cmbStatus = new Guna2ComboBox();
            this.btnOk = new Guna2Button();
            this.btnCancel = new Guna2Button();

            this.SuspendLayout();

            // lblLabel
            this.lblLabel.Text = "Add response notes and set status (optional):";
            this.lblLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLabel.Location = new System.Drawing.Point(16, 12);
            this.lblLabel.AutoSize = true;

            // txtRespondNotes
            this.txtRespondNotes.Location = new System.Drawing.Point(16, 40);
            this.txtRespondNotes.Size = new System.Drawing.Size(420, 120);
            this.txtRespondNotes.Multiline = true;
            this.txtRespondNotes.BorderRadius = 6;
            this.txtRespondNotes.PlaceholderText = "Type admin response notes here...";

            // cmbStatus
            this.cmbStatus.Location = new System.Drawing.Point(16, 170);
            this.cmbStatus.Size = new System.Drawing.Size(200, 36);
            this.cmbStatus.BorderRadius = 6;
            this.cmbStatus.Items.AddRange(new object[] { "Pending", "Approved", "Rejected" });
            this.cmbStatus.SelectedIndex = 0;

            // btnOk
            this.btnOk.Text = "OK";
            this.btnOk.Location = new System.Drawing.Point(260, 174);
            this.btnOk.Size = new System.Drawing.Size(80, 34);
            this.btnOk.BorderRadius = 6;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);

            // btnCancel
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(352, 174);
            this.btnCancel.Size = new System.Drawing.Size(80, 34);
            this.btnCancel.BorderRadius = 6;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AdminRespondDialog Form
            this.ClientSize = new System.Drawing.Size(460, 230);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.txtRespondNotes);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Text = "Admin Response";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
