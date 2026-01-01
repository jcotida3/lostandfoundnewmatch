using LFsystem.Services;
using MySql.Data.MySqlClient;

namespace LFsystem.Views.Pages
{
    public partial class ClaimItemForm : Form
    {
        private readonly int foundItemId;
        private readonly int? matchedLostItemId; // optional

        public ClaimItemForm(int foundItemId, int? matchedLostItemId = null)
        {
            InitializeComponent();
            this.foundItemId = foundItemId;
            this.matchedLostItemId = matchedLostItemId;

            LoadDepartments();
            LoadYearLevels();
            LoadItemDetails();
        }

        private void LoadItemDetails()
        {
            // Load Found item
            string queryFound = @"
SELECT i.title, c.name AS category, l.name as location
FROM items i
LEFT JOIN categories c ON i.category_id = c.id
LEFT JOIN locations l on i.location_id = l.id
WHERE i.id = @item_id";

            using var conn = Database.GetConnection();
            conn.Open();

            using (var cmd = new MySqlCommand(queryFound, conn))
            {
                cmd.Parameters.AddWithValue("@item_id", foundItemId);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    itemTitleValue.Text = reader.GetString("title");
                    itemCategoryValue.Text = reader.GetString("category");
                    itemLocationValue.Text = reader.GetString("location");
                }
            }

            // Load matched Lost item details if exists
            if (matchedLostItemId.HasValue)
            {
                string queryLost = @"
SELECT i.title, c.name AS category, l.name as location
FROM items i
LEFT JOIN categories c ON i.category_id = c.id
LEFT JOIN locations l on i.location_id = l.id
WHERE i.id = @item_id";

                using var cmdLost = new MySqlCommand(queryLost, conn);
                cmdLost.Parameters.AddWithValue("@item_id", matchedLostItemId.Value);
                using var readerLost = cmdLost.ExecuteReader();
                if (readerLost.Read())
                {
                    itemTitleValue.Text = readerLost.GetString("title");
                    itemCategoryValue.Text = readerLost.GetString("category");
                    itemLocationValue.Text = readerLost.GetString("location");
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            using var conn = Database.GetConnection();
            conn.Open();

            // Insert claim for Found item
            string query = @"
INSERT INTO claims 
(item_id, claimant_name, claimant_contact, student_id, year_level, department, claim_date)
VALUES (@item_id, @claimant_name, @claimant_contact, @student_id, @year_level, @department, NOW())";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@item_id", foundItemId);
            cmd.Parameters.AddWithValue("@claimant_name", txtClaimantName.Text.Trim());
            cmd.Parameters.AddWithValue("@claimant_contact", txtClaimantContact.Text.Trim());
            cmd.Parameters.AddWithValue("@student_id", txtStudentID.Text.Trim());
            cmd.Parameters.AddWithValue("@year_level", cmbYearLevel.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@department", cmbDepartment.SelectedItem.ToString());

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                // Update Found item to Claimed
                string updateFound = "UPDATE items SET status='Claimed' WHERE id=@item_id";
                using var updateCmd = new MySqlCommand(updateFound, conn);
                updateCmd.Parameters.AddWithValue("@item_id", foundItemId);
                updateCmd.ExecuteNonQuery();

                // Update matched Lost item to Claimed if exists
                if (matchedLostItemId.HasValue)
                {
                    string updateLost = "UPDATE items SET status='Claimed' WHERE id=@item_id";
                    using var updateLostCmd = new MySqlCommand(updateLost, conn);
                    updateLostCmd.Parameters.AddWithValue("@item_id", matchedLostItemId.Value);
                    updateLostCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Claim submitted successfully and item(s) marked as Claimed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to submit claim.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtClaimantName.Text) ||
                string.IsNullOrWhiteSpace(txtClaimantContact.Text) ||
                string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                MessageBox.Show("Please fill in all text fields.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbYearLevel.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Year Level.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Department.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void LoadDepartments()
        {
            string query = "SELECT id, name FROM departments ORDER BY name";

            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            cmbDepartment.Items.Clear(); // Clear first
            while (reader.Read())
            {
                // Add as a KeyValuePair or just the name
                cmbDepartment.Items.Add(reader["name"].ToString());
            }

            if (cmbDepartment.Items.Count > 0)
                cmbDepartment.SelectedIndex = 0; // Optional: select first by default
        }

        private void LoadYearLevels()
        {
            cmbYearLevel.Items.Clear();
            cmbYearLevel.Items.Add("1st Year");
            cmbYearLevel.Items.Add("2nd Year");
            cmbYearLevel.Items.Add("3rd Year");
            cmbYearLevel.Items.Add("4th Year");

            cmbYearLevel.SelectedIndex = 0; // Optional default
        }

    }
}