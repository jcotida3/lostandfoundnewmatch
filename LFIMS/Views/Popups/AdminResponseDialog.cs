using Guna.UI2.WinForms;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Windows.Forms;

namespace LFsystem.Views.Pages
{
    public partial class AdminRespondDialog : Form
    {
        public string ResponseNotes => txtRespondNotes.Text.Trim();
        public string ChosenStatus => cmbStatus.SelectedItem?.ToString() ?? "";

        public AdminRespondDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
