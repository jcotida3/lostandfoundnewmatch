using LFsystem.Services; // Make sure this namespace is correct
using System;
using System.Windows.Forms;

namespace LFsystem.Views.Popups
{
    // Make sure the class name matches your actual form name
    public partial class StaffClaimRequestForm : Form
    {
        private readonly int _itemId;
        private readonly ItemService _itemService;

        // Constructor to receive the Item ID and Name
        public StaffClaimRequestForm(int itemId, string itemName)
        {
            InitializeComponent();
            _itemId = itemId;
            // Initialize the ItemService instance
            _itemService = new ItemService();

            // Set up the UI labels and events
            // Replace lblItemTitle with your actual label name
            lblItemTitle.Text = $"Claim Request for: {itemName} (ID: {_itemId})";

            // Assuming your submit button is named btnSubmit
            btnSubmit.Click += BtnSubmit_Click;
        }

        private void BtnSubmit_Click(object? sender, EventArgs e)
        {
            // 1. Get user input
            // Ensure these control names match your UI design
            string claimantName = txtClaimantName.Text.Trim();
            string claimantContact = txtClaimantContact.Text.Trim();
            string claimNotes = txtClaimNotes.Text.Trim();

            // Basic validation
            if (string.IsNullOrWhiteSpace(claimantName) || string.IsNullOrWhiteSpace(claimantContact))
            {
                MessageBox.Show("Please provide the claimant's name and contact information.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Execute service layer logic
            if (_itemService.StaffSubmitClaim(_itemId, claimantName, claimantContact, claimNotes))
            {
                // Success: Signal DialogResult.OK to the calling form (ManageItems)
                MessageBox.Show($"Claim request submitted for Item ID {_itemId}. Status changed to 'Claim Pending' for admin review.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to submit the claim request due to a database error. Please check your service logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add any other methods/event handlers you need here (e.g., Cancel button)
    }
}