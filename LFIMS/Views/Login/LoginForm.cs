using Guna.UI2.WinForms;
using LFsystem.Helpers;
using LFsystem.Models;
using LFsystem.Services;
using System;
using System.Windows.Forms;

namespace LFsystem.Views.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = guna2Button1; // Press Enter = login
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var userService = new UserService();
                User user = userService.GetUserByUsername(username);

                if (user == null)
                {
                    MessageBox.Show("User not found or inactive account.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(!PasswordHelper.VerifyPassword(password, user.PasswordHash))
                {
                    MessageBox.Show("Incorrect Password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!user.IsActive)
                {
                    MessageBox.Show("Your account is deactivated. Please contact administrator.", "Access Denied", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Save to Session
                LFsystem.Helpers.Session.UserId = user.ID;
                LFsystem.Helpers.Session.Username = user.Username;
                LFsystem.Helpers.Session.Role = user.Role;
                LFsystem.Helpers.Session.Name = user.FullName;

                MessageBox.Show($"Welcome {user.FullName}! ({user.Role})", "Login Successful!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);


                Views.Main.MainForm mainForm = new Views.Main.MainForm(user.Role);
                this.Hide();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
