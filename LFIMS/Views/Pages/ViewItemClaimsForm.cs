// File: LFsystem.Views.Forms/ViewItemClaimsForm.cs

using LFsystem.Services;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace LFsystem.Views.Forms
{
    // Assuming the form contains: dgvItemClaims, btnApproveSelected, btnRejectSelected, and labels for item details.
    public partial class ViewItemClaimsForm : Form
    {
        private int _itemId;
        private ClaimService _claimService = new ClaimService();

        public ViewItemClaimsForm(int itemId)
        {
            InitializeComponent();
            _itemId = itemId;
            this.Text = $"Review Claims for Item ID: {itemId}";

            // Optional: LoadItemDetails() to show item name/image at the top

            SetupDataGridView();
            LoadClaimsForItemId();

            btnApproveSelected.Click += BtnApproveSelected_Click;
            btnRejectSelected.Click += BtnRejectSelected_Click;
        }

        private void SetupDataGridView()
        {
            dgvItemClaims.AutoGenerateColumns = false;
            dgvItemClaims.Columns.Clear();

            // Increase row height and enable wrap mode to view all claim_notes
            dgvItemClaims.RowTemplate.Height = 100;
            dgvItemClaims.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvItemClaims.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "claim_id", HeaderText = "ID", Width = 50 });
            dgvItemClaims.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "claim_status", HeaderText = "Status", Width = 80 });
            dgvItemClaims.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "claimant_name", HeaderText = "Claimant Name", Width = 150 });
            dgvItemClaims.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "claimant_contact", HeaderText = "Primary Contact", Width = 100 });

            // This is the CRUCIAL column for comparison
            dgvItemClaims.Columns.Add(new DataGridViewTextBoxColumn()
            { DataPropertyName = "claim_notes", HeaderText = "Claim & Proof Details", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void LoadClaimsForItemId()
        {
            int totalRecords;
            // Fetch ALL claims (Pending, Approved, Rejected) for full history
            DataTable dt = _claimService.GetClaims(out totalRecords, specificItemId: _itemId);
            dgvItemClaims.DataSource = dt;
        }

        // --- Approval Logic for Admin ---
        private void BtnApproveSelected_Click(object? sender, EventArgs e)
        {
            if (dgvItemClaims.SelectedRows.Count == 1)
            {
                int claimId = Convert.ToInt32(dgvItemClaims.SelectedRows[0].Cells["claim_id"].Value);

                if (MessageBox.Show("Approving this claim will automatically REJECT ALL OTHER PENDING CLAIMS for this item and mark the item as 'Claimed'. Proceed?", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_claimService.ApproveClaim(claimId, _itemId))
                    {
                        MessageBox.Show("Claim successfully approved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Signals parent to refresh
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select exactly one claim to approve.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // --- Rejection Logic for Admin ---
        private void BtnRejectSelected_Click(object? sender, EventArgs e)
        {
            if (dgvItemClaims.SelectedRows.Count == 1)
            {
                int claimId = Convert.ToInt32(dgvItemClaims.SelectedRows[0].Cells["claim_id"].Value);

                if (MessageBox.Show("Are you sure you want to reject only this claim?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_claimService.RejectClaim(claimId)) // Calls the simple rejection method
                    {
                        MessageBox.Show("Claim rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadClaimsForItemId(); // Refresh the grid to show the new status
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select exactly one claim to reject.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}