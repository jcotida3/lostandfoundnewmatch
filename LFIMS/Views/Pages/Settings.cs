using LFsystem.Helpers;
using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();

            ApplyRoleBasedSettingVisibility();
            LoadUserProfile();
            LoadCategories();
            LoadDepartments();
            LoadLocation();
            // Subscribe event handlers
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            dvgCategories.CellClick += DgvCategories_CellClick;
            dvgLocation.CellClick += DgvLocation_CellClick;
            dvgDepartment.CellClick += DgvDepartment_CellClick;
        }
        private void ApplyRoleBasedSettingVisibility()
        {
            if(Session.Role != "Super Admin")
            {
                Tabs.Visible = false;
            }
            else
            {
                Tabs.Visible = true;
            }
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
        private void LoadCategories() =>
            LoadDataGridView(dvgCategories, "categories", "colCategoryID", "colCategoryName", "colCategoryEdit", "colCategoryDelete");

        private void LoadLocation() =>
            LoadDataGridView(dvgLocation, "locations", "colLocationID", "colLocationName", "colLocationEdit", "colLocationDelete");

        private void LoadDepartments() =>
            LoadDataGridView(dvgDepartment, "departments", "colDepartmentID", "colDepartmentName", "colDepartmentEdit", "colDepartmentDelete");
        private void LoadDataGridView(DataGridView dgv, string tableName, string idCol, string nameCol, string editCol, string deleteCol)
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = $"SELECT id, name FROM {tableName}";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgv.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        int rowIndex = dgv.Rows.Add();
                        dgv.Rows[rowIndex].Cells[idCol].Value = row["id"];
                        dgv.Rows[rowIndex].Cells[nameCol].Value = row["name"];
                        dgv.Rows[rowIndex].Cells[editCol].Value = "Edit";
                        dgv.Rows[rowIndex].Cells[deleteCol].Value = "Delete";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using var form = new AddFilterForm("categories");
            form.ShowDialog();
            LoadCategories(); // Reload DataGridView after closing
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            using var form = new AddFilterForm("locations");
            form.ShowDialog();
            LoadLocation();
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            using var form = new AddFilterForm("departments");
            form.ShowDialog();
            LoadDepartments();
        }
        private void HandleEditDeleteClick(
    DataGridView dgv,
    DataGridViewCellEventArgs e,
    string tableName,
    Action reloadAction)
        {
            if (e.RowIndex < 0) return;

            var id = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            var name = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            var column = dgv.Columns[e.ColumnIndex].Name;

            // EDIT
            if (column.Contains("Edit"))
            {
                using var form = new EditFilterForm(tableName, id, name);
                form.ShowDialog();
                reloadAction();
            }

            // DELETE
            else if (column.Contains("Delete"))
            {
                if (MessageBox.Show("Are you sure you want to delete this item?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using var conn = Database.GetConnection();
                    conn.Open();
                    string query = $"DELETE FROM {tableName} WHERE id=@id";

                    using var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Item deleted successfully!");
                    reloadAction();
                }
            }
        }
        private void DgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleEditDeleteClick(dvgCategories, e, "categories", LoadCategories);
        }

        private void DgvLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleEditDeleteClick(dvgLocation, e, "locations", LoadLocation);
        }

        private void DgvDepartment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleEditDeleteClick(dvgDepartment, e, "departments", LoadDepartments);
        }

    }
}
