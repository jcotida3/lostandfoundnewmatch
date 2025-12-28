using Guna.UI2.WinForms;
using LFsystem.Helpers;
using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class ViewItemForm : Form
    {
        private int _itemId;

        public ViewItemForm(int itemId)
        {
            InitializeComponent();
            _itemId = itemId;
            LoadItemDetails();
        }

        private void LoadItemDetails()
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                string query = @"
            SELECT i.title, i.description, i.image_path,
                   c.name AS category, i.type, i.status,
                   l.name AS location,
                   i.student_name AS reporter_name, i.student_contact AS reporter_contact,
                   u.name AS reported_by,
                   i.created_at, i.updated_at
            FROM items i
            LEFT JOIN categories c ON i.category_id = c.id
            LEFT JOIN locations l ON i.location_id = l.id
            LEFT JOIN users u ON i.reporter_id = u.id
            WHERE i.id = @itemId";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemId", _itemId);

                using var reader = cmd.ExecuteReader();

                string itemStatus = "";

                if (reader.Read())
                {
                    // --- Existing code to load item info ---
                    lblItemName.Text = reader["title"]?.ToString() ?? "N/A";
                    lblDescription.Text = reader["description"]?.ToString() ?? "N/A";
                    lblLocation.Text = reader["location"]?.ToString() ?? "N/A";
                    lblCategory.Text = " - " + (reader["category"]?.ToString() ?? "N/A");

                    string reporterName = reader["reporter_name"]?.ToString() ?? "N/A";
                    string reporterContact = reader["reporter_contact"]?.ToString() ?? "N/A";
                    string reportedBy = reader["reported_by"]?.ToString() ?? "N/A";

                    lblReportedBy.Text = reportedBy;

                    string itemType = reader["type"]?.ToString() ?? "N/A";
                    lblItemType.Text = itemType;
                    UpdateTypeChip(itemType);

                    pnlFinder.Visible = (itemType == "Found" || (!string.IsNullOrWhiteSpace(reporterName) || !string.IsNullOrWhiteSpace(reporterContact)));
                    lblReporterName.Text = reporterName;
                    lblReporterContact.Text = reporterContact;

                    // Status
                    itemStatus = reader["status"]?.ToString() ?? "";
                    statusChip.Text = itemStatus.ToLower();
                    UpdateStatusColor(itemStatus);

                    // Dates
                    lblCreatedDate.Text = Convert.ToDateTime(reader["created_at"]).ToString("MMMM dd, yyyy hh:mm tt");
                    lblUpdatedDate.Text = reader["updated_at"] != DBNull.Value
                        ? Convert.ToDateTime(reader["updated_at"]).ToString("MMMM dd, yyyy  hh:mm tt")
                        : "N/A";

                    // Image
                    string imgPath = reader["image_path"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(imgPath))
                    {
                        string fullPath = Path.Combine(Application.StartupPath, imgPath);
                        picBox.Image = File.Exists(fullPath)
                            ? Image.FromFile(fullPath)
                            : Properties.Resources.default_item;
                    }
                    else
                    {
                        picBox.Image = Properties.Resources.default_item;
                    }
                }
                reader.Close();

                // --- Load claimant info if claimed ---
                if (itemStatus.ToUpper() == "CLAIMED")
                {
                    pnlClaimant.Visible = true; // Add a panel for claimant info
                    string claimQuery = @"
                SELECT claimant_name, claimant_contact, student_id, year_level, department, claim_date
                FROM claims
                WHERE item_id = @itemId
                ORDER BY claim_date DESC
                LIMIT 1";

                    using var claimCmd = new MySqlCommand(claimQuery, conn);
                    claimCmd.Parameters.AddWithValue("@itemId", _itemId);

                    using var claimReader = claimCmd.ExecuteReader();
                    if (claimReader.Read())
                    {
                        lblClaimantName.Text = claimReader["claimant_name"]?.ToString() ?? "N/A";
                        lblClaimantContact.Text = claimReader["claimant_contact"]?.ToString() ?? "N/A";
                        lblStudentID.Text = claimReader["student_id"]?.ToString() ?? "N/A";
                        lblYearLevel.Text = claimReader["year_level"]?.ToString() ?? "N/A";
                        lblDepartment.Text = claimReader["department"]?.ToString() ?? "N/A";
                        lblClaimDate.Text = claimReader["claim_date"] != DBNull.Value
                            ? Convert.ToDateTime(claimReader["claim_date"]).ToString("MMMM dd, yyyy")
                            : "N/A";
                    }
                }
                else
                {
                    pnlClaimant.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading item: " + ex.Message);
            }
        }

        private void UpdateTypeChip(string itemtype)
        {
            switch (itemtype.ToUpper())
            {
                case "LOST":
                    lblItemType.BackColor = Color.FromArgb(255, 228, 228);  // soft red background
                    lblItemType.ForeColor = Color.FromArgb(220, 53, 69);     // red text
                    break;

                case "FOUND":
                    lblItemType.BackColor = Color.FromArgb(212, 237, 218);  // soft green background
                    lblItemType.ForeColor = Color.FromArgb(40, 167, 69);     // green text
                    break;

                default:
                    lblItemType.BackColor = Color.LightGray;
                    lblItemType.ForeColor = Color.Black;
                    break;
            }

            if (!string.IsNullOrWhiteSpace(itemtype))
            {
                lblItemType.Text = char.ToUpper(itemtype[0]) + itemtype.Substring(1).ToLower();

            }
        }

        private void UpdateStatusColor(string status)
        {
            switch (status.ToUpper())
            {
                case "APPROVED":
                    statusChip.BackColor = Color.FromArgb(198, 239, 206);
                    statusChip.ForeColor = Color.FromArgb(0, 97, 0);
                    break;
                case "PENDING":
                    statusChip.BackColor = Color.FromArgb(255, 235, 156);
                    statusChip.ForeColor = Color.FromArgb(156, 101, 0);
                    break;
                case "CLAIMED":
                    statusChip.BackColor = Color.FromArgb(173, 216, 230); // light blue
                    statusChip.ForeColor = Color.FromArgb(0, 0, 139);     // dark blue
                    break;
                case "REJECTED":
                    statusChip.BackColor = Color.FromArgb(255, 192, 192);
                    statusChip.ForeColor = Color.FromArgb(139, 0, 0);
                    break;
                default:
                    statusChip.BackColor = Color.LightGray;
                    statusChip.ForeColor = Color.Black;
                    break;
            }
        }
    }
}
