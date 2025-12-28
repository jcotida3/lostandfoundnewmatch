using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LFsystem.Views.Components // Assuming you have a Components folder
{
    public partial class ClaimCard : UserControl
    {
        public ClaimCard()
        {
            InitializeComponent();
            // Wire up click events to the handlers
            btnApprove.Click += (s, e) => OnApproveClicked?.Invoke(this, EventArgs.Empty);
            btnReject.Click += (s, e) => OnRejectClicked?.Invoke(this, EventArgs.Empty);
            btnRespond.Click += (s, e) => OnRespondClicked?.Invoke(this, EventArgs.Empty);
        }

        // --- Properties to hold claim data ---
        public int ClaimId { get; set; }
        public int ItemId { get; set; }

        // --- Events for button clicks ---
        public event EventHandler OnApproveClicked;
        public event EventHandler OnRejectClicked;
        public event EventHandler OnRespondClicked;

        // --- Public properties to set label text from the main form ---
        [Category("Claim Data")]
        public string ClaimantName
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        [Category("Claim Data")]
        public string ClaimantContact
        {
            get => lblContact.Text;
            set => lblContact.Text = $"Contact: {value}";
        }

        [Category("Claim Data")]
        public string ClaimNotes
        {
            get => lblNotes.Text;
            set => lblNotes.Text = $"Notes: {value}";
        }

        [Category("Claim Data")]
        public DateTime ClaimDate
        {
            get => DateTime.Parse(lblDate.Text);
            set => lblDate.Text = value.ToString("yyyy-MM-dd HH:mm");
        }

        [Category("Claim Data")]
        public string Status
        {
            get => lblStatus.Text;
            set
            {
                lblStatus.Text = $"Status: {value}";
                // Change color based on status
                switch (value)
                {
                    case "Approved":
                        pnlStatus.FillColor = Color.MediumSeaGreen;
                        break;
                    case "Rejected":
                        pnlStatus.FillColor = Color.Crimson;
                        break;
                    default: // Pending
                        pnlStatus.FillColor = Color.RoyalBlue;
                        break;
                }
            }
        }
    }
}
