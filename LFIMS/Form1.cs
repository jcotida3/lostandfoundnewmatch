/*using LFsystem.Services;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace LFsystem.Views
{
    public partial class BuildingRoomForm : Form
    {
        public BuildingRoomForm()
        {
            InitializeComponent();
            LoadBuildings();
        }

        private void LoadBuildings()
        {
            cmbBuildings.Items.Clear();
            using var conn = Database.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT id, name FROM buildings ORDER BY name", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbBuildings.Items.Add(new { Id = reader.GetInt32("id"), Name = reader.GetString("name") });
            }

            cmbBuildings.DisplayMember = "Name";
            cmbBuildings.ValueMember = "Id";

            if (cmbBuildings.Items.Count > 0)
            {
                cmbBuildings.SelectedIndex = 0;
            }
        }

        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            string buildingName = txtBuildingName.Text.Trim();
            if (string.IsNullOrEmpty(buildingName))
            {
                MessageBox.Show("Enter a building name.");
                return;
            }

            using var conn = Database.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("INSERT INTO buildings (name) VALUES (@name)", conn);
            cmd.Parameters.AddWithValue("@name", buildingName);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Building added!");
            txtBuildingName.Clear();
            LoadBuildings();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (cmbBuildings.SelectedItem == null)
            {
                MessageBox.Show("Select a building.");
                return;
            }

            dynamic selectedBuilding = cmbBuildings.SelectedItem;
            int buildingId = selectedBuilding.Id;
            string roomName = txtRoomName.Text.Trim();

            if (string.IsNullOrEmpty(roomName))
            {
                MessageBox.Show("Enter a room name.");
                return;
            }

            using var conn = Database.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("INSERT INTO rooms (building_id, name) VALUES (@bid, @name)", conn);
            cmd.Parameters.AddWithValue("@bid", buildingId);
            cmd.Parameters.AddWithValue("@name", roomName);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Room added!");
            txtRoomName.Clear();
            LoadRooms(buildingId);
        }

        private void cmbBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuildings.SelectedItem == null) return;

            dynamic selectedBuilding = cmbBuildings.SelectedItem;
            int buildingId = selectedBuilding.Id;
            LoadRooms(buildingId);
        }

        private void LoadRooms(int buildingId)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT id, name FROM rooms WHERE building_id=@bid ORDER BY name", conn);
            cmd.Parameters.AddWithValue("@bid", buildingId);
            using var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            dgvRooms.DataSource = dt;
        }
    }
}
*/
