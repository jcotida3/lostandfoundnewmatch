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

        public MainForm(string role)
        {
            InitializeComponent();
            userRole = role;

            if (userRole != "Super Admin")
            {

                btnUserManagement.Visible = false;

            }
            // Load the default page (Dashboard)
            LoadPage(new Dashboard());
            SetActiveButton(btnDashboard);
            lblRole.Text = userRole;
        }

        // Load UserControl into panelContent
        public void LoadPage(UserControl page)
        {
            panelContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Add(page);
        }

        
        // Handle active button color
        public void SetActiveButton(Guna2Button clickedButton)
        {
            if (activeButton != null)
            {
                activeButton.FillColor = Color.FromArgb(176, 196, 222); // default sidebar color
                activeButton.ForeColor = Color.White;
            }

            activeButton = clickedButton;
            activeButton.FillColor = Color.FromArgb(30, 144, 255); // highlight color
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
                case "Settings":
                    SetActiveButton(btnSettings);
                    break;
                case "UserManagement":
                    SetActiveButton(btnUserManagement);
                    break;
                default:
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
