using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using LFsystem.Services;
using LFsystem.Views.Popups;
namespace LFsystem.Views.Pages
{
    public partial class ManageClaims : UserControl
    {
        public ManageClaims()
        {
            InitializeComponent();
            LoadClaims();
        }

        private void LoadClaims()
        {
            dgvClaims.Rows.Clear();

            using var conn = Database.GetConnection();
            conn.Open();

            string query = @"SELECT id, item_id, claimant_name, claimant_contact, 
                                    claim_notes, status, claim_date 
                             FROM claims 
                             ORDER BY claim_date DESC";

            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int claimId = reader.GetInt32("id");
                int itemId = reader.GetInt32("item_id");

                int rowIndex = dgvClaims.Rows.Add(
                    claimId,
                    $"LF-{itemId}", // LFID display
                    reader.GetString("claimant_name"),
                    reader.GetString("claimant_contact"),
                    reader.GetString("status"),
                    reader.GetDateTime("claim_date").ToString("yyyy-MM-dd HH:mm"),
                    "View" // text for btnView
                );

                // Optional: Gray out "View" button if not Pending
                if (reader.GetString("status") != "Pending")
                {
                    dgvClaims.Rows[rowIndex].Cells["btnView"].ReadOnly = true;
                    dgvClaims.Rows[rowIndex].Cells["btnView"].Style.BackColor = Color.LightGray;
                }
            }

            // Wire up click event
            dgvClaims.CellClick -= DgvClaims_CellClick;
            dgvClaims.CellClick += DgvClaims_CellClick;
        }

        private void DgvClaims_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvClaims.Columns[e.ColumnIndex].Name == "btnView")
            {
                int claimId = Convert.ToInt32(dgvClaims.Rows[e.RowIndex].Cells["id"].Value);
                OpenClaimDetailPopup(claimId);
            }
        }

        private void OpenClaimDetailPopup(int claimId)
        {
            try
            {
                using var popup = new ClaimDetailPopupForm(claimId);
                var result = popup.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadClaims(); // refresh grid after approve/reject
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening claim details:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateClaimStatus(int claimId, string newStatus)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string query = "UPDATE claims SET status = @status WHERE id = @id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@status", newStatus);
            cmd.Parameters.AddWithValue("@id", claimId);
            cmd.ExecuteNonQuery();

            LoadClaims(); // refresh grid
        }
    }
}
