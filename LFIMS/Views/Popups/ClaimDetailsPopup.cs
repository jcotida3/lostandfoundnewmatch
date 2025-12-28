using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace LFsystem.Views.Popups
{
    public partial class ClaimDetailPopupForm : Form
    {
        private int claimId;

        public ClaimDetailPopupForm(int claimId)
        {
            InitializeComponent();
            this.claimId = claimId;
            LoadClaimData();
        }

        private void LoadClaimData()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string query = @"
        SELECT 
            c.id AS claim_id,
            c.item_id,
            c.claimant_name,
            c.claimant_contact,
            c.claim_notes,
            c.status AS claim_status,
            c.claim_date,
            i.title,
            i.description,
            i.image_path,
            i.status AS item_status,
            cat.name AS category_name,
            loc.name AS location_name
        FROM claims c
        JOIN items i ON c.item_id = i.id
        LEFT JOIN categories cat ON i.category_id = cat.id
        LEFT JOIN locations loc ON i.location_id = loc.id
        WHERE c.id = @claimId";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@claimId", claimId);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                int itemId = reader["item_id"] != DBNull.Value ? reader.GetInt32("item_id") : 0;
                txtItemID.Text = $"LF-{itemId}";
                txtTitle.Text = reader["title"].ToString();
                txtDescription.Text = reader["description"].ToString();
                txtCategory.Text = reader["category_name"] != DBNull.Value ? reader["category_name"].ToString() : "N/A";
                txtLocation.Text = reader["location_name"] != DBNull.Value ? reader["location_name"].ToString() : "N/A";
                txtClaimant.Text = reader["claimant_name"].ToString();
                txtContact.Text = reader["claimant_contact"].ToString();
                txtNotes.Text = reader["claim_notes"].ToString();
                txtDate.Text = Convert.ToDateTime(reader["claim_date"]).ToString("yyyy-MM-dd HH:mm");
                txtStatus.Text = reader["claim_status"].ToString();

                string imagePath = reader["image_path"].ToString();
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    picItem.Image = Image.FromFile(imagePath);
                    picItem.SizeMode = PictureBoxSizeMode.Zoom;
                }

                string claimStatus = reader["claim_status"].ToString();
                string itemStatus = reader["item_status"].ToString();

                // Show Approve/Reject buttons ONLY if claim is Pending AND item is not already Claimed
                if (claimStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase) &&
                    !itemStatus.Equals("Claimed", StringComparison.OrdinalIgnoreCase))
                {
                    btnApprove.Visible = true;
                    btnApprove.Enabled = true;
                    btnReject.Visible = true;
                    btnReject.Enabled = true;
                }
                else
                {
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                }
            }
        }




        private void BtnApprove_Click(object sender, EventArgs e)
        {
            UpdateClaimStatus("Approved");
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            UpdateClaimStatus("Rejected");
        }

        private void UpdateClaimStatus(string newStatus)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            // 1. Update claim status
            string updateClaim = "UPDATE claims SET status = @status WHERE id = @id";
            using (var cmd = new MySqlCommand(updateClaim, conn))
            {
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", claimId);
                cmd.ExecuteNonQuery();
            }

            // 2. Get the item ID related to this claim
            int itemId = 0;
            string getItem = "SELECT item_id FROM claims WHERE id = @claimId";
            using (var cmd = new MySqlCommand(getItem, conn))
            {
                cmd.Parameters.AddWithValue("@claimId", claimId);
                var result = cmd.ExecuteScalar();
                if (result != null)
                    itemId = Convert.ToInt32(result);
            }

            // 3. Update the items table status
            if (itemId > 0)
            {
                // If admin approves → item becomes Claimed
                // If admin rejects → item becomes Approved (normal)
                string newItemStatus = (newStatus == "Approved") ? "Claimed" : "Approved";

                string updateItem = "UPDATE items SET status = @itemStatus WHERE id = @itemId";
                using (var cmd = new MySqlCommand(updateItem, conn))
                {
                    cmd.Parameters.AddWithValue("@itemStatus", newItemStatus);
                    cmd.Parameters.AddWithValue("@itemId", itemId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show($"Claim {newStatus}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
