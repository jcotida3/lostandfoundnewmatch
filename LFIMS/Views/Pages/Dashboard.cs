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
            lblTotalNum.Text = GetCount("SELECT COUNT(*) FROM items WHERE Status != 'Rejected' AND delete_at IS NULL");
            lblMyReportNum.Text = GetCount($"SELECT COUNT(*) FROM items WHERE reporter_id = @userId AND delete_at IS NULL", Session.UserId);
            lblPendingNum.Text = GetCount("SELECT COUNT(*) FROM items WHERE Status = 'Pending' AND delete_at IS NULL");
            lblApprovedNum.Text = GetCount("SELECT COUNT(*) FROM items WHERE Status = 'Approved' AND delete_at IS NULL");
            lblClaimedNum.Text = GetCount("SELECT COUNT(*) FROM items WHERE Status = 'Claimed' AND delete_at IS NULL");

            // Show/hide pending panel depending on role

            if (Session.Role == "Admin" || Session.Role == "SuperAdmin")
            {
                string pendingCount = GetCount("SELECT COUNT(*) FROM items WHERE Status = 'Pending'");

                btnReviewPending.Text = $"Review [{pendingCount}] Pending Items";
                panelPending.Visible = true;
            }    
            if (Session.Role != "Staff")
            {
                panelMyReport.Visible = false;
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