using LFsystem.Services;
using MySql.Data.MySqlClient;

namespace LFsystem.Views.Pages
{
    public partial class ClaimItemForm : Form
    {
        private readonly int itemId;


        public ClaimItemForm(int itemId)
        {
            InitializeComponent();
            this.itemId = itemId;

            LoadDepartments();
            LoadYearLevels();
            LoadItemDetails();
        }

        private void LoadItemDetails()
        {
            string query = @"
SELECT i.title, c.name AS category, l.name as location
FROM items i
LEFT JOIN categories c ON i.category_id = c.id
LEFT JOIN locations l on i.location_id = l.id
WHERE i.id = @item_id";
            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@item_id", itemId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                itemTitleValue.Text = reader.GetString("title");
                itemCategoryValue.Text = reader.GetString("category");
                itemLocationValue.Text = reader.GetString("location");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string query = @"INSERT INTO claims (item_id, claimant_name, claimant_contact, student_id, year_level, department, claim_date) VALUES(@item_id, @claimant_name, @claimant_contact, @student_id, @year_level, @department, NOW())";

            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@item_id", itemId);
            cmd.Parameters.AddWithValue("@claimant_name", txtClaimantName.Text.Trim());
            cmd.Parameters.AddWithValue("@claimant_contact", txtClaimantContact.Text.Trim());
            cmd.Parameters.AddWithValue("@student_id", txtStudentID.Text.Trim());

            // ComboBox selected values
            cmd.Parameters.AddWithValue("@year_level", cmbYearLevel.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@department", cmbDepartment.SelectedItem.ToString());

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                string updateQuery = "UPDATE items SET status='Claimed' WHERE id=@item_id";
                using var updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@item_id", itemId);
                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Claim submitted successfully and item marked as Claimed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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