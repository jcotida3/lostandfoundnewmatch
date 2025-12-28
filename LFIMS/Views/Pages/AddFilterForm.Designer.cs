using Guna.UI2.WinForms.Suite;

namespace LFsystem.Views.Pages
{
    partial class AddFilterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            CustomizableEdges customizableEdges1 = new CustomizableEdges();
            CustomizableEdges customizableEdges2 = new CustomizableEdges();
            lblName = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            txtName = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(37, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(262, 121);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 33);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(169, 121);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 33);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            // 
            // txtName
            // 
            txtName.BorderRadius = 15;
            txtName.CustomizableEdges = customizableEdges1;
            txtName.DefaultText = "";
            txtName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Font = new Font("Segoe UI", 9F);
            txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Location = new Point(37, 44);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "";
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtName.Size = new Size(300, 36);
            txtName.TabIndex = 4;
            // 
            // AddFilterForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(370, 166);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFilterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddItemForm";
            ResumeLayout(false);
            PerformLayout();
        }
        private Guna.UI2.WinForms.Guna2TextBox txtName;
    }
}
