using LFsystem.Services;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LFsystem
{
    public partial class EditUserForm : Form
    {
        private int _id;

        public EditUserForm(int id, string name, string username, string email, string role, string status)
        {
            InitializeComponent();
            _id = id;

            // Load existing values
            txtName.Text = name;
            txtUsername.Text = username;
            txtEmail.Text = email;
            cmbRole.SelectedItem = role;
            cmbStatus.SelectedItem = status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();
            string status = cmbStatus.SelectedItem?.ToString();

            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("All fields except password are required.",
                                "Validation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Validate password only if user tries to change it
            bool isChangingPassword = !string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmPassword);

            if (isChangingPassword)
            {
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match.",
                                    "Password Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (newPassword.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters.",
                                    "Password Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
            }

            int isActive = (status == "Active") ? 1 : 0;

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query;

                    if (isChangingPassword)
                    {
                        query = @"UPDATE users 
                          SET Name=@Name,
                              Username=@Username,
                              Email=@Email,
                              Role=@Role,
                              isActive=@Active,
                              Password=@Password
                          WHERE id=@Id";
                    }
                    else
                    {
                        query = @"UPDATE users 
                          SET Name=@Name,
                              Username=@Username,
                              Email=@Email,
                              Role=@Role,
                              isActive=@Active
                          WHERE id=@Id";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Active", isActive);
                        cmd.Parameters.AddWithValue("@Id", _id);

                        if (isChangingPassword)
                        {
                            string hashed = BCrypt.Net.BCrypt.HashPassword(newPassword);
                            cmd.Parameters.AddWithValue("@Password", hashed);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(isChangingPassword ?
                                "User updated successfully (Password changed)!" :
                                "User updated successfully!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
