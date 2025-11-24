using Guna.UI2.WinForms;
using LFsystem.Helpers;
using LFsystem.Models;
using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class Report : UserControl
    {
        private string selectedImagePath = "";
        private readonly ItemService itemService = new ItemService();

        public Report()
        {
            InitializeComponent();
            pnlFinderInformation.Visible = false;

            // Radio buttons
            radioLost.CheckedChanged += RadioButtons_CheckedChanged;
            radioFound.CheckedChanged += RadioButtons_CheckedChanged;

            // Upload photo
            btnUploadPhoto.Click += UploadPhoto_Click;
            btnRemoveImage.Click += BtnRemoveImage_Click;

            // Report & Clear
            btnSubmit.Click += BtnSubmit_Click;
            btnClear.Click += BtnClear_Click;

            // Load dropdowns
            LoadCategories();
            LoadLocations();
            LoadDepartments();
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            pnlFinderInformation.Visible = radioFound.Checked;
        }

        private void UploadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;

                    // Load image without locking file
                    using (var fs = new FileStream(selectedImagePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var img = Image.FromStream(fs))
                        {
                            picItem.Image = new Bitmap(img);
                        }
                    }

                    picItem.SizeMode = PictureBoxSizeMode.Zoom;

                    // Only show remove button if an image is uploaded
                    btnRemoveImage.Visible = true;
                }
            }
        }

        private void BtnRemoveImage_Click(object sender, EventArgs e)
        {
            
            picItem.Image = Properties.Resources.upload_icon;
            picItem.SizeMode = PictureBoxSizeMode.Zoom;
            selectedImagePath = "";

            btnRemoveImage.Visible = false;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Determine Lost or Found
            string type = radioLost.Checked ? "Lost" :
                          radioFound.Checked ? "Found" : "";

            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Please select Lost or Found.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate required dropdowns
            if ((int)cmbItemCategory.SelectedValue == 0 ||
                (int)cmbItemLocation.SelectedValue == 0)
            {
                MessageBox.Show("Please select Category and Location.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if((int)cmbItemDepartment.SelectedValue == 0)
            {
                MessageBox.Show("Please select Department.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Optional reporter input: no need to validate
            string reporterName = string.IsNullOrWhiteSpace(txtFinderName.Text)
                                  ? null : txtFinderName.Text.Trim();
            string reporterEmail = string.IsNullOrWhiteSpace(txtFinderContact.Text)
                                  ? null : txtFinderContact.Text.Trim();

            // Validate item info
            if (string.IsNullOrWhiteSpace(txtItemName.Text) ||
                string.IsNullOrWhiteSpace(txtItemDescription.Text))
            {
                MessageBox.Show("Please enter Item Name and Description.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Prepare item model
                ItemModel item = new ItemModel
                {
                    Title = txtItemName.Text.Trim(),
                    Description = txtItemDescription.Text.Trim(),
                    Type = type,
                    CategoryId = Convert.ToInt32(cmbItemCategory.SelectedValue) == 0 ? (int?)null : Convert.ToInt32(cmbItemCategory.SelectedValue),
                    LocationId = Convert.ToInt32(cmbItemLocation.SelectedValue) == 0 ? (int?)null : Convert.ToInt32(cmbItemLocation.SelectedValue),
                    DepartmentId = Convert.ToInt32(cmbItemDepartment.SelectedValue) == 0 ? (int?)null : Convert.ToInt32(cmbItemDepartment.SelectedValue),
                    Status = (Session.Role == "Admin" || Session.Role == "Super Admin") ? "Approved" : "Pending",
                    ReporterId = Session.UserId, // staff/admin entering
                    StudentName = reporterName, // can be null
                    StudentEmail = reporterEmail, // can be null
                    DateReported = DateTime.Now
                };

                // Handle image
                item.ImagePath = SaveImage(selectedImagePath);

                // Add item via service
                bool success = itemService.AddItem(item);

                if (success)
                {
                    MessageBox.Show(item.Status == "Approved"
                        ? "Report submitted successfully!"
                        : "Report submitted successfully! Pending admin approval.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to submit report.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving report: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SaveImage(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
                return null;

            string uploadsDir = Path.Combine(Application.StartupPath, "uploads");
            if (!Directory.Exists(uploadsDir))
                Directory.CreateDirectory(uploadsDir);

            string uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(sourcePath);
            string relativePath = Path.Combine("uploads", uniqueName);
            string fullPath = Path.Combine(Application.StartupPath, relativePath);

            File.Copy(sourcePath, fullPath, true);
            return relativePath;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtItemName.Clear();
            txtItemDescription.Clear();
            txtFinderName.Clear();
            txtFinderContact.Clear();
            cmbItemCategory.SelectedIndex = 0;
            cmbItemLocation.SelectedIndex = 0;
            radioLost.Checked = false;
            radioFound.Checked = false;
            pnlFinderInformation.Visible = false;

            picItem.Image = Properties.Resources.upload_icon;
            selectedImagePath = "";
            btnRemoveImage.Visible = false;
        }

        private void LoadCategories()
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, name FROM categories";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow placeholder = dt.NewRow();
                    placeholder["id"] = 0;
                    placeholder["name"] = "Select Category";
                    dt.Rows.InsertAt(placeholder, 0);

                    cmbItemCategory.DataSource = dt;
                    cmbItemCategory.DisplayMember = "name";
                    cmbItemCategory.ValueMember = "id";
                    cmbItemCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void LoadLocations()
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, name FROM locations";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow placeholder = dt.NewRow();
                    placeholder["id"] = 0;
                    placeholder["name"] = "Select Location";
                    dt.Rows.InsertAt(placeholder, 0);

                    cmbItemLocation.DataSource = dt;
                    cmbItemLocation.DisplayMember = "name";
                    cmbItemLocation.ValueMember = "id";
                    cmbItemLocation.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading locations: " + ex.Message);
            }
        }
        private void LoadDepartments()
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, name FROM departments";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow placeholder = dt.NewRow();
                    placeholder["id"] = 0;
                    placeholder["name"] = "Select Department";
                    dt.Rows.InsertAt(placeholder, 0);

                    cmbItemDepartment.DataSource = dt;
                    cmbItemDepartment.DisplayMember = "name";
                    cmbItemDepartment.ValueMember = "id";
                    cmbItemDepartment.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }
    }
}