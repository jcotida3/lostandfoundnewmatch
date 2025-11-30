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

namespace LFsystem.Views.Pages
{
    public partial class UserManagement : UserControl
    {
        public UserManagement()
        {
            InitializeComponent();
            LoadUsers();
            tblDataGridView.CellClick += tblDataGridView_CellClick;

        }

        private void LoadUsers()
        {
            try
            {
                string queryUsers = "SELECT id, name, username, email, role, isActive FROM users";
                string queryCounts = @"
            SELECT 
                COUNT(*) AS TotalUsers,
                SUM(role='Staff') AS TotalStaff,
                SUM(role='Admin') AS TotalAdmin,
                SUM(role='Super Admin') AS TotalSuperAdmin
            FROM users;
        ";

                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open(); // necessary because we will use ExecuteReader

                    // Load users (DataAdapter will handle closing automatically)
                    using (MySqlCommand cmd = new MySqlCommand(queryUsers, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        tblDataGridView.Rows.Clear();
                        foreach (DataRow row in dt.Rows)
                        {

                            bool isActive = Convert.ToBoolean(row["isActive"]);
                            string statusText = isActive ? "Active" : "Inactive";

                            int rowIndex = tblDataGridView.Rows.Add(
                                row["id"].ToString(),
                                row["name"].ToString(),
                                row["username"].ToString(),
                                row["email"].ToString(),
                                row["role"].ToString(),
                                statusText,
                                "Edit",
                                "Delete"
                            );

                           
                        }
                    }


                    // Load counts
                    using (MySqlCommand cmdCount = new MySqlCommand(queryCounts, conn))
                    using (MySqlDataReader reader = cmdCount.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblNoUser.Text = reader["TotalUsers"].ToString();
                            lblNoStaff.Text = reader["TotalStaff"].ToString();
                            lblNoAdmin.Text = reader["TotalAdmin"].ToString();
                            lblNoSuperAdmin.Text = reader["TotalSuperAdmin"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users:\n" + ex.Message);
            }
        }
        private void TblDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (tblDataGridView.Columns[e.ColumnIndex].Name == "colStatus")
            {
                string status = e.Value?.ToString();
                if (status == "Active")
                    e.CellStyle.ForeColor = Color.Green;
                else if (status == "Inactive")
                    e.CellStyle.ForeColor = Color.Red;
            }
        }
        private void tblDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (tblDataGridView.Columns[e.ColumnIndex].Name == "colEdit")
            {
                var cell = tblDataGridView.Rows[e.RowIndex].Cells["colID"];
                if (cell == null || cell.Value == null) return;

                int id = Convert.ToInt32(cell.Value);

                string name = tblDataGridView.Rows[e.RowIndex].Cells["colName"].Value?.ToString();
                string username = tblDataGridView.Rows[e.RowIndex].Cells["colUsername"].Value?.ToString();
                string email = tblDataGridView.Rows[e.RowIndex].Cells["colEmail"].Value?.ToString();
                string role = tblDataGridView.Rows[e.RowIndex].Cells["colRole"].Value?.ToString();
                string status = tblDataGridView.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString();

                // Open edit form
                EditUserForm editForm = new EditUserForm(id, name, username, email, role, status);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers(); // refresh grid
                }
            }
            if (tblDataGridView.Columns[e.ColumnIndex].Name == "colDelete")
            {
                string username = tblDataGridView.Rows[e.RowIndex].Cells["colUsername"].Value.ToString();

                DialogResult confirm = MessageBox.Show(
                    $"Are you sure you want to delete user '{username}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    DeleteUser(username);
                    LoadUsers();
                }
            }
        }
        private void DeleteUser(string username)
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    // Soft delete: mark as inactive instead of deleting
                    string query = "UPDATE users SET isActive=0 WHERE Username=@username";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message,
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }
        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            using (CreateUserForm form = new CreateUserForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadUsers(); // Refresh the table
                }
            }
        }
    }
}