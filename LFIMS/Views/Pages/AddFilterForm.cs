using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class AddFilterForm : Form
    {
        private readonly string tableName;

        public AddFilterForm(string tableName)
        {
            InitializeComponent();
            this.tableName = tableName;

            this.Text = "Add " + tableName; // e.g. "Add Category"
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                string query = $"INSERT INTO {tableName} (name) VALUES (@name)";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Item added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message);
                return;
            }

            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
