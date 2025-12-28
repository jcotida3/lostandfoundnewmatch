namespace LFsystem.Views.Main
{
    partial class MainForm
    {
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelSidebar = new Panel();
            flowSideBar = new FlowLayoutPanel();
            btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            btnReport = new Guna.UI2.WinForms.Guna2Button();
            btnManageItems = new Guna.UI2.WinForms.Guna2Button();
            btnManageClaims = new Guna.UI2.WinForms.Guna2Button();
            btnSettings = new Guna.UI2.WinForms.Guna2Button();
            btnUserManagement = new Guna.UI2.WinForms.Guna2Button();
            btnSignOut = new Guna.UI2.WinForms.Guna2Button();
            pictureBox1 = new PictureBox();
            panelHeader = new Panel();
            lblTime = new Label();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblRole = new Label();
            lblHeader = new Label();
            panelContent = new Panel();
            panelSidebar.SuspendLayout();
            flowSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.LightSteelBlue;
            panelSidebar.Controls.Add(flowSideBar);
            panelSidebar.Controls.Add(btnSignOut);
            panelSidebar.Controls.Add(pictureBox1);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(279, 900);
            panelSidebar.TabIndex = 0;
            // 
            // flowSideBar
            // 
            flowSideBar.Controls.Add(btnDashboard);
            flowSideBar.Controls.Add(btnReport);
            flowSideBar.Controls.Add(btnManageItems);
            flowSideBar.Controls.Add(btnManageClaims);
            flowSideBar.Controls.Add(btnSettings);
            flowSideBar.Controls.Add(btnUserManagement);
            flowSideBar.Location = new Point(0, 248);
            flowSideBar.Name = "flowSideBar";
            flowSideBar.Size = new Size(276, 516);
            flowSideBar.TabIndex = 0;
            // 
            // btnDashboard
            // 
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.CustomizableEdges = customizableEdges1;
            btnDashboard.DisabledState.BorderColor = Color.DarkGray;
            btnDashboard.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDashboard.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDashboard.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDashboard.FillColor = Color.Transparent;
            btnDashboard.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.HoverState.FillColor = Color.DodgerBlue;
            btnDashboard.Image = Properties.Resources.home_icon;
            btnDashboard.ImageAlign = HorizontalAlignment.Left;
            btnDashboard.ImageSize = new Size(25, 25);
            btnDashboard.Location = new Point(0, 0);
            btnDashboard.Margin = new Padding(0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.PressedColor = SystemColors.HotTrack;
            btnDashboard.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnDashboard.Size = new Size(279, 60);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnReport
            // 
            btnReport.Cursor = Cursors.Hand;
            btnReport.CustomizableEdges = customizableEdges3;
            btnReport.DisabledState.BorderColor = Color.DarkGray;
            btnReport.DisabledState.CustomBorderColor = Color.DarkGray;
            btnReport.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnReport.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnReport.FillColor = Color.Transparent;
            btnReport.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReport.ForeColor = Color.White;
            btnReport.HoverState.FillColor = Color.DodgerBlue;
            btnReport.Image = (Image)resources.GetObject("btnReport.Image");
            btnReport.ImageAlign = HorizontalAlignment.Left;
            btnReport.ImageSize = new Size(25, 25);
            btnReport.Location = new Point(0, 60);
            btnReport.Margin = new Padding(0);
            btnReport.Name = "btnReport";
            btnReport.PressedColor = SystemColors.HotTrack;
            btnReport.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnReport.Size = new Size(279, 60);
            btnReport.TabIndex = 1;
            btnReport.Text = "Report Item";
            btnReport.TextOffset = new Point(7, 0);
            btnReport.Click += btnReport_Click;
            // 
            // btnManageItems
            // 
            btnManageItems.Cursor = Cursors.Hand;
            btnManageItems.CustomizableEdges = customizableEdges5;
            btnManageItems.DisabledState.BorderColor = Color.DarkGray;
            btnManageItems.DisabledState.CustomBorderColor = Color.DarkGray;
            btnManageItems.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnManageItems.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnManageItems.FillColor = Color.Transparent;
            btnManageItems.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageItems.ForeColor = Color.White;
            btnManageItems.HoverState.FillColor = Color.DodgerBlue;
            btnManageItems.Image = (Image)resources.GetObject("btnManageItems.Image");
            btnManageItems.ImageAlign = HorizontalAlignment.Left;
            btnManageItems.ImageSize = new Size(25, 25);
            btnManageItems.Location = new Point(0, 120);
            btnManageItems.Margin = new Padding(0);
            btnManageItems.Name = "btnManageItems";
            btnManageItems.PressedColor = SystemColors.HotTrack;
            btnManageItems.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnManageItems.Size = new Size(279, 60);
            btnManageItems.TabIndex = 2;
            btnManageItems.Text = "All Items";
            btnManageItems.Click += btnManageItems_Click;
            // 
            // btnManageClaims
            // 
            btnManageClaims.Cursor = Cursors.Hand;
            btnManageClaims.CustomizableEdges = customizableEdges7;
            btnManageClaims.DisabledState.BorderColor = Color.DarkGray;
            btnManageClaims.DisabledState.CustomBorderColor = Color.DarkGray;
            btnManageClaims.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnManageClaims.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnManageClaims.FillColor = Color.Transparent;
            btnManageClaims.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageClaims.ForeColor = Color.White;
            btnManageClaims.HoverState.FillColor = Color.DodgerBlue;
            btnManageClaims.Image = Properties.Resources.claims_icon;
            btnManageClaims.ImageAlign = HorizontalAlignment.Left;
            btnManageClaims.ImageSize = new Size(30, 30);
            btnManageClaims.Location = new Point(0, 180);
            btnManageClaims.Margin = new Padding(0);
            btnManageClaims.Name = "btnManageClaims";
            btnManageClaims.PressedColor = SystemColors.HotTrack;
            btnManageClaims.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnManageClaims.Size = new Size(279, 60);
            btnManageClaims.TabIndex = 8;
            btnManageClaims.Text = "Manage Claims";
            btnManageClaims.Click += btnManageClaims_Click;
            // 
            // btnSettings
            // 
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.CustomizableEdges = customizableEdges9;
            btnSettings.DisabledState.BorderColor = Color.DarkGray;
            btnSettings.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSettings.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSettings.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSettings.FillColor = Color.Transparent;
            btnSettings.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSettings.ForeColor = Color.White;
            btnSettings.HoverState.FillColor = Color.DodgerBlue;
            btnSettings.Image = (Image)resources.GetObject("btnSettings.Image");
            btnSettings.ImageAlign = HorizontalAlignment.Left;
            btnSettings.ImageSize = new Size(25, 25);
            btnSettings.Location = new Point(0, 240);
            btnSettings.Margin = new Padding(0);
            btnSettings.Name = "btnSettings";
            btnSettings.PressedColor = SystemColors.HotTrack;
            btnSettings.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSettings.Size = new Size(279, 60);
            btnSettings.TabIndex = 3;
            btnSettings.Text = "Settings";
            btnSettings.Click += btnSettings_Click;
            // 
            // btnUserManagement
            // 
            btnUserManagement.Cursor = Cursors.Hand;
            btnUserManagement.CustomizableEdges = customizableEdges11;
            btnUserManagement.DisabledState.BorderColor = Color.DarkGray;
            btnUserManagement.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUserManagement.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUserManagement.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUserManagement.FillColor = Color.Transparent;
            btnUserManagement.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUserManagement.ForeColor = Color.White;
            btnUserManagement.HoverState.FillColor = Color.DodgerBlue;
            btnUserManagement.Image = (Image)resources.GetObject("btnUserManagement.Image");
            btnUserManagement.ImageAlign = HorizontalAlignment.Left;
            btnUserManagement.ImageSize = new Size(25, 25);
            btnUserManagement.Location = new Point(0, 300);
            btnUserManagement.Margin = new Padding(0);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.PressedColor = SystemColors.HotTrack;
            btnUserManagement.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnUserManagement.Size = new Size(279, 60);
            btnUserManagement.TabIndex = 7;
            btnUserManagement.Text = "User Management";
            btnUserManagement.TextOffset = new Point(15, 0);
            btnUserManagement.Click += btnUserManagement_Click;
            // 
            // btnSignOut
            // 
            btnSignOut.Cursor = Cursors.Hand;
            btnSignOut.CustomizableEdges = customizableEdges13;
            btnSignOut.DisabledState.BorderColor = Color.DarkGray;
            btnSignOut.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSignOut.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSignOut.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSignOut.Dock = DockStyle.Bottom;
            btnSignOut.FillColor = Color.Red;
            btnSignOut.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignOut.ForeColor = Color.White;
            btnSignOut.HoverState.FillColor = Color.FromArgb(192, 0, 0);
            btnSignOut.Image = (Image)resources.GetObject("btnSignOut.Image");
            btnSignOut.ImageAlign = HorizontalAlignment.Left;
            btnSignOut.ImageSize = new Size(25, 25);
            btnSignOut.Location = new Point(0, 840);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnSignOut.Size = new Size(279, 60);
            btnSignOut.TabIndex = 6;
            btnSignOut.Text = "Sign Out";
            btnSignOut.TextOffset = new Point(10, 0);
            btnSignOut.Click += btnSignOut_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(28, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(217, 176);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.HotTrack;
            panelHeader.Controls.Add(lblTime);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(lblRole);
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(279, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(983, 60);
            panelHeader.TabIndex = 1;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.White;
            lblTime.Location = new Point(780, 19);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(0, 27);
            lblTime.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges15;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.Dock = DockStyle.Right;
            btnClose.FillColor = Color.FromArgb(192, 192, 255);
            btnClose.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(926, 0);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnClose.Size = new Size(57, 60);
            btnClose.TabIndex = 2;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.ForeColor = Color.White;
            lblRole.Location = new Point(594, 19);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(57, 27);
            lblRole.TabIndex = 1;
            lblRole.Text = "Role";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(43, 19);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(491, 27);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Lost and Found Inventory Management System";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(279, 60);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(983, 840);
            panelContent.TabIndex = 2;
            // 
            // MainForm
            // 
            ClientSize = new Size(1262, 900);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Controls.Add(panelSidebar);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            panelSidebar.ResumeLayout(false);
            flowSideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }
        private Panel panelSidebar;
        private Panel panelHeader;
        private Panel panelContent;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2Button btnSettings;
        private Guna.UI2.WinForms.Guna2Button btnManageItems;
        private Guna.UI2.WinForms.Guna2Button btnReport;
        
        private Guna.UI2.WinForms.Guna2Button btnSignOut;
        private Guna.UI2.WinForms.Guna2Button btnUserManagement;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Label lblRole;
        private Label lblHeader;
        private FlowLayoutPanel flowSideBar;
        private Guna.UI2.WinForms.Guna2Button btnManageClaims;
        private Label lblTime;
    }
}
