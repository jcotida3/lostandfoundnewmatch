using LFsystem.Helpers;
using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class MatchItems : UserControl
    {
        public MatchItems()
        {
            InitializeComponent();
            LoadMatchSuggestions();
        }

        private void LoadMatchSuggestions()
        {
            dgvMatches.Rows.Clear();

                        string query = @"
                SELECT
                lost.id   AS lost_id,
                found.id  AS found_id,

                lost.title  AS lost_title,
                found.title AS found_title,

                c.name AS category,
                l.name AS location,

                (
                    /* Category match */
                    CASE WHEN lost.category_id = found.category_id THEN 30 ELSE 0 END +

                    /* Location match */
                    CASE WHEN lost.location_id = found.location_id THEN 20 ELSE 0 END +

                    /* Title similarity */
                    CASE
                        WHEN found.title LIKE CONCAT('%', lost.title, '%')
                          OR lost.title LIKE CONCAT('%', found.title, '%')
                        THEN 25
                        ELSE 0
                    END +

                    /* Description similarity (basic keyword overlap) */
                    CASE
                        WHEN found.description LIKE CONCAT('%', SUBSTRING_INDEX(lost.description, ' ', 3), '%')
                          OR lost.description LIKE CONCAT('%', SUBSTRING_INDEX(found.description, ' ', 3), '%')
                        THEN 15
                        ELSE 0
                    END +

                    /* Date proximity */
                    CASE
                        WHEN ABS(DATEDIFF(lost.created_at, found.created_at)) <= 1 THEN 10
                        WHEN ABS(DATEDIFF(lost.created_at, found.created_at)) <= 3 THEN 7
                        WHEN ABS(DATEDIFF(lost.created_at, found.created_at)) <= 7 THEN 4
                        ELSE 0
                    END
                ) AS match_score

            FROM items lost
            JOIN items found
                ON lost.type = 'Lost'
               AND found.type = 'Found'

            LEFT JOIN categories c ON lost.category_id = c.id
            LEFT JOIN locations l ON lost.location_id = l.id

            WHERE lost.status = 'Approved'
              AND found.status = 'Approved'
              AND lost.matched_item_id IS NULL
              AND found.matched_item_id IS NULL

            HAVING match_score >= 45
            ORDER BY match_score DESC;
            ";

           try
    {
        using var conn = Database.GetConnection();
        conn.Open();
        using var cmd = new MySqlCommand(query, conn);
        using var reader = cmd.ExecuteReader();

        bool hasRows = false;

        while (reader.Read())
        {
            hasRows = true;
            int rowIndex = dgvMatches.Rows.Add();

            dgvMatches.Rows[rowIndex].Cells["colLostId"].Value = reader["lost_id"];
            dgvMatches.Rows[rowIndex].Cells["colFoundId"].Value = reader["found_id"];
            dgvMatches.Rows[rowIndex].Cells["colLostTitle"].Value = reader["lost_title"];
            dgvMatches.Rows[rowIndex].Cells["colFoundTitle"].Value = reader["found_title"];
            dgvMatches.Rows[rowIndex].Cells["colCategory"].Value = reader["category"];
            dgvMatches.Rows[rowIndex].Cells["colLocation"].Value = reader["location"];
            dgvMatches.Rows[rowIndex].Cells["colScore"].Value = reader["match_score"] + "%";
        }

                // If no matches found, show a centered message spanning all visible columns
                if (!hasRows)
                {
                    int rowIndex = dgvMatches.Rows.Add();

                    dgvMatches.Rows[rowIndex].Cells["colLostTitle"].Value = "No items to be matched";
                    dgvMatches.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                    dgvMatches.Rows[rowIndex].DefaultCellStyle.Font = new Font(dgvMatches.Font, FontStyle.Italic);
                    dgvMatches.Rows[rowIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Clear other cells
                    dgvMatches.Rows[rowIndex].Cells["colFoundTitle"].Value = "";
                    dgvMatches.Rows[rowIndex].Cells["colCategory"].Value = "";
                    dgvMatches.Rows[rowIndex].Cells["colLocation"].Value = "";
                    dgvMatches.Rows[rowIndex].Cells["colScore"].Value = "";

                    // Hide the button cell
                    dgvMatches.Rows[rowIndex].Cells["colAction"].Value = null;
                    dgvMatches.Rows[rowIndex].Cells["colAction"].ReadOnly = true;
                    dgvMatches.Rows[rowIndex].Cells["colAction"].Style.BackColor = dgvMatches.BackgroundColor;
                    dgvMatches.Rows[rowIndex].Cells["colAction"].Style.SelectionBackColor = dgvMatches.BackgroundColor;
                }

            }
            catch (Exception ex)
    {
        MessageBox.Show("Error loading match suggestions:\n" + ex.Message);
    }
}

        private void dgvMatches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Only act on the Action column
            if (dgvMatches.Columns[e.ColumnIndex].Name != "colAction") return;

            // Check if this is the "No items" row
            var lostIdCell = dgvMatches.Rows[e.RowIndex].Cells["colLostId"].Value;
            var foundIdCell = dgvMatches.Rows[e.RowIndex].Cells["colFoundId"].Value;
            if (lostIdCell == null || foundIdCell == null) return;

            int lostId = Convert.ToInt32(lostIdCell);
            int foundId = Convert.ToInt32(foundIdCell);

            using var form = new ConfirmMatchForm(lostId, foundId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadMatchSuggestions(); // refresh after confirmed
            }
        }


    }
}

 