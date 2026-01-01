using LFsystem.Helpers; // for Database
using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class ArchivedItems : UserControl
    {
        private int currentPage = 1;
        private int pageSize = 5; // Rows per page
        private int totalRows = 0;
        private int totalPages = 0;

        public ArchivedItems()
        {
            InitializeComponent();

            // Set column wrap for description
            dgvRejected.Columns["colDescription"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvRejected.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            LoadRejectedItems();
            UpdatePageInfo();
        }

        // Get total number of rejected items for pagination
        private void GetTotalRejectedItems()
        {
            string query = "SELECT COUNT(*) FROM items WHERE status = 'Rejected'";
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var cmd = new MySqlCommand(query, conn);
                totalRows = Convert.ToInt32(cmd.ExecuteScalar());
                totalPages = (int)Math.Ceiling(totalRows / (double)pageSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting total rows: " + ex.Message);
            }
        }

        // Load rejected items with pagination and remaining time
        private void LoadRejectedItems()
        {
            dgvRejected.Rows.Clear();

            GetTotalRejectedItems(); // Update totalPages
            UpdatePageInfo();

            int offset = (currentPage - 1) * pageSize;

            string query = @"SELECT i.id, i.title, i.description, i.type, c.name AS category, 
                                    l.name AS location, u.name AS reporter_name, 
                                    i.status, i.created_at, i.delete_at
                             FROM items i
                             LEFT JOIN categories c ON i.category_id = c.id
                             LEFT JOIN locations l ON i.location_id = l.id
                             LEFT JOIN users u ON i.reporter_id = u.id
                             WHERE i.status = 'Rejected'
                             ORDER BY i.created_at DESC
                             LIMIT @limit OFFSET @offset";

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@limit", pageSize);
                cmd.Parameters.AddWithValue("@offset", offset);

                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int rowIndex = dgvRejected.Rows.Add();

                    dgvRejected.Rows[rowIndex].Cells["colItemId"].Value = reader["id"];
                    dgvRejected.Rows[rowIndex].Cells["colItem"].Value = reader["title"];
                    dgvRejected.Rows[rowIndex].Cells["colDescription"].Value = reader["description"];
                    dgvRejected.Rows[rowIndex].Cells["colType"].Value = reader["type"];
                    dgvRejected.Rows[rowIndex].Cells["colCategory"].Value = reader["category"];
                    dgvRejected.Rows[rowIndex].Cells["colLocation"].Value = reader["location"];
                    dgvRejected.Rows[rowIndex].Cells["colReportedBy"].Value = reader["reporter_name"];
                    dgvRejected.Rows[rowIndex].Cells["colStatus"].Value = reader["status"];
                    dgvRejected.Rows[rowIndex].Cells["colDateTime"].Value = reader["created_at"];

                    // Calculate remaining time before permanent deletion
                    if (reader["delete_at"] != DBNull.Value)
                    {
                        DateTime deleteAt = Convert.ToDateTime(reader["delete_at"]);
                        TimeSpan remaining = deleteAt - DateTime.Now;
                        dgvRejected.Rows[rowIndex].Cells["colTimeRemaining"].Value = remaining.TotalDays > 0
                            ? $"{Math.Ceiling(remaining.TotalDays)} days remaining"
                            : "Expired";
                    }
                    else
                    {
                        dgvRejected.Rows[rowIndex].Cells["colTimeRemaining"].Value = "-";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rejected items: " + ex.Message);
            }
        }

        // Update page info label
        private void UpdatePageInfo()
        {
            lblPageInfo.Text = $"Page {currentPage} of {Math.Max(totalPages, 1)}";
        }

        // Go to previous page
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadRejectedItems();
            }
        }

        // Go to next page
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadRejectedItems();
            }
        }

        private void dgvRejected_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex< 0)
            {
                return;
            }

            if (dgvRejected.Columns[e.ColumnIndex].Name == "colView")
            {
                int itemId = Convert.ToInt32(dgvRejected.Rows[e.RowIndex].Cells["colItemId"].Value);

                ViewItemForm viewForm = new ViewItemForm(itemId);
                viewForm.ShowDialog();
            }
            
        }
    }
}
