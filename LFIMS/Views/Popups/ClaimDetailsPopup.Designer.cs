using System.Drawing;
using System.Windows.Forms;

namespace LFsystem.Views.Popups
{
    partial class ClaimDetailPopupForm
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
            txtTitle = new Label();
            lblCategory = new Label();
            txtCategory = new Label();
            lblLocation = new Label();
            txtLocation = new Label();
            lblDescription = new Label();
            txtDescription = new Label();
            picItem = new PictureBox();
            lblClaimant = new Label();
            txtClaimant = new Label();
            lblContact = new Label();
            txtContact = new Label();
            lblNotes = new Label();
            txtNotes = new Label();
            lblDate = new Label();
            txtDate = new Label();
            lblStatus = new Label();
            txtStatus = new Label();
            btnApprove = new Button();
            btnReject = new Button();
            lblItemID = new Label();
            txtItemID = new Label();
            ((System.ComponentModel.ISupportInitialize)picItem).BeginInit();
            SuspendLayout();
            // 
            // lblItemTitle
            // 
            lblItemTitle.AutoSize = true;
            lblItemTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblItemTitle.ForeColor = Color.Black;
            lblItemTitle.Location = new Point(20, 20);
            lblItemTitle.Name = "lblItemTitle";
            lblItemTitle.Size = new Size(44, 20);
            lblItemTitle.TabIndex = 0;
            lblItemTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.Transparent;
            txtTitle.Location = new Point(100, 17);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(250, 27);
            txtTitle.TabIndex = 1;
            txtTitle.Text = "Item Title Content";
            txtTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategory.Location = new Point(20, 100);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(77, 20);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Category:";
            // 
            // txtCategory
            // 
            txtCategory.BackColor = Color.Transparent;
            txtCategory.Location = new Point(100, 97);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(250, 27);
            txtCategory.TabIndex = 5;
            txtCategory.Text = "Category Content";
            txtCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocation.Location = new Point(20, 140);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(73, 20);
            lblLocation.TabIndex = 6;
            lblLocation.Text = "Location:";
            // 
            // txtLocation
            // 
            txtLocation.BackColor = Color.Transparent;
            txtLocation.Location = new Point(100, 137);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(250, 27);
            txtLocation.TabIndex = 7;
            txtLocation.Text = "Location Content";
            txtLocation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescription.Location = new Point(20, 175);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(93, 20);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.White;
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Location = new Point(20, 200);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(330, 80);
            txtDescription.TabIndex = 9;
            txtDescription.Text = "Item Description Content. This is a multi-line field.";
            // 
            // picItem
            // 
            picItem.BorderStyle = BorderStyle.FixedSingle;
            picItem.Location = new Point(441, 16);
            picItem.Name = "picItem";
            picItem.Size = new Size(250, 225);
            picItem.SizeMode = PictureBoxSizeMode.Zoom;
            picItem.TabIndex = 10;
            picItem.TabStop = false;
            // 
            // lblClaimant
            // 
            lblClaimant.AutoSize = true;
            lblClaimant.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClaimant.Location = new Point(20, 295);
            lblClaimant.Name = "lblClaimant";
            lblClaimant.Size = new Size(75, 20);
            lblClaimant.TabIndex = 11;
            lblClaimant.Text = "Claimant:";
            // 
            // txtClaimant
            // 
            txtClaimant.BackColor = Color.White;
            txtClaimant.Location = new Point(100, 292);
            txtClaimant.Name = "txtClaimant";
            txtClaimant.Size = new Size(250, 27);
            txtClaimant.TabIndex = 12;
            txtClaimant.Text = "Claimant Name Content";
            txtClaimant.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContact.Location = new Point(20, 335);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(67, 20);
            lblContact.TabIndex = 13;
            lblContact.Text = "Contact:";
            // 
            // txtContact
            // 
            txtContact.BackColor = Color.White;
            txtContact.Location = new Point(100, 332);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(250, 27);
            txtContact.TabIndex = 14;
            txtContact.Text = "Contact Info Content";
            txtContact.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNotes.Location = new Point(20, 375);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(55, 20);
            lblNotes.TabIndex = 15;
            lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            txtNotes.BackColor = Color.White;
            txtNotes.BorderStyle = BorderStyle.FixedSingle;
            txtNotes.Location = new Point(20, 400);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(330, 60);
            txtNotes.TabIndex = 16;
            txtNotes.Text = "Claim notes content. This is a multi-line field.";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDate.Location = new Point(457, 295);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(46, 20);
            lblDate.TabIndex = 17;
            lblDate.Text = "Date:";
            // 
            // txtDate
            // 
            txtDate.BackColor = Color.White;
            txtDate.Location = new Point(517, 292);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(190, 27);
            txtDate.TabIndex = 18;
            txtDate.Text = "Date Content";
            txtDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(457, 335);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(57, 20);
            lblStatus.TabIndex = 19;
            lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            txtStatus.BackColor = Color.White;
            txtStatus.Location = new Point(517, 332);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(190, 27);
            txtStatus.TabIndex = 20;
            txtStatus.Text = "Status Content";
            txtStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(441, 391);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(120, 40);
            btnApprove.TabIndex = 21;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += BtnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(571, 391);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(120, 40);
            btnReject.TabIndex = 22;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += BtnReject_Click;
            // 
            // lblItemID
            // 
            lblItemID.AutoSize = true;
            lblItemID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblItemID.ForeColor = Color.Black;
            lblItemID.Location = new Point(20, 60);
            lblItemID.Name = "lblItemID";
            lblItemID.Size = new Size(66, 20);
            lblItemID.TabIndex = 2;
            lblItemID.Text = "Item ID:";
            // 
            // txtItemID
            // 
            txtItemID.BackColor = Color.Transparent;
            txtItemID.Location = new Point(100, 57);
            txtItemID.Name = "txtItemID";
            txtItemID.Size = new Size(100, 27);
            txtItemID.TabIndex = 3;
            txtItemID.Text = "ID Content";
            txtItemID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ClaimDetailPopupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(735, 628);
            Controls.Add(txtItemID);
            Controls.Add(lblItemID);
            Controls.Add(btnReject);
            Controls.Add(btnApprove);
            Controls.Add(txtStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtDate);
            Controls.Add(lblDate);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(txtContact);
            Controls.Add(lblContact);
            Controls.Add(txtClaimant);
            Controls.Add(lblClaimant);
            Controls.Add(picItem);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtLocation);
            Controls.Add(lblLocation);
            Controls.Add(txtCategory);
            Controls.Add(lblCategory);
            Controls.Add(txtTitle);
            Controls.Add(lblItemTitle);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ClaimDetailPopupForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Claim Details";
            ((System.ComponentModel.ISupportInitialize)picItem).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        // Declarations for the controls, updated to Label where appropriate
        private System.Windows.Forms.Label lblItemTitle;
        private System.Windows.Forms.Label txtTitle; // Now a Label
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label txtCategory; // Now a Label
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label txtLocation; // Now a Label
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label txtDescription; // Now a Label
        private System.Windows.Forms.PictureBox picItem;
        private System.Windows.Forms.Label lblClaimant;
        private System.Windows.Forms.Label txtClaimant; // Now a Label
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label txtContact; // Now a Label
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label txtNotes; // Now a Label
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label txtDate; // Now a Label
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label txtStatus; // Now a Label
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label txtItemID; // Now a Label
    }
}