using LFsystem.Helpers;  // for Session if needed
using LFsystem.Services; // for Database.cs
using LFsystem.Views.Main;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;


namespace LFsystem.Views.Pages
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            
            lblWelcome.Text = $"Welcome back, {Session.Name}";
            roleValue.Text = Session.Role;

            // Load item counts
            lblTotalNum.Text = GetCount("SELECT COUNT(*) FROM items");
            lblMyReportNum.Text = GetCount($"SELECT COUNT(*) FROM items WHERE reporter_id = @userId", Session.UserId);
            lblPendingNum.Text = GetCount("SELECT COUNT(*) FROM items WHERE Status = 'Pending'");
            lblApprovedNum.Text = GetCount("SELECT COUNT(*) FROM items WHERE Status = 'Approved'");
            lblClaimedNum.Text = GetCount("SELECT COUNT(*) FROM items WHERE Status = 'Claimed'");

            // Show/hide pending panel depending on role

            if (Session.Role == "Admin" || Session.Role == "Super Admin")
            {
                string pendingCount = GetCount("SELECT COUNT(*) FROM items WHERE Status = 'Pending'");

                btnReviewPending.Text = $"Review [{pendingCount}] Pending Items";
                panelPending.Visible = true;
            }    

        }
        private string GetCount(string query, int? userId = null)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        if (userId.HasValue)
                            cmd.Parameters.AddWithValue("@userId", userId.Value);

                        return cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                return "0";
            }
        }
        private void btnReviewPending_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm is MainForm mainForm)
            {
                var manageItemsPage = new ManageItems();
                mainForm.LoadPage(manageItemsPage);
                mainForm.ActivateSidebarButton("ManageItems");

                // Set filter to Pending
                manageItemsPage.SetStatusFilter("Pending");
            }
        }

    }
}