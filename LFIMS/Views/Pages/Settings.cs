using LFsystem.Helpers;
using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            LoadUserProfile();

            // Subscribe event handlers
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void LoadUserProfile()
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT Name, Email, Role FROM users WHERE Id=@id LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", Session.UserId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtName.Text = reader["Name"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtRole.Text = reader["Role"].ToString();
                        roleValue.Text = reader["Role"].ToString();

                        // Preload edit boxes
                        txtNameEdit.Text = txtName.Text;
                        txtEmailEdit.Text = txtEmail.Text;
                    }
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Show edit fields
            txtName.Visible = false;
            txtEmail.Visible = false;

            txtNameEdit.Visible = true;
            txtEmailEdit.Visible = true;

            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Reset edit boxes to original values
            txtNameEdit.Text = txtName.Text;
            txtEmailEdit.Text = txtEmail.Text;

            // Hide edit fields
            txtNameEdit.Visible = false;
            txtEmailEdit.Visible = false;

            txtName.Visible = true;
            txtEmail.Visible = true;

            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "UPDATE users SET Name=@name, Email=@email WHERE Id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtNameEdit.Text);
                cmd.Parameters.AddWithValue("@email", txtEmailEdit.Text);
                cmd.Parameters.AddWithValue("@id", Session.UserId);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Profile updated successfully!");

                    // Update labels
                    txtName.Text = txtNameEdit.Text;
                    txtEmail.Text = txtEmailEdit.Text;

                    // Return to view mode
                    BtnCancel_Click(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("No changes were made.");
                }
            }
        }
    }
}
