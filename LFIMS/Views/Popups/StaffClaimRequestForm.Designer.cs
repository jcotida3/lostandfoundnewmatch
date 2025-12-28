namespace LFsystem.Views.Popups
{
    partial class StaffClaimRequestForm
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
            lblItemTitle = new Label();
            label1 = new Label();
            txtClaimantName = new TextBox();
            label2 = new Label();
            txtClaimantContact = new TextBox();
            label3 = new Label();
            txtClaimNotes = new TextBox();
            btnSubmit = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblItemTitle
            // 
            lblItemTitle.AutoSize = true;
            lblItemTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItemTitle.Location = new Point(12, 9);
            lblItemTitle.Name = "lblItemTitle";
            lblItemTitle.Size = new Size(250, 28);
            lblItemTitle.TabIndex = 0;
            lblItemTitle.Text = "Claim Request for: [Item]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 50);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 1;
            label1.Text = "Claimant's Name:";
            // 
            // txtClaimantName
            // 
            txtClaimantName.Location = new Point(16, 68);
            txtClaimantName.Name = "txtClaimantName";
            txtClaimantName.Size = new Size(350, 27);
            txtClaimantName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 104);
            label2.Name = "label2";
            label2.Size = new Size(135, 20);
            label2.TabIndex = 3;
            label2.Text = "Claimant's Contact:";
            // 
            // txtClaimantContact
            // 
            txtClaimantContact.Location = new Point(16, 122);
            txtClaimantContact.Name = "txtClaimantContact";
            txtClaimantContact.Size = new Size(350, 27);
            txtClaimantContact.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 158);
            label3.Name = "label3";
            label3.Size = new Size(141, 20);
            label3.TabIndex = 5;
            label3.Text = "Notes / Description:";
            // 
            // txtClaimNotes
            // 
            txtClaimNotes.Location = new Point(12, 202);
            txtClaimNotes.Multiline = true;
            txtClaimNotes.Name = "txtClaimNotes";
            txtClaimNotes.Size = new Size(350, 80);
            txtClaimNotes.TabIndex = 6;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.CornflowerBlue;
            btnSubmit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(266, 311);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(100, 30);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "Submit Claim";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(151, 311);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // StaffClaimRequestForm
            // 
            AcceptButton = btnSubmit;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(384, 402);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(txtClaimNotes);
            Controls.Add(label3);
            Controls.Add(txtClaimantContact);
            Controls.Add(label2);
            Controls.Add(txtClaimantName);
            Controls.Add(label1);
            Controls.Add(lblItemTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StaffClaimRequestForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Submit Item Claim Request";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        // IMPORTANT: These names are used in the code-behind file.
        private System.Windows.Forms.Label lblItemTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClaimantName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaimantContact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClaimNotes;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}