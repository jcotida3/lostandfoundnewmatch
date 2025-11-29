namespace LFsystem.Views.Pages
{
    partial class Settings
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblSettings = new Label();
            panelSettingInfo = new Guna.UI2.WinForms.Guna2Panel();
            btnSave = new Button();
            btnCancel = new Button();
            btnEdit = new PictureBox();
            txtRole = new Label();
            txtEmail = new Label();
            txtName = new Label();
            lblProfileRole = new Label();
            lblEmailRole = new Label();
            lblProfileName = new Label();
            label1 = new Label();
            lblProfileInformation = new Label();
            txtEmailEdit = new TextBox();
            txtNameEdit = new TextBox();
            roleValue = new Label();
            lblRole = new Label();
            panelSettingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnEdit).BeginInit();
            SuspendLayout();
            // 
            // lblSettings
            // 
            lblSettings.AutoSize = true;
            lblSettings.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblSettings.ForeColor = SystemColors.HotTrack;
            lblSettings.Location = new Point(46, 29);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(134, 41);
            lblSettings.TabIndex = 0;
            lblSettings.Text = "Settings";
            // 
            // panelSettingInfo
            // 
            panelSettingInfo.BorderColor = Color.DimGray;
            panelSettingInfo.BorderRadius = 20;
            panelSettingInfo.BorderThickness = 1;
            panelSettingInfo.Controls.Add(btnSave);
            panelSettingInfo.Controls.Add(btnCancel);
            panelSettingInfo.Controls.Add(btnEdit);
            panelSettingInfo.Controls.Add(txtRole);
            panelSettingInfo.Controls.Add(txtEmail);
            panelSettingInfo.Controls.Add(txtName);
            panelSettingInfo.Controls.Add(lblProfileRole);
            panelSettingInfo.Controls.Add(lblEmailRole);
            panelSettingInfo.Controls.Add(lblProfileName);
            panelSettingInfo.Controls.Add(label1);
            panelSettingInfo.Controls.Add(lblProfileInformation);
            panelSettingInfo.Controls.Add(txtEmailEdit);
            panelSettingInfo.Controls.Add(txtNameEdit);
            panelSettingInfo.CustomizableEdges = customizableEdges1;
            panelSettingInfo.Location = new Point(46, 124);
            panelSettingInfo.Name = "panelSettingInfo";
            panelSettingInfo.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelSettingInfo.Size = new Size(528, 220);
            panelSettingInfo.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(492, 11);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5, 0, 5, 0);
            btnSave.Size = new Size(30, 35);
            btnSave.TabIndex = 9;
            btnSave.Text = "💾";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(452, 11);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(30, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "❌";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Image = Properties.Resources.edit;
            btnEdit.Location = new Point(492, 11);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(30, 35);
            btnEdit.SizeMode = PictureBoxSizeMode.Zoom;
            btnEdit.TabIndex = 8;
            btnEdit.TabStop = false;
            // 
            // txtRole
            // 
            txtRole.AutoSize = true;
            txtRole.Font = new Font("Microsoft YaHei UI", 9F);
            txtRole.ForeColor = Color.Gray;
            txtRole.Location = new Point(123, 165);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(157, 20);
            txtRole.TabIndex = 7;
            txtRole.Text = "Your account details";
            // 
            // txtEmail
            // 
            txtEmail.AutoSize = true;
            txtEmail.Font = new Font("Microsoft YaHei UI", 9F);
            txtEmail.ForeColor = Color.Gray;
            txtEmail.Location = new Point(123, 125);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(157, 20);
            txtEmail.TabIndex = 6;
            txtEmail.Text = "Your account details";
            // 
            // txtName
            // 
            txtName.AutoSize = true;
            txtName.Font = new Font("Microsoft YaHei UI", 9F);
            txtName.ForeColor = Color.Gray;
            txtName.Location = new Point(123, 75);
            txtName.Name = "txtName";
            txtName.Size = new Size(157, 20);
            txtName.TabIndex = 5;
            txtName.Text = "Your account details";
            // 
            // lblProfileRole
            // 
            lblProfileRole.AutoSize = true;
            lblProfileRole.Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Bold);
            lblProfileRole.Location = new Point(42, 163);
            lblProfileRole.Name = "lblProfileRole";
            lblProfileRole.Size = new Size(48, 24);
            lblProfileRole.TabIndex = 4;
            lblProfileRole.Text = "Role";
            // 
            // lblEmailRole
            // 
            lblEmailRole.AutoSize = true;
            lblEmailRole.Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Bold);
            lblEmailRole.Location = new Point(42, 118);
            lblEmailRole.Name = "lblEmailRole";
            lblEmailRole.Size = new Size(57, 24);
            lblEmailRole.TabIndex = 3;
            lblEmailRole.Text = "Email";
            // 
            // lblProfileName
            // 
            lblProfileName.AutoSize = true;
            lblProfileName.Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Bold);
            lblProfileName.Location = new Point(42, 75);
            lblProfileName.Name = "lblProfileName";
            lblProfileName.Size = new Size(61, 24);
            lblProfileName.TabIndex = 2;
            lblProfileName.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 7.8F);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(197, 35);
            label1.Name = "label1";
            label1.Size = new Size(135, 19);
            label1.TabIndex = 1;
            label1.Text = "Your account details";
            // 
            // lblProfileInformation
            // 
            lblProfileInformation.AutoSize = true;
            lblProfileInformation.Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Bold);
            lblProfileInformation.Location = new Point(177, 11);
            lblProfileInformation.Name = "lblProfileInformation";
            lblProfileInformation.Size = new Size(174, 24);
            lblProfileInformation.TabIndex = 0;
            lblProfileInformation.Text = "Profile Information";
            // 
            // txtEmailEdit
            // 
            txtEmailEdit.Location = new Point(123, 122);
            txtEmailEdit.Name = "txtEmailEdit";
            txtEmailEdit.Size = new Size(200, 27);
            txtEmailEdit.TabIndex = 1;
            txtEmailEdit.Visible = false;
            // 
            // txtNameEdit
            // 
            txtNameEdit.Location = new Point(123, 72);
            txtNameEdit.Name = "txtNameEdit";
            txtNameEdit.Size = new Size(200, 27);
            txtNameEdit.TabIndex = 0;
            txtNameEdit.Visible = false;
            // 
            // roleValue
            // 
            roleValue.AutoSize = true;
            roleValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            roleValue.Location = new Point(107, 80);
            roleValue.Name = "roleValue";
            roleValue.Size = new Size(53, 25);
            roleValue.TabIndex = 11;
            roleValue.Text = "Staff";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblRole.ForeColor = Color.Gray;
            lblRole.Location = new Point(46, 80);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(55, 25);
            lblRole.TabIndex = 12;
            lblRole.Text = "Role:";
            // 
            // Settings
            // 
            BackColor = Color.White;
            Controls.Add(roleValue);
            Controls.Add(lblRole);
            Controls.Add(panelSettingInfo);
            Controls.Add(lblSettings);
            Name = "Settings";
            Size = new Size(1084, 790);
            panelSettingInfo.ResumeLayout(false);
            panelSettingInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnEdit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSettings;
        private Guna.UI2.WinForms.Guna2Panel panelSettingInfo;
        private System.Windows.Forms.Label lblProfileInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.Label lblEmailRole;
        private System.Windows.Forms.Label lblProfileRole;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtEmail;
        private System.Windows.Forms.Label txtRole;
        private System.Windows.Forms.TextBox txtNameEdit;
        private System.Windows.Forms.TextBox txtEmailEdit;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label roleValue;
        private System.Windows.Forms.Label lblRole;
    }
}
