using LFsystem.Helpers;
using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class ManageClaims : UserControl
    {
        public ManageClaims()
        {
            InitializeComponent();

            dgvClaims.CellClick += DgvClaims_CellClick;
            txtSearch.TextChanged += (s, e) => LoadClaims();
            btnRefresh.Click += (s, e) => LoadClaims();

            LoadClaims(); // initial load
        }

        private void LoadClaims()
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                string query = @"
SELECT id, item_id, claimant_name, claimant_contact, claim_notes, claim_date, status, admin_response_notes
FROM claims
WHERE (claimant_name LIKE @s OR claimant_contact LIKE @s OR claim_notes LIKE @s)
ORDER BY claim_date DESC";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@s", $"%{txtSearch.Text.Trim()}%");

                var dt = new DataTable();
                using (var da = new MySqlDataAdapter(cmd))
                    da.Fill(dt);

                dgvClaims.DataSource = dt;

                // Set column headers
                dgvClaims.Columns["id"].HeaderText = "ID";
                dgvClaims.Columns["item_id"].HeaderText = "Item ID";
                dgvClaims.Columns["claimant_name"].HeaderText = "Name";
                dgvClaims.Columns["claimant_contact"].HeaderText = "Contact";
                dgvClaims.Columns["claim_notes"].HeaderText = "Notes";
                dgvClaims.Columns["claim_date"].HeaderText = "Date";
                dgvClaims.Columns["status"].HeaderText = "Status";
                dgvClaims.Columns["admin_response_notes"].HeaderText = "Admin Notes";

                AddActionButtonsOnce();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load claims:\n" + ex.Message);
            }
        }

        private void AddActionButtonsOnce()
        {
            // Prevent duplicate buttons
            if (dgvClaims.Columns.Contains("approve_btn")) return;

            dgvClaims.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "approve_btn",
                HeaderText = "",
                Text = "Approve",
                UseColumnTextForButtonValue = true,
                Width = 90
            });
            dgvClaims.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "reject_btn",
                HeaderText = "",
                Text = "Reject",
                UseColumnTextForButtonValue = true,
                Width = 90
            });
            dgvClaims.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "respond_btn",
                HeaderText = "",
                Text = "Respond",
                UseColumnTextForButtonValue = true,
                Width = 90
            });
        }

        private void DgvClaims_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dgvClaims.Columns[e.ColumnIndex];
            int claimId = Convert.ToInt32(dgvClaims.Rows[e.RowIndex].Cells["id"].Value);
            string currentStatus = dgvClaims.Rows[e.RowIndex].Cells["status"].Value?.ToString() ?? "";

            if (col.Name == "approve_btn")
            {
                if (MessageBox.Show("Approve this claim?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    UpdateClaimStatus(claimId, "Approved", null, true);
            }
            else if (col.Name == "reject_btn")
            {
                if (MessageBox.Show("Reject this claim?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    UpdateClaimStatus(claimId, "Rejected", null, false);
            }
            else if (col.Name == "respond_btn")
            {
                using var dialog = new AdminRespondDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                    UpdateClaimStatus(claimId, dialog.ChosenStatus, dialog.ResponseNotes, dialog.ChosenStatus == "Approved");
            }
        }

        private void UpdateClaimStatus(int claimId, string newStatus, string adminNotes, bool markItemClaimed)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                using var cmd = new MySqlCommand(@"
UPDATE claims 
SET status=@status,
    admin_response_notes=@notes
WHERE id=@id", conn);

                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@notes", string.IsNullOrEmpty(adminNotes) ? DBNull.Value : adminNotes);
                cmd.Parameters.AddWithValue("@id", claimId);

                cmd.ExecuteNonQuery();

                if (markItemClaimed)
                {
                    using var q = new MySqlCommand("SELECT item_id FROM claims WHERE id=@id", conn);
                    q.Parameters.AddWithValue("@id", claimId);
                    var itemObj = q.ExecuteScalar();
                    if (itemObj != null)
                    {
                        int itemId = Convert.ToInt32(itemObj);
                        using var u = new MySqlCommand("UPDATE items SET status='Claimed' WHERE id=@id", conn);
                        u.Parameters.AddWithValue("@id", itemId);
                        u.ExecuteNonQuery();
                    }
                }

                LoadClaims();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating claim:\n" + ex.Message);
            }
        }
    }
}
