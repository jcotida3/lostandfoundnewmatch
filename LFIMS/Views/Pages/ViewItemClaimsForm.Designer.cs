// File: LFsystem.Views.Forms/ViewItemClaimsForm.Designer.cs

namespace LFsystem.Views.Forms
{
    partial class ViewItemClaimsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null; // KEEP THIS LINE (It's part of the standard template)

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblItemInfo = new System.Windows.Forms.Label();
            this.dgvItemClaims = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnApproveSelected = new Guna.UI2.WinForms.Guna2Button();
            this.btnRejectSelected = new Guna.UI2.WinForms.Guna2Button();
            // **REMOVED: this.components = new System.ComponentModel.Container();** // The components container is initialized in the first line of InitializeComponent() and is already declared above.

            ((System.ComponentModel.ISupportInitialize)(this.dgvItemClaims)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(325, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Claims Review Dashboard";
            // 
            // lblItemInfo
            // 
            this.lblItemInfo.AutoSize = true;
            this.lblItemInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemInfo.Location = new System.Drawing.Point(23, 65);
            this.lblItemInfo.Name = "lblItemInfo";
            this.lblItemInfo.Size = new System.Drawing.Size(309, 23);
            this.lblItemInfo.TabIndex = 1;
            this.lblItemInfo.Text = "Reviewing claims for: [Item Name/ID]";
            // 
            // dgvItemClaims
            // 
            this.dgvItemClaims.AllowUserToAddRows = false;
            this.dgvItemClaims.AllowUserToDeleteRows = false;
            this.dgvItemClaims.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvItemClaims.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemClaims.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItemClaims.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemClaims.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItemClaims.ColumnHeadersHeight = 40;
            this.dgvItemClaims.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemClaims.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItemClaims.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvItemClaims.Location = new System.Drawing.Point(27, 100);
            this.dgvItemClaims.Name = "dgvItemClaims";
            this.dgvItemClaims.ReadOnly = true;
            this.dgvItemClaims.RowHeadersVisible = false;
            this.dgvItemClaims.RowHeadersWidth = 51;
            this.dgvItemClaims.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemClaims.RowTemplate.Height = 100; // Match the code-behind setting
            this.dgvItemClaims.Size = new System.Drawing.Size(746, 350);
            this.dgvItemClaims.TabIndex = 2;
            this.dgvItemClaims.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvItemClaims.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvItemClaims.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvItemClaims.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvItemClaims.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvItemClaims.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvItemClaims.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvItemClaims.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvItemClaims.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvItemClaims.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemClaims.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvItemClaims.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvItemClaims.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvItemClaims.ThemeStyle.ReadOnly = true;
            this.dgvItemClaims.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvItemClaims.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvItemClaims.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemClaims.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvItemClaims.ThemeStyle.RowsStyle.Height = 100;
            this.dgvItemClaims.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvItemClaims.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnApproveSelected
            // 
            this.btnApproveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApproveSelected.AutoRoundedCorners = true;
            this.btnApproveSelected.BorderRadius = 21;
            this.btnApproveSelected.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApproveSelected.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnApproveSelected.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnApproveSelected.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnApproveSelected.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnApproveSelected.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproveSelected.ForeColor = System.Drawing.Color.White;
            this.btnApproveSelected.Location = new System.Drawing.Point(27, 470);
            this.btnApproveSelected.Name = "btnApproveSelected";
            this.btnApproveSelected.Size = new System.Drawing.Size(200, 45);
            this.btnApproveSelected.TabIndex = 3;
            this.btnApproveSelected.Text = "Approve Selected";
            // 
            // btnRejectSelected
            // 
            this.btnRejectSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRejectSelected.AutoRoundedCorners = true;
            this.btnRejectSelected.BorderRadius = 21;
            this.btnRejectSelected.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRejectSelected.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRejectSelected.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRejectSelected.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRejectSelected.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRejectSelected.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRejectSelected.ForeColor = System.Drawing.Color.White;
            this.btnRejectSelected.Location = new System.Drawing.Point(573, 470);
            this.btnRejectSelected.Name = "btnRejectSelected";
            this.btnRejectSelected.Size = new System.Drawing.Size(200, 45);
            this.btnRejectSelected.TabIndex = 4;
            this.btnRejectSelected.Text = "Reject Selected";
            // 
            // ViewItemClaimsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.btnRejectSelected);
            this.Controls.Add(this.btnApproveSelected);
            this.Controls.Add(this.dgvItemClaims);
            this.Controls.Add(this.lblItemInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewItemClaimsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Review Claims";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemClaims)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblItemInfo;
        private Guna.UI2.WinForms.Guna2DataGridView dgvItemClaims;
        private Guna.UI2.WinForms.Guna2Button btnRejectSelected;
        private Guna.UI2.WinForms.Guna2Button btnApproveSelected;
        // **REMOVED: private System.ComponentModel.IContainer components;** // This line was moved up to the standard location outside the region.
    }
}