using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class EditFilterForm : Form
    {
        private readonly string tableName;
        private readonly string recordId;

        public EditFilterForm(string tableName, string id, string currentName)
        {
            InitializeComponent();

            this.tableName = tableName;
            this.recordId = id;

            this.Text = "Edit " + tableName;
            txtName.Text = currentName;
            lblTitle.Text = $"Edit " + tableName;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string newName = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }

            using var conn = Database.GetConnection();
            conn.Open();

            string query = $"UPDATE {tableName} SET name=@name WHERE id=@id";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", newName);
            cmd.Parameters.AddWithValue("@id", recordId);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Updated successfully!");
            Close();
        }
    }
}
