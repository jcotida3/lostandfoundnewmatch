using Guna.UI2.WinForms;
using LFsystem.Helpers;
using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class EditItemForm : Form
    {
        private readonly int _itemId;
        private string _imagePath;

        public EditItemForm(int itemId)
        {
            InitializeComponent();

            _itemId = itemId;

            // Load filter ComboBoxes first
            LoadFilters();
            LoadStatus();
            // Load item details
            LoadItemDetails();
            
        }

        private void LoadFilters()
        {
            LoadFilter(cmbCategory, "categories");
            LoadFilter(cmbLocation, "locations");
            LoadFilter(cmbDepartment, "departments");
        }

        private void LoadFilter(ComboBox combo, string table)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var query = $"SELECT id, name FROM {table} ORDER BY name ASC";
                var da = new MySqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);

                combo.DataSource = dt;
                combo.DisplayMember = "name";
                combo.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {table}: {ex.Message}");
            }
        }

        private void LoadItemDetails()
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                string query = @"
                    SELECT i.title, i.description, i.type, i.image_path,
                           i.category_id, i.location_id, i.department_id,
                           i.student_name, i.student_contact, i.status
                    FROM items i
                    WHERE i.id = @id";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _itemId);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // --- Title & Description ---
                    itemName.Text = reader["title"] != DBNull.Value ? reader["title"].ToString() : "";
                    itemDescription.Text = reader["description"] != DBNull.Value ? reader["description"].ToString() : "";

                    // --- Type RadioButtons ---
                    string type = reader["type"] != DBNull.Value ? reader["type"].ToString().ToLower() : "lost";
                    rbLost.Checked = type == "lost";
                    rbFound.Checked = type == "found";

                    // --- ComboBoxes ---
                    SelectComboBoxValue(cmbCategory, reader["category_id"]);
                    SelectComboBoxValue(cmbLocation, reader["location_id"]);
                    SelectComboBoxValue(cmbDepartment, reader["department_id"]);

                    // --- Finder Info ---
                    txtFindName.Text = reader["student_name"] != DBNull.Value ? reader["student_name"].ToString() : "";
                    txtFindContact.Text = reader["student_contact"] != DBNull.Value ? reader["student_contact"].ToString() : "";

                    // --- Image ---
                    _imagePath = reader["image_path"] != DBNull.Value ? reader["image_path"].ToString() : "";
                    LoadPicture(_imagePath);

                    string status = reader["status"] != DBNull.Value ? reader["status"].ToString() : "Pending";
                    cmbStatus.SelectedItem = status;
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading item: " + ex.Message);
            }
            UpdateFinderInfoVisibility();
        }
        private void LoadStatus()
        {
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Approved");
            cmbStatus.Items.Add("Claimed");
        }
        private void UpdateFinderInfoVisibility()
        {
            pnlFinderInformation.Visible = rbFound.Checked;

            if (rbLost.Checked)
            {
                pnlFinderInformation.Visible = false;
            }
        }
        private void rbType_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFinderInfoVisibility();
        }
        private void SelectComboBoxValue(ComboBox combo, object value)
        {
            if (value != DBNull.Value && value != null)
            {
                int id = Convert.ToInt32(value);
                if (combo.Items.Count > 0)
                {
                    combo.SelectedValue = id;
                }
            }
        }

        private void LoadPicture(string path)
        {
            try
            {
                Image img = Properties.Resources.default_item;
                if (!string.IsNullOrEmpty(path))
                {
                    string fullPath = Path.Combine(Application.StartupPath, path);
                    if (File.Exists(fullPath))
                        img = new Bitmap(fullPath);
                }
                picBox.Image = img;
            }
            catch
            {
                picBox.Image = Properties.Resources.default_item;
            }
        }

        // --- Replace button ---
        private void btnReplace_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _imagePath = ofd.FileName;
                picBox.Image = new Bitmap(_imagePath);
            }
        }

        // --- Cancel button ---
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- Save button ---
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                string query = @"
                    UPDATE items
                    SET title = @title,
                        description = @desc,
                        type = @type,
                        category_id = @cat,
                        location_id = @loc,
                        department_id = @dept,
                        student_name = @fname,
                        student_contact = @fcontact,
                        image_path = @img,
                        status = @status
                    WHERE id = @id";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", itemName.Text.Trim());
                cmd.Parameters.AddWithValue("@desc", itemDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@type", rbLost.Checked ? "Lost" : "Found");
                cmd.Parameters.AddWithValue("@cat", Convert.ToInt32(cmbCategory.SelectedValue));
                cmd.Parameters.AddWithValue("@loc", Convert.ToInt32(cmbLocation.SelectedValue));
                cmd.Parameters.AddWithValue("@dept", Convert.ToInt32(cmbDepartment.SelectedValue));
                cmd.Parameters.AddWithValue("@fname", txtFindName.Text.Trim());
                cmd.Parameters.AddWithValue("@fcontact", txtFindContact.Text.Trim());
                cmd.Parameters.AddWithValue("@img", _imagePath);
                cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@id", _itemId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating item: " + ex.Message);
            }
        }

        

      
    }
}
