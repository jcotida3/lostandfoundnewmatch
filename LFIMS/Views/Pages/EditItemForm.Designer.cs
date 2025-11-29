// EditItemForm.Designer.cs
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace LFsystem.Views.Pages
{
    partial class EditItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
        /// Required method for Designer support — do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            mainPanel = new Panel();
            lblStatus = new Label();
            cmbStatus = new Guna2ComboBox();
            btnReplace = new Guna2Button();
            btnSave = new Guna2Button();
            btnCancel = new Guna2Button();
            picBox = new PictureBox();
            pictureBox1 = new PictureBox();
            lblItemPhoto = new Label();
            cmbDepartment = new Guna2ComboBox();
            cmbLocation = new Guna2ComboBox();
            lblDepartment = new Label();
            lblLocation = new Label();
            itemDescription = new Guna2TextBox();
            lblDescription = new Label();
            cmbCategory = new Guna2ComboBox();
            lblCategory = new Label();
            itemName = new Guna2TextBox();
            lblItemName = new Label();
            rbFound = new RadioButton();
            rbLost = new RadioButton();
            lblItemType = new Label();
            lblEditSub = new Label();
            lblEdit = new Label();
            pnlFinderInformation = new Guna2Panel();
            lblFinderInformation = new Label();
            lblFindName = new Label();
            txtFindName = new Guna2TextBox();
            lblFindContact = new Label();
            txtFindContact = new Guna2TextBox();
            mainPanel.SuspendLayout();
            ((ISupportInitialize)picBox).BeginInit();
            ((ISupportInitialize)pictureBox1).BeginInit();
            pnlFinderInformation.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(pnlFinderInformation);
            mainPanel.Controls.Add(lblStatus);
            mainPanel.Controls.Add(btnReplace);
            mainPanel.Controls.Add(cmbStatus);
            mainPanel.Controls.Add(btnSave);
            mainPanel.Controls.Add(btnCancel);
            mainPanel.Controls.Add(picBox);
            mainPanel.Controls.Add(pictureBox1);
            mainPanel.Controls.Add(lblItemPhoto);
            mainPanel.Controls.Add(cmbDepartment);
            mainPanel.Controls.Add(cmbLocation);
            mainPanel.Controls.Add(lblDepartment);
            mainPanel.Controls.Add(lblLocation);
            mainPanel.Controls.Add(itemDescription);
            mainPanel.Controls.Add(lblDescription);
            mainPanel.Controls.Add(cmbCategory);
            mainPanel.Controls.Add(lblCategory);
            mainPanel.Controls.Add(itemName);
            mainPanel.Controls.Add(lblItemName);
            mainPanel.Controls.Add(rbFound);
            mainPanel.Controls.Add(rbLost);
            mainPanel.Controls.Add(lblItemType);
            mainPanel.Controls.Add(lblEditSub);
            mainPanel.Controls.Add(lblEdit);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(490, 803);
            mainPanel.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(246, 686);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 17);
            lblStatus.TabIndex = 30;
            lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.AutoRoundedCorners = true;
            cmbStatus.BackColor = Color.Transparent;
            cmbStatus.CustomizableEdges = customizableEdges9;
            cmbStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbStatus.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.ForeColor = Color.FromArgb(68, 88, 112);
            cmbStatus.ItemHeight = 25;
            cmbStatus.Location = new Point(302, 679);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cmbStatus.Size = new Size(175, 31);
            cmbStatus.TabIndex = 31;
            // 
            // btnReplace
            // 
            btnReplace.BorderColor = Color.DarkGray;
            btnReplace.BorderRadius = 5;
            btnReplace.BorderThickness = 1;
            btnReplace.CustomizableEdges = customizableEdges7;
            btnReplace.DisabledState.BorderColor = Color.DarkGray;
            btnReplace.DisabledState.CustomBorderColor = Color.DarkGray;
            btnReplace.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnReplace.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnReplace.FillColor = Color.White;
            btnReplace.Font = new Font("Segoe UI", 9F);
            btnReplace.ForeColor = Color.Black;
            btnReplace.Location = new Point(165, 524);
            btnReplace.Margin = new Padding(3, 4, 3, 4);
            btnReplace.Name = "btnReplace";
            btnReplace.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnReplace.Size = new Size(154, 30);
            btnReplace.TabIndex = 29;
            btnReplace.Text = "Replace Item";
            btnReplace.Click += btnReplace_Click;
            // 
            // btnSave
            // 
            btnSave.BorderRadius = 5;
            btnSave.CustomizableEdges = customizableEdges11;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.FromArgb(16, 76, 136);
            btnSave.Font = new Font("Segoe UI", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(359, 754);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSave.Size = new Size(120, 30);
            btnSave.TabIndex = 28;
            btnSave.Text = "Update Item";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BorderColor = Color.DarkGray;
            btnCancel.BorderRadius = 5;
            btnCancel.BorderThickness = 1;
            btnCancel.CustomizableEdges = customizableEdges13;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.White;
            btnCancel.Font = new Font("Segoe UI", 9F);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(233, 754);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnCancel.Size = new Size(120, 30);
            btnCancel.TabIndex = 27;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // picBox
            // 
            picBox.BorderStyle = BorderStyle.FixedSingle;
            picBox.Location = new Point(11, 357);
            picBox.Margin = new Padding(3, 4, 3, 4);
            picBox.Name = "picBox";
            picBox.Size = new Size(466, 159);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.TabIndex = 24;
            picBox.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.upload_icon;
            pictureBox1.Location = new Point(11, 328);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // lblItemPhoto
            // 
            lblItemPhoto.AutoSize = true;
            lblItemPhoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItemPhoto.Location = new Point(35, 328);
            lblItemPhoto.Name = "lblItemPhoto";
            lblItemPhoto.Size = new Size(88, 20);
            lblItemPhoto.TabIndex = 22;
            lblItemPhoto.Text = "Item Photo";
            // 
            // cmbDepartment
            // 
            cmbDepartment.BackColor = Color.Transparent;
            cmbDepartment.BorderRadius = 5;
            cmbDepartment.CustomizableEdges = customizableEdges15;
            cmbDepartment.DrawMode = DrawMode.OwnerDrawFixed;
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FillColor = Color.WhiteSmoke;
            cmbDepartment.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbDepartment.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbDepartment.Font = new Font("Segoe UI", 10F);
            cmbDepartment.ForeColor = Color.FromArgb(68, 88, 112);
            cmbDepartment.IntegralHeight = false;
            cmbDepartment.ItemHeight = 24;
            cmbDepartment.Location = new Point(256, 291);
            cmbDepartment.Margin = new Padding(3, 4, 3, 4);
            cmbDepartment.MaxDropDownItems = 5;
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.ShadowDecoration.CustomizableEdges = customizableEdges16;
            cmbDepartment.Size = new Size(205, 30);
            cmbDepartment.TabIndex = 14;
            // 
            // cmbLocation
            // 
            cmbLocation.BackColor = Color.Transparent;
            cmbLocation.BorderRadius = 5;
            cmbLocation.CustomizableEdges = customizableEdges17;
            cmbLocation.DrawMode = DrawMode.OwnerDrawFixed;
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocation.FillColor = Color.WhiteSmoke;
            cmbLocation.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbLocation.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbLocation.Font = new Font("Segoe UI", 10F);
            cmbLocation.ForeColor = Color.FromArgb(68, 88, 112);
            cmbLocation.ItemHeight = 24;
            cmbLocation.Location = new Point(9, 291);
            cmbLocation.Margin = new Padding(3, 4, 3, 4);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.ShadowDecoration.CustomizableEdges = customizableEdges18;
            cmbLocation.Size = new Size(205, 30);
            cmbLocation.TabIndex = 13;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartment.Location = new Point(253, 266);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(82, 17);
            lblDepartment.TabIndex = 12;
            lblDepartment.Text = "Department";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLocation.Location = new Point(10, 266);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(61, 17);
            lblLocation.TabIndex = 11;
            lblLocation.Text = "Location";
            // 
            // itemDescription
            // 
            itemDescription.BorderRadius = 5;
            itemDescription.Cursor = Cursors.IBeam;
            itemDescription.CustomizableEdges = customizableEdges19;
            itemDescription.DefaultText = "";
            itemDescription.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            itemDescription.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            itemDescription.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            itemDescription.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            itemDescription.FillColor = Color.WhiteSmoke;
            itemDescription.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            itemDescription.Font = new Font("Segoe UI", 9F);
            itemDescription.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            itemDescription.Location = new Point(11, 206);
            itemDescription.Margin = new Padding(3, 5, 3, 5);
            itemDescription.Name = "itemDescription";
            itemDescription.PlaceholderText = "";
            itemDescription.SelectedText = "";
            itemDescription.ShadowDecoration.CustomizableEdges = customizableEdges20;
            itemDescription.Size = new Size(452, 55);
            itemDescription.TabIndex = 10;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(12, 179);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(79, 17);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Description";
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.Transparent;
            cmbCategory.BorderRadius = 5;
            cmbCategory.CustomizableEdges = customizableEdges21;
            cmbCategory.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FillColor = Color.WhiteSmoke;
            cmbCategory.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbCategory.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.ForeColor = Color.FromArgb(68, 88, 112);
            cmbCategory.IntegralHeight = false;
            cmbCategory.ItemHeight = 24;
            cmbCategory.Location = new Point(258, 134);
            cmbCategory.Margin = new Padding(3, 4, 3, 4);
            cmbCategory.MaxDropDownItems = 5;
            cmbCategory.Name = "cmbCategory";
            cmbCategory.ShadowDecoration.CustomizableEdges = customizableEdges22;
            cmbCategory.Size = new Size(205, 30);
            cmbCategory.TabIndex = 8;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategory.Location = new Point(255, 113);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(64, 17);
            lblCategory.TabIndex = 7;
            lblCategory.Text = "Category";
            // 
            // itemName
            // 
            itemName.BorderRadius = 5;
            itemName.Cursor = Cursors.IBeam;
            itemName.CustomizableEdges = customizableEdges23;
            itemName.DefaultText = "";
            itemName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            itemName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            itemName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            itemName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            itemName.FillColor = Color.WhiteSmoke;
            itemName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            itemName.Font = new Font("Segoe UI", 9F);
            itemName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            itemName.Location = new Point(11, 134);
            itemName.Margin = new Padding(3, 5, 3, 5);
            itemName.Name = "itemName";
            itemName.PlaceholderForeColor = Color.Black;
            itemName.PlaceholderText = "iPhone 12";
            itemName.SelectedText = "";
            itemName.ShadowDecoration.CustomizableEdges = customizableEdges24;
            itemName.Size = new Size(205, 30);
            itemName.TabIndex = 6;
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItemName.Location = new Point(12, 113);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(76, 17);
            lblItemName.TabIndex = 5;
            lblItemName.Text = "Item Name";
            // 
            // rbFound
            // 
            rbFound.AutoSize = true;
            rbFound.Location = new Point(110, 79);
            rbFound.Margin = new Padding(3, 4, 3, 4);
            rbFound.Name = "rbFound";
            rbFound.Size = new Size(105, 24);
            rbFound.TabIndex = 4;
            rbFound.TabStop = true;
            rbFound.Text = "Found Item";
            rbFound.UseVisualStyleBackColor = true;
            rbFound.CheckedChanged += rbType_CheckedChanged;
            // 
            // rbLost
            // 
            rbLost.AutoSize = true;
            rbLost.Location = new Point(12, 79);
            rbLost.Margin = new Padding(3, 4, 3, 4);
            rbLost.Name = "rbLost";
            rbLost.Size = new Size(91, 24);
            rbLost.TabIndex = 3;
            rbLost.TabStop = true;
            rbLost.Text = "Lost Item";
            rbLost.UseVisualStyleBackColor = true;
            rbLost.CheckedChanged += rbType_CheckedChanged;
            // 
            // lblItemType
            // 
            lblItemType.AutoSize = true;
            lblItemType.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItemType.Location = new Point(13, 54);
            lblItemType.Name = "lblItemType";
            lblItemType.Size = new Size(69, 17);
            lblItemType.TabIndex = 2;
            lblItemType.Text = "Item Type";
            // 
            // lblEditSub
            // 
            lblEditSub.AutoSize = true;
            lblEditSub.Location = new Point(12, 25);
            lblEditSub.Name = "lblEditSub";
            lblEditSub.Size = new Size(222, 20);
            lblEditSub.TabIndex = 1;
            lblEditSub.Text = "Update Item information details";
            // 
            // lblEdit
            // 
            lblEdit.AutoSize = true;
            lblEdit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEdit.Location = new Point(11, 2);
            lblEdit.Name = "lblEdit";
            lblEdit.Size = new Size(84, 23);
            lblEdit.TabIndex = 0;
            lblEdit.Text = "Edit Item";
            // 
            // pnlFinderInformation
            // 
            pnlFinderInformation.BackColor = Color.FromArgb(239, 247, 255);
            pnlFinderInformation.BorderRadius = 10;
            pnlFinderInformation.BorderThickness = 1;
            pnlFinderInformation.Controls.Add(txtFindContact);
            pnlFinderInformation.Controls.Add(lblFindContact);
            pnlFinderInformation.Controls.Add(txtFindName);
            pnlFinderInformation.Controls.Add(lblFindName);
            pnlFinderInformation.Controls.Add(lblFinderInformation);
            pnlFinderInformation.CustomizableEdges = customizableEdges5;
            pnlFinderInformation.FillColor = Color.FromArgb(239, 247, 255);
            pnlFinderInformation.Location = new Point(13, 562);
            pnlFinderInformation.Margin = new Padding(3, 4, 3, 4);
            pnlFinderInformation.Name = "pnlFinderInformation";
            pnlFinderInformation.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlFinderInformation.Size = new Size(466, 105);
            pnlFinderInformation.TabIndex = 26;
            // 
            // lblFinderInformation
            // 
            lblFinderInformation.AutoSize = true;
            lblFinderInformation.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFinderInformation.ForeColor = Color.FromArgb(16, 76, 136);
            lblFinderInformation.Location = new Point(7, 2);
            lblFinderInformation.Name = "lblFinderInformation";
            lblFinderInformation.Size = new Size(125, 17);
            lblFinderInformation.TabIndex = 27;
            lblFinderInformation.Text = "Finder Information";
            // 
            // lblFindName
            // 
            lblFindName.AutoSize = true;
            lblFindName.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFindName.Location = new Point(7, 34);
            lblFindName.Name = "lblFindName";
            lblFindName.Size = new Size(87, 17);
            lblFindName.TabIndex = 28;
            lblFindName.Text = "Finder Name";
            // 
            // txtFindName
            // 
            txtFindName.BorderRadius = 5;
            txtFindName.Cursor = Cursors.IBeam;
            txtFindName.CustomizableEdges = customizableEdges3;
            txtFindName.DefaultText = "";
            txtFindName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFindName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFindName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFindName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFindName.FillColor = Color.WhiteSmoke;
            txtFindName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFindName.Font = new Font("Segoe UI", 9F);
            txtFindName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFindName.Location = new Point(10, 60);
            txtFindName.Margin = new Padding(3, 5, 3, 5);
            txtFindName.Name = "txtFindName";
            txtFindName.PlaceholderForeColor = Color.Black;
            txtFindName.PlaceholderText = "";
            txtFindName.SelectedText = "";
            txtFindName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtFindName.Size = new Size(203, 30);
            txtFindName.TabIndex = 29;
            // 
            // lblFindContact
            // 
            lblFindContact.AutoSize = true;
            lblFindContact.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFindContact.Location = new Point(242, 34);
            lblFindContact.Name = "lblFindContact";
            lblFindContact.Size = new Size(98, 17);
            lblFindContact.TabIndex = 30;
            lblFindContact.Text = "Finder Contact";
            // 
            // txtFindContact
            // 
            txtFindContact.BorderRadius = 5;
            txtFindContact.Cursor = Cursors.IBeam;
            txtFindContact.CustomizableEdges = customizableEdges1;
            txtFindContact.DefaultText = "";
            txtFindContact.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFindContact.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFindContact.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFindContact.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFindContact.FillColor = Color.WhiteSmoke;
            txtFindContact.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFindContact.Font = new Font("Segoe UI", 9F);
            txtFindContact.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFindContact.Location = new Point(245, 60);
            txtFindContact.Margin = new Padding(3, 5, 3, 5);
            txtFindContact.Name = "txtFindContact";
            txtFindContact.PlaceholderForeColor = Color.Black;
            txtFindContact.PlaceholderText = "";
            txtFindContact.SelectedText = "";
            txtFindContact.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtFindContact.Size = new Size(203, 30);
            txtFindContact.TabIndex = 31;
            // 
            // EditItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(490, 803);
            Controls.Add(mainPanel);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditItemForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((ISupportInitialize)picBox).EndInit();
            ((ISupportInitialize)pictureBox1).EndInit();
            pnlFinderInformation.ResumeLayout(false);
            pnlFinderInformation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Label lblEdit;
        private Label lblItemType;
        private Label lblEditSub;
        private RadioButton rbFound;
        private RadioButton rbLost;
        private Label lblItemName;
        private Guna2TextBox itemName;
        private Label lblCategory;
        private Guna2ComboBox cmbCategory;
        private Label lblDescription;
        private Guna2TextBox itemDescription;
        private Guna2ComboBox cmbDepartment;
        private Guna2ComboBox cmbLocation;
        private Label lblDepartment;
        private PictureBox picBox;
        private PictureBox pictureBox1;
        private Label lblItemPhoto;
        private Label lblLocation;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        private Guna2Button btnReplace;
        private Label lblStatus;
        private Guna2ComboBox cmbStatus;
        private Guna2Panel pnlFinderInformation;
        private Guna2TextBox txtFindContact;
        private Label lblFindContact;
        private Guna2TextBox txtFindName;
        private Label lblFindName;
        private Label lblFinderInformation;
    }
}
