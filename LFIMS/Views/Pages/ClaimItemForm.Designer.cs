namespace LFsystem.Views.Pages
{
    partial class ClaimItemForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblItemName;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2TextBox txtContact;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Guna.UI2.WinForms.Guna2Button btnSubmit;
        private Guna.UI2.WinForms.Guna2Button btnCancel;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblItemName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtContact = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSubmit = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();

            // panelMain
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Padding = new System.Windows.Forms.Padding(18);
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.lblItemName);
            this.panelMain.Controls.Add(this.txtName);
            this.panelMain.Controls.Add(this.txtContact);
            this.panelMain.Controls.Add(this.txtNotes);
            this.panelMain.Controls.Add(this.btnSubmit);
            this.panelMain.Controls.Add(this.btnCancel);

            // lblTitle
            this.lblTitle.Text = "Claim This Item";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.AutoSize = true;

            // lblItemName
            this.lblItemName.Text = "Claiming: (item)";
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblItemName.Location = new System.Drawing.Point(22, 52);
            this.lblItemName.AutoSize = true;

            // txtName
            this.txtName.PlaceholderText = "Your full name";
            this.txtName.Location = new System.Drawing.Point(22, 86);
            this.txtName.Size = new System.Drawing.Size(420, 36);
            this.txtName.BorderRadius = 6;

            // txtContact
            this.txtContact.PlaceholderText = "Contact number or email";
            this.txtContact.Location = new System.Drawing.Point(22, 132);
            this.txtContact.Size = new System.Drawing.Size(420, 36);
            this.txtContact.BorderRadius = 6;

            // txtNotes
            this.txtNotes.PlaceholderText = "Notes: explain why this item is yours (optional)";
            this.txtNotes.Location = new System.Drawing.Point(22, 178);
            this.txtNotes.Size = new System.Drawing.Size(420, 140);
            this.txtNotes.BorderRadius = 6;
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // btnSubmit
            this.btnSubmit.Text = "Submit Claim";
            this.btnSubmit.Location = new System.Drawing.Point(262, 332);
            this.btnSubmit.Size = new System.Drawing.Size(100, 36);
            this.btnSubmit.BorderRadius = 6;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // btnCancel
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(368, 332);
            this.btnCancel.Size = new System.Drawing.Size(74, 36);
            this.btnCancel.BorderRadius = 6;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ClaimItemForm
            this.ClientSize = new System.Drawing.Size(470, 390);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Claim Item";
        }
        #endregion
    }
}
