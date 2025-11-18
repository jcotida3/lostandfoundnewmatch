namespace LFsystem.Views.Pages
{
    partial class ViewItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewItemForm));
            lblItemName = new Label();
            lblSubtitle = new Label();
            lblPhoto = new Label();
            picBox = new PictureBox();
            headDesc = new Label();
            lblDescription = new Label();
            headLocation = new Label();
            headDept = new Label();
            headReportBy = new Label();
            lblLocation = new Label();
            lblDepartment = new Label();
            lblReportedBy = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnlFinder = new Panel();
            lblReporterContact = new Label();
            lblReporterName = new Label();
            lblFinderInformation = new Label();
            pnlTimeline = new Panel();
            lblUpdatedDate = new Label();
            headUpdated = new Label();
            lblCreatedDate = new Label();
            headCreated = new Label();
            Timeline = new Label();
            statusChip = new Label();
            statusEllipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            lblItemType = new Label();
            typeElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            flwNameType = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            pnlFinder.SuspendLayout();
            pnlTimeline.SuspendLayout();
            flwNameType.SuspendLayout();
            SuspendLayout();
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItemName.Location = new Point(3, 0);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(97, 25);
            lblItemName.TabIndex = 1;
            lblItemName.Text = "Iphone 12";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.Location = new Point(26, 53);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(49, 20);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "- Item";
            // 
            // lblPhoto
            // 
            lblPhoto.AutoSize = true;
            lblPhoto.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhoto.Location = new Point(50, 96);
            lblPhoto.Name = "lblPhoto";
            lblPhoto.Size = new Size(99, 23);
            lblPhoto.TabIndex = 3;
            lblPhoto.Text = "Item Photo";
            // 
            // picBox
            // 
            picBox.BorderStyle = BorderStyle.FixedSingle;
            picBox.Location = new Point(12, 122);
            picBox.Name = "picBox";
            picBox.Size = new Size(466, 209);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.TabIndex = 4;
            picBox.TabStop = false;
            // 
            // headDesc
            // 
            headDesc.AutoSize = true;
            headDesc.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headDesc.Location = new Point(15, 342);
            headDesc.Name = "headDesc";
            headDesc.Size = new Size(102, 23);
            headDesc.TabIndex = 5;
            headDesc.Text = "Description";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(12, 365);
            lblDescription.MaximumSize = new Size(260, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(94, 20);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Found - Item";
            // 
            // headLocation
            // 
            headLocation.AutoSize = true;
            headLocation.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headLocation.Location = new Point(269, 342);
            headLocation.Name = "headLocation";
            headLocation.Size = new Size(78, 23);
            headLocation.TabIndex = 7;
            headLocation.Text = "Location";
            // 
            // headDept
            // 
            headDept.AutoSize = true;
            headDept.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headDept.Location = new Point(15, 416);
            headDept.Name = "headDept";
            headDept.Size = new Size(108, 23);
            headDept.TabIndex = 8;
            headDept.Text = "Department";
            // 
            // headReportBy
            // 
            headReportBy.AutoSize = true;
            headReportBy.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headReportBy.Location = new Point(269, 416);
            headReportBy.Name = "headReportBy";
            headReportBy.Size = new Size(110, 23);
            headReportBy.TabIndex = 9;
            headReportBy.Text = "Reported By";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLocation.Location = new Point(271, 365);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(94, 20);
            lblLocation.TabIndex = 10;
            lblLocation.Text = "Found - Item";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDepartment.Location = new Point(18, 439);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(94, 20);
            lblDepartment.TabIndex = 11;
            lblDepartment.Text = "Found - Item";
            // 
            // lblReportedBy
            // 
            lblReportedBy.AutoSize = true;
            lblReportedBy.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReportedBy.Location = new Point(271, 439);
            lblReportedBy.Name = "lblReportedBy";
            lblReportedBy.Size = new Size(94, 20);
            lblReportedBy.TabIndex = 12;
            lblReportedBy.Text = "Found - Item";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(pnlFinder);
            flowLayoutPanel1.Controls.Add(pnlTimeline);
            flowLayoutPanel1.Location = new Point(12, 484);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(270, 307);
            flowLayoutPanel1.TabIndex = 13;
            // 
            // pnlFinder
            // 
            pnlFinder.Controls.Add(lblReporterContact);
            pnlFinder.Controls.Add(lblReporterName);
            pnlFinder.Controls.Add(lblFinderInformation);
            pnlFinder.Location = new Point(3, 3);
            pnlFinder.Name = "pnlFinder";
            pnlFinder.Size = new Size(242, 78);
            pnlFinder.TabIndex = 14;
            // 
            // lblReporterContact
            // 
            lblReporterContact.AutoSize = true;
            lblReporterContact.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReporterContact.Location = new Point(5, 53);
            lblReporterContact.Name = "lblReporterContact";
            lblReporterContact.Size = new Size(94, 20);
            lblReporterContact.TabIndex = 15;
            lblReporterContact.Text = "Found - Item";
            // 
            // lblReporterName
            // 
            lblReporterName.AutoSize = true;
            lblReporterName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReporterName.Location = new Point(5, 33);
            lblReporterName.Name = "lblReporterName";
            lblReporterName.Size = new Size(94, 20);
            lblReporterName.TabIndex = 14;
            lblReporterName.Text = "Found - Item";
            // 
            // lblFinderInformation
            // 
            lblFinderInformation.AutoSize = true;
            lblFinderInformation.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFinderInformation.Location = new Point(3, 10);
            lblFinderInformation.Name = "lblFinderInformation";
            lblFinderInformation.Size = new Size(157, 23);
            lblFinderInformation.TabIndex = 14;
            lblFinderInformation.Text = "FinderInformation";
            // 
            // pnlTimeline
            // 
            pnlTimeline.Controls.Add(lblUpdatedDate);
            pnlTimeline.Controls.Add(headUpdated);
            pnlTimeline.Controls.Add(lblCreatedDate);
            pnlTimeline.Controls.Add(headCreated);
            pnlTimeline.Controls.Add(Timeline);
            pnlTimeline.Location = new Point(3, 87);
            pnlTimeline.Name = "pnlTimeline";
            pnlTimeline.Size = new Size(242, 187);
            pnlTimeline.TabIndex = 16;
            // 
            // lblUpdatedDate
            // 
            lblUpdatedDate.AutoSize = true;
            lblUpdatedDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUpdatedDate.Location = new Point(5, 111);
            lblUpdatedDate.MaximumSize = new Size(120, 0);
            lblUpdatedDate.Name = "lblUpdatedDate";
            lblUpdatedDate.Size = new Size(113, 40);
            lblUpdatedDate.TabIndex = 18;
            lblUpdatedDate.Text = "January 4 2025, 4:30 PM";
            // 
            // headUpdated
            // 
            headUpdated.AutoSize = true;
            headUpdated.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headUpdated.ForeColor = Color.FromArgb(128, 128, 255);
            headUpdated.Location = new Point(5, 91);
            headUpdated.Name = "headUpdated";
            headUpdated.Size = new Size(69, 20);
            headUpdated.TabIndex = 16;
            headUpdated.Text = "Updated";
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreatedDate.Location = new Point(3, 43);
            lblCreatedDate.MaximumSize = new Size(120, 0);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(113, 40);
            lblCreatedDate.TabIndex = 15;
            lblCreatedDate.Text = "January 4 2025, 4:30 PM";
            // 
            // headCreated
            // 
            headCreated.AutoSize = true;
            headCreated.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headCreated.ForeColor = Color.FromArgb(0, 192, 0);
            headCreated.Location = new Point(5, 23);
            headCreated.Name = "headCreated";
            headCreated.Size = new Size(63, 20);
            headCreated.TabIndex = 14;
            headCreated.Text = "Created";
            // 
            // Timeline
            // 
            Timeline.AutoSize = true;
            Timeline.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Timeline.Location = new Point(5, 0);
            Timeline.Name = "Timeline";
            Timeline.Size = new Size(79, 23);
            Timeline.TabIndex = 14;
            Timeline.Text = "Timeline";
            // 
            // statusChip
            // 
            statusChip.AutoSize = true;
            statusChip.BackColor = Color.FromArgb(198, 239, 206);
            statusChip.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            statusChip.ForeColor = Color.FromArgb(0, 97, 0);
            statusChip.Location = new Point(372, 21);
            statusChip.Name = "statusChip";
            statusChip.Padding = new Padding(3, 1, 3, 1);
            statusChip.Size = new Size(81, 22);
            statusChip.TabIndex = 14;
            statusChip.Text = "approved";
            // 
            // statusEllipse
            // 
            statusEllipse.TargetControl = statusChip;
            // 
            // lblItemType
            // 
            lblItemType.Anchor = AnchorStyles.Left;
            lblItemType.AutoSize = true;
            lblItemType.BackColor = Color.Red;
            lblItemType.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItemType.ForeColor = Color.White;
            lblItemType.Location = new Point(106, 1);
            lblItemType.Name = "lblItemType";
            lblItemType.Padding = new Padding(3, 1, 3, 1);
            lblItemType.Size = new Size(41, 22);
            lblItemType.TabIndex = 15;
            lblItemType.Text = "lost";
            // 
            // typeElipse
            // 
            typeElipse.BorderRadius = 10;
            typeElipse.TargetControl = lblItemType;
            // 
            // flwNameType
            // 
            flwNameType.Controls.Add(lblItemName);
            flwNameType.Controls.Add(lblItemType);
            flwNameType.Location = new Point(23, 21);
            flwNameType.Name = "flwNameType";
            flwNameType.Size = new Size(250, 29);
            flwNameType.TabIndex = 16;
            // 
            // ViewItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(490, 803);
            Controls.Add(flwNameType);
            Controls.Add(statusChip);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblReportedBy);
            Controls.Add(lblDepartment);
            Controls.Add(lblLocation);
            Controls.Add(headReportBy);
            Controls.Add(headDept);
            Controls.Add(headLocation);
            Controls.Add(lblDescription);
            Controls.Add(headDesc);
            Controls.Add(picBox);
            Controls.Add(lblPhoto);
            Controls.Add(lblSubtitle);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ViewItemForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewItemForm";
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            pnlFinder.ResumeLayout(false);
            pnlFinder.PerformLayout();
            pnlTimeline.ResumeLayout(false);
            pnlTimeline.PerformLayout();
            flwNameType.ResumeLayout(false);
            flwNameType.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblItemName;
        private Label lblSubtitle;
        private Label lblPhoto;
        private PictureBox picBox;
        private Label headDesc;
        private Label lblDescription;
        private Label headLocation;
        private Label headDept;
        private Label headReportBy;
        private Label lblLocation;
        private Label lblDepartment;
        private Label lblReportedBy;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pnlFinder;
        private Label lblReporterContact;
        private Label lblReporterName;
        private Label lblFinderInformation;
        private Panel pnlTimeline;
        private Label lblUpdatedDate;
        private Label headUpdated;
        private Label lblCreatedDate;
        private Label headCreated;
        private Label Timeline;
        private Label statusChip;
        private Guna.UI2.WinForms.Guna2Elipse statusEllipse;
        private Label lblItemType;
        private Guna.UI2.WinForms.Guna2Elipse typeElipse;
        private FlowLayoutPanel flwNameType;
    }
}