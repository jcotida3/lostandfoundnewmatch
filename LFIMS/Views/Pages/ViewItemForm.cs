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
                                       l.name AS location, d.name AS department,
                                       i.student_name AS reporter_name, i.student_contact AS reporter_contact,
                                       u.name AS reported_by,
                                       i.date_created, i.date_updated
                                FROM items i
                                LEFT JOIN categories c ON i.category_id = c.id
                                LEFT JOIN locations l ON i.location_id = l.id
                                LEFT JOIN departments d ON i.department_id = d.id
                                LEFT JOIN users u ON i.reporter_id = u.id
                                WHERE i.id = @itemId";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@itemId", _itemId);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Basic info
                    string reporterName = reader["reporter_name"] == DBNull.Value ? "" : reader["reporter_name"].ToString()!;
                    string reporterContact = reader["reporter_contact"] == DBNull.Value ? "" : reader["reporter_contact"].ToString()!;
                    string reportedBy = reader["reported_by"] == DBNull.Value ? "" : reader["reported_by"].ToString()!;
                    string itemType = reader["type"] == DBNull.Value ? "" : reader["type"].ToString()!;
                    


                    lblItemName.Text = reader["title"].ToString();
                    lblDescription.Text = reader["description"].ToString();
                    lblLocation.Text = reader["location"].ToString();
                    lblDepartment.Text = reader["department"].ToString();
                    lblReportedBy.Text = reportedBy;
                    lblSubtitle.Text = $" - {reader["category"]}";
                    lblItemType.Text = itemType;

                    UpdateTypeChip(itemType);

                    // Handle pnlFinder based on type
                    if (itemType == "Found")
                    {
                        pnlFinder.Visible = true;
                        lblReporterName.Text = string.IsNullOrWhiteSpace(reporterName) ? "NA" : reporterName;
                        lblReporterContact.Text = string.IsNullOrWhiteSpace(reporterContact) ? "NA" : reporterContact;
                    }
                    else if (itemType == "Lost")
                    {
                        if (string.IsNullOrWhiteSpace(reporterName) && string.IsNullOrWhiteSpace(reporterContact))
                            pnlFinder.Visible = false;
                        else
                        {
                            pnlFinder.Visible = true;
                            lblReporterName.Text = reporterName;
                            lblReporterContact.Text = reporterContact;
                        }
                    }

                    // Status
                    string status = reader["status"] == DBNull.Value ? "" : reader["status"].ToString()!;
                    statusChip.Text = status.ToLower();
                    UpdateStatusColor(status);

                    // Dates
                    lblCreatedDate.Text = Convert.ToDateTime(reader["date_created"]).ToString("MMMM dd, yyyy hh:mm tt");
                    lblUpdatedDate.Text = reader["date_updated"] == DBNull.Value
                        ? "N/A"
                        : Convert.ToDateTime(reader["date_updated"]).ToString("MMMM dd, yyyy hh:mm tt");

                    // Image
                    // Image
                    string? imgPath = reader["image_path"] as string;

                    if (!string.IsNullOrWhiteSpace(imgPath))
                    {
                        string fullPath = Path.Combine(Application.StartupPath, imgPath);

                        if (File.Exists(fullPath))
                        {
                            try
                            {
                                using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                                {
                                    picBox.Image = Image.FromStream(fs);
                                }
                            }
                            catch
                            {
                                // Failed to load the image → use default
                                picBox.Image = Properties.Resources.default_item;
                            }
                        }
                        else
                        {
                            // File does not exist → default
                            picBox.Image = Properties.Resources.default_item;
                        }
                    }
                    else
                    {
                        // Empty or NULL → default
                        picBox.Image = Properties.Resources.default_item;
                    }

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
                    statusChip.BackColor = Color.FromArgb(173, 216, 230);
                    statusChip.ForeColor = Color.FromArgb(0, 0, 139);
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
