using Guna.UI2.WinForms;
using LFsystem.Helpers;
using LFsystem.Views.Login;
using LFsystem.Views.Pages;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace LFsystem.Views.Main
{
    public partial class MainForm : Form
    {
        private string userRole;
        private Guna2Button? activeButton = null;
        private System.Windows.Forms.Timer timerClock; // Use fully qualified name

        public MainForm(string role)
        {
            InitializeComponent();
            userRole = role;
            ApplyRolePermissions(); // Handle button visibility

            // Load default page
            LoadPage(new Dashboard());
            SetActiveButton(btnDashboard);
            lblRole.Text = userRole;
        }
        private void ApplyRolePermissions()
        {
            btnUserManagement.Visible = false; // Only Super Admin
            btnManageClaims.Visible = false;   // Only Admin/Super Admin

            if (userRole == "Super Admin")
            {
                btnUserManagement.Visible = true;
                btnManageClaims.Visible = false;
                btnReport.Visible = false;
            }
            else if (userRole == "Admin")
            {
                btnManageClaims.Visible = true;
                btnReport.Visible = false;
            }
        }

        public void LoadPage(UserControl page)
        {
            panelContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Add(page);
        }

        public void SetActiveButton(Guna2Button clickedButton)
        {
            if (activeButton != null)
            {
                activeButton.FillColor = Color.FromArgb(176, 196, 222); // default sidebar
                activeButton.ForeColor = Color.White;
            }

            activeButton = clickedButton;
            activeButton.FillColor = Color.FromArgb(30, 144, 255); // highlight
            activeButton.ForeColor = Color.White;
        }

        public void ActivateSidebarButton(string name)
        {
            switch (name)
            {
                case "Dashboard":
                    SetActiveButton(btnDashboard);
                    break;
                case "Report":
                    SetActiveButton(btnReport);
                    break;
                case "ManageItems":
                    SetActiveButton(btnManageItems);
                    break;
                case "ManageClaims":
                    SetActiveButton(btnManageClaims);
                    break;
                case "Settings":
                    SetActiveButton(btnSettings);
                    break;
                case "UserManagement":
                    SetActiveButton(btnUserManagement);
                    break;
            }
        }

        // Button events
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDashboard);
            LoadPage(new Dashboard());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnReport);
            LoadPage(new Report());
        }

        private void btnManageItems_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnManageItems);
            LoadPage(new ManageItems());
        }

        private void btnManageClaims_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnManageClaims);
            LoadPage(new ManageClaims());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnSettings);
            LoadPage(new Settings());
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnUserManagement);
            LoadPage(new UserManagement());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
