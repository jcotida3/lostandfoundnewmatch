using LFsystem.Helpers;
using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class ConfirmMatchForm : Form
    {
        private readonly int lostId;
        private readonly int foundId;

        public ConfirmMatchForm(int lostId, int foundId)
        {
            InitializeComponent();
            this.lostId = lostId;
            this.foundId = foundId;

            LoadItemDetails();
        }

        private void LoadItemDetails()
        {
            string query = @"
                SELECT 
                    i.id, i.title, i.description, i.type,
                    c.name AS category,
                    l.name AS location,
                    i.created_at
                FROM items i
                LEFT JOIN categories c ON i.category_id = c.id
                LEFT JOIN locations l ON i.location_id = l.id
                WHERE i.id IN (@lostId, @foundId);
            ";

            using var conn = Database.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@lostId", lostId);
            cmd.Parameters.AddWithValue("@foundId", foundId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                bool isLost = reader["id"].ToString() == lostId.ToString();

                if (isLost)
                {
                    lblLostTitle.Text = reader["title"].ToString();
                    txtLostDescription.Text = reader["description"].ToString();
                    lblLostCategory.Text = reader["category"].ToString();
                    lblLostLocation.Text = reader["location"].ToString();
                    lblLostDate.Text = Convert.ToDateTime(reader["created_at"]).ToString("MMM dd, yyyy");
                }
                else
                {
                    lblFoundTitle.Text = reader["title"].ToString();
                    txtFoundDescription.Text = reader["description"].ToString();
                    lblFoundCategory.Text = reader["category"].ToString();
                    lblFoundLocation.Text = reader["location"].ToString();
                    lblFoundDate.Text = Convert.ToDateTime(reader["created_at"]).ToString("MMM dd, yyyy");
                }
            }
            GenerateMatchReasons(
                                lblLostTitle.Text, lblFoundTitle.Text,
                                txtLostDescription.Text, txtFoundDescription.Text,
                                lblLostCategory.Text, lblFoundCategory.Text,
                                lblLostLocation.Text, lblFoundLocation.Text,
                                DateTime.Parse(lblLostDate.Text), DateTime.Parse(lblFoundDate.Text)
);

        }

       
        private void GenerateMatchReasons(
    string lostTitle, string foundTitle,
    string lostDesc, string foundDesc,
    string lostCategory, string foundCategory,
    string lostLocation, string foundLocation,
    DateTime lostDate, DateTime foundDate)
        {
            var reasons = new List<string>();
            int totalScore = 0;

            // Category (+30)
            if (string.Equals(lostCategory, foundCategory, StringComparison.OrdinalIgnoreCase))
            {
                reasons.Add($"Same category: {lostCategory} (+30)");
                totalScore += 30;
            }

            // Location (+20)
            if (string.Equals(lostLocation, foundLocation, StringComparison.OrdinalIgnoreCase))
            {
                reasons.Add($"Same location: {lostLocation} (+20)");
                totalScore += 20;
            }

            // Title (+25)
            if (
                foundTitle.IndexOf(lostTitle, StringComparison.OrdinalIgnoreCase) >= 0 ||
                lostTitle.IndexOf(foundTitle, StringComparison.OrdinalIgnoreCase) >= 0
            )
            {
                reasons.Add($"Title similarity (+25): '{lostTitle}' vs '{foundTitle}'");
                totalScore += 25;
            }

            // Description (+15)
            string lostSnippet = string.Join(" ",
                lostDesc.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Take(3));

            string foundSnippet = string.Join(" ",
                foundDesc.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Take(3));

            if (
                foundDesc.IndexOf(lostSnippet, StringComparison.OrdinalIgnoreCase) >= 0 ||
                lostDesc.IndexOf(foundSnippet, StringComparison.OrdinalIgnoreCase) >= 0
            )
            {
                reasons.Add($"Description overlap (+15): '{lostSnippet}' vs '{foundSnippet}'");
                totalScore += 15;
            }

            // Date (+10 / +7 / +4)
            double daysDiff = Math.Abs((lostDate - foundDate).TotalDays);

            if (daysDiff <= 1)
            {
                reasons.Add("Reported on the same day (+10)");
                totalScore += 10;
            }
            else if (daysDiff <= 3)
            {
                reasons.Add("Reported within 3 days (+7)");
                totalScore += 7;
            }
            else if (daysDiff <= 7)
            {
                reasons.Add("Reported within 7 days (+4)");
                totalScore += 4;
            }

            // =============================
            // FINAL DISPLAY (INSIDE TEXTBOX)
            // =============================
            txtMatchReasons.Text =
                $"TOTAL MATCH SCORE: {totalScore}%{Environment.NewLine}" +
                "--------------------------------" + Environment.NewLine +
                (reasons.Count > 0
                    ? string.Join(Environment.NewLine, reasons)
                    : "No strong match reasons found.");
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            using var transaction = conn.BeginTransaction();

            try
            {
                string updateLost = @"
                    UPDATE items
                    SET matched_item_id = @foundId,
                        status = 'Matched'
                    WHERE id = @lostId;
                ";

                string updateFound = @"
                    UPDATE items
                    SET matched_item_id = @lostId,
                        status = 'Matched'
                    WHERE id = @foundId;
                ";

                using var cmd1 = new MySqlCommand(updateLost, conn, transaction);
                cmd1.Parameters.AddWithValue("@foundId", foundId);
                cmd1.Parameters.AddWithValue("@lostId", lostId);
                cmd1.ExecuteNonQuery();

                using var cmd2 = new MySqlCommand(updateFound, conn, transaction);
                cmd2.Parameters.AddWithValue("@lostId", lostId);
                cmd2.Parameters.AddWithValue("@foundId", foundId);
                cmd2.ExecuteNonQuery();

                transaction.Commit();

                MessageBox.Show("Items successfully matched!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Match failed:\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
