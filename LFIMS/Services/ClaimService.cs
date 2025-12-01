// File: LFsystem.Services/ClaimService.cs

using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
// Assuming a static helper class 'Database' exists in LFsystem.Helpers 
// with a method 'GetConnection()' that returns an open MySqlConnection.

namespace LFsystem.Services
{
    public class ClaimService
    {
        // Constructor, if needed, can be empty or handle initialization
        public ClaimService()
        {
            // Initialization code here
        }

        // --- AddClaim Method: Uses ONLY existing database columns ---
        public bool AddClaim(int itemId, string claimantName, string claimantContact, string claimNotes)
        {
            try
            {
                // NOTE: Replace 'Database.GetConnection()' with your actual connection method.
                using var conn = Database.GetConnection();
                conn.Open();

                string query = @"
                    INSERT INTO claims (item_id, claimant_name, claimant_contact, claim_notes, status, claim_date)
                    VALUES (@itemId, @name, @contact, @notes, 'Pending', NOW())";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@itemId", itemId);
                    cmd.Parameters.AddWithValue("@name", claimantName.Trim());
                    cmd.Parameters.AddWithValue("@contact", claimantContact.Trim());

                    // All detailed claim/proof info is stored here:
                    cmd.Parameters.AddWithValue("@notes", string.IsNullOrWhiteSpace(claimNotes) ? (object)DBNull.Value : claimNotes.Trim());

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting claim: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // --- ApproveClaim Method: Crucial Transaction Logic ---
        public bool ApproveClaim(int approvedClaimId, int itemId)
        {
            // NOTE: Replace 'Database.GetConnection()' with your actual connection method.
            using var conn = Database.GetConnection();
            conn.Open();

            // Start a transaction to ensure all 3 steps succeed or all fail.
            using var transaction = conn.BeginTransaction();
            try
            {
                // 1. Update the specific claim status to 'Approved'
                string updateApprovedClaimQuery = "UPDATE claims SET status = 'Approved' WHERE id = @approvedClaimId";
                using (var cmdApprovedClaim = new MySqlCommand(updateApprovedClaimQuery, conn, transaction))
                {
                    cmdApprovedClaim.Parameters.AddWithValue("@approvedClaimId", approvedClaimId);
                    cmdApprovedClaim.ExecuteNonQuery();
                }

                // 2. Update the item status to 'Claimed' (Based on your SQL dump's item statuses)
                string updateItemQuery = "UPDATE items SET status = 'Claimed' WHERE id = @itemId";
                using (var cmdItem = new MySqlCommand(updateItemQuery, conn, transaction))
                {
                    cmdItem.Parameters.AddWithValue("@itemId", itemId);
                    cmdItem.ExecuteNonQuery();
                }

                // 3. Reject all other PENDING claims for this item (The key logic)
                string rejectOtherClaimsQuery = "UPDATE claims SET status = 'Rejected' WHERE item_id = @itemId AND id != @approvedClaimId AND status = 'Pending'";
                using (var cmdRejectOthers = new MySqlCommand(rejectOtherClaimsQuery, conn, transaction))
                {
                    cmdRejectOthers.Parameters.AddWithValue("@itemId", itemId);
                    cmdRejectOthers.Parameters.AddWithValue("@approvedClaimId", approvedClaimId);
                    cmdRejectOthers.ExecuteNonQuery();
                }

                transaction.Commit(); // Commit all changes
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Revert all changes on error
                MessageBox.Show($"Error approving claim: {ex.Message}", "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // --- GetClaims Method: Fetches claims for display/comparison ---
        public DataTable GetClaims(out int totalRecords, string statusFilter = "", string searchTerm = "", int page = 1, int pageSize = 10, int? specificItemId = null)
        {
            DataTable dt = new DataTable();
            totalRecords = 0;
            // NOTE: Implement your connection and query setup here.

            try
            {
                // Example Query (adjust parameters and WHERE clause for pagination/filtering):
                string whereClause = "WHERE 1=1 ";
                if (specificItemId.HasValue)
                {
                    whereClause += " AND c.item_id = @specificItemId ";
                }
                // Add statusFilter and searchTerm logic to whereClause...

                string dataQuery = $@"
                    SELECT
                        c.id AS claim_id,
                        c.item_id,
                        i.title AS item_name,
                        i.description AS item_description, 
                        c.claimant_name,
                        c.claimant_contact,
                        c.claim_notes, -- Crucial field for comparison
                        c.claim_date,
                        c.status AS claim_status
                    FROM claims c
                    JOIN items i ON c.item_id = i.id
                    {whereClause}
                    ORDER BY c.claim_date DESC
                    LIMIT @pageSize OFFSET @offset;";

                // ... (Execute query and fill dt) ...
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching claims: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // --- RejectClaim (Placeholder) ---
        public bool RejectClaim(int claimId)
        {
            // Logic to simply set the status of a single claim to 'Rejected'
            try
            {
                // ... (Database operation to update claims SET status = 'Rejected' WHERE id = @claimId) ...
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error rejecting claim: {ex.Message}");
                return false;
            }
        }
    }
}