using Guna.UI2.WinForms;
using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LFsystem.Helpers;

namespace LFsystem.Views.Pages
{
    public partial class CreateUserForm : Form
    {


        public CreateUserForm()
        {
            InitializeComponent();
            btnCreate.Click += BtnCreate_Click;
            btnCancel.Click += BtnCancel_Click;
            cmbRole.Items.AddRange(new object[] { "Staff", "Admin", "Super Admin" });
            cmbRole.SelectedIndex = 0;
        }
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(textUsername.Text) ||
                string.IsNullOrWhiteSpace(textFullName.Text) ||
                string.IsNullOrWhiteSpace(textEmail.Text) ||
                string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Please fill all fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = textUsername.Text.Trim();
            string fullname = textFullName.Text.Trim();
            string email = textEmail.Text.Trim();
            string password = PasswordHelper.HashPassword(textPassword.Text);
            string role = cmbRole.SelectedItem?.ToString();

            // Insert into database
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string query = @"INSERT INTO users (username, name, email, password, role, isActive, created_at)
                         VALUES (@username, @name, @email, @password, @role, 1, @created_at)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@name", fullname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password); // hash recommended
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"User '{username}' created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Signal to the calling form that a user was created
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error creating user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
#region roles for dynamic
/*private void LoadRoles()
{
    try
    {
        using (MySqlConnection conn = Database.GetConnection())
        {
            conn.Open();
            string query = "SELECT RoleName FROM roles ORDER BY RoleName ASC";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            cmbRole.Items.Clear();
            while (reader.Read())
            {
                cmbRole.Items.Add(reader["RoleName"].ToString());
            }
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error loading roles: " + ex.Message);
    }
}*/

#endregion


