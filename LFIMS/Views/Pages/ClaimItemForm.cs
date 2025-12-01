using LFsystem.Helpers;
using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class ClaimItemForm : Form
    {
        private readonly int itemId;
        private readonly string itemName;

        public ClaimItemForm(int itemId, string itemName)
        {
            InitializeComponent();
            this.itemId = itemId;
            this.itemName = itemName ?? "Item";
            lblItemName.Text = $"Claiming: {this.itemName}";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string contact = txtContact.Text.Trim();
            string notes = txtNotes.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter your name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show("Please enter your contact number or email.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Focus();
                return;
            }

            // Optional: prevent duplicate pending claims for same item by same contact
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                using var checkCmd = new MySqlCommand(@"SELECT COUNT(*) FROM claims 
                                                        WHERE item_id=@item AND claimant_contact=@contact AND status='Pending'", conn);
                checkCmd.Parameters.AddWithValue("@item", itemId);
                checkCmd.Parameters.AddWithValue("@contact", contact);
                var cnt = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (cnt > 0)
                {
                    MessageBox.Show("There is already a pending claim for this item using the same contact. Please wait for admin review or use a different contact.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var cmd = new MySqlCommand(@"
INSERT INTO claims (item_id, claimant_name, claimant_contact, claimant_notes, claim_date, status)
VALUES (@item, @name, @contact, @notes, NOW(), 'Pending')", conn);

                cmd.Parameters.AddWithValue("@item", itemId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to submit claim: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Claim submitted successfully. An admin will review it shortly.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
