namespace LFsystem.Views.Pages
{
    partial class MatchItems
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblItemMatchSub = new Label();
            lblItemMatch = new Label();
            dgvMatches = new Guna.UI2.WinForms.Guna2DataGridView();
            colLostId = new DataGridViewTextBoxColumn();
            colFoundId = new DataGridViewTextBoxColumn();
            colLostTitle = new DataGridViewTextBoxColumn();
            colFoundTitle = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colLocation = new DataGridViewTextBoxColumn();
            colScore = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvMatches).BeginInit();
            SuspendLayout();
            // 
            // lblItemMatchSub
            // 
            lblItemMatchSub.AutoSize = true;
            lblItemMatchSub.Font = new Font("Segoe UI", 10.8F);
            lblItemMatchSub.ForeColor = Color.Gray;
            lblItemMatchSub.Location = new Point(28, 73);
            lblItemMatchSub.Name = "lblItemMatchSub";
            lblItemMatchSub.Size = new Size(431, 25);
            lblItemMatchSub.TabIndex = 3;
            lblItemMatchSub.Text = "\"Suggested matches between Lost and Found items\"";
            // 
            // lblItemMatch
            // 
            lblItemMatch.AutoSize = true;
            lblItemMatch.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblItemMatch.ForeColor = SystemColors.HotTrack;
            lblItemMatch.Location = new Point(28, 23);
            lblItemMatch.Name = "lblItemMatch";
            lblItemMatch.Size = new Size(360, 41);
            lblItemMatch.TabIndex = 2;
            lblItemMatch.Text = "Item Match Suggestions";
            // 
            // dgvMatches
            // 
            dgvMatches.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvMatches.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvMatches.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMatches.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMatches.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMatches.ColumnHeadersHeight = 50;
            dgvMatches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvMatches.Columns.AddRange(new DataGridViewColumn[] { colLostId, colFoundId, colLostTitle, colFoundTitle, colCategory, colLocation, colScore, colAction });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvMatches.DefaultCellStyle = dataGridViewCellStyle3;
            dgvMatches.GridColor = Color.FromArgb(231, 229, 255);
            dgvMatches.Location = new Point(28, 125);
            dgvMatches.MultiSelect = false;
            dgvMatches.Name = "dgvMatches";
            dgvMatches.ReadOnly = true;
            dgvMatches.RowHeadersVisible = false;
            dgvMatches.RowHeadersWidth = 51;
            dgvMatches.RowTemplate.Height = 60;
            dgvMatches.Size = new Size(1087, 250);
            dgvMatches.TabIndex = 6;
            dgvMatches.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvMatches.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvMatches.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvMatches.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvMatches.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvMatches.ThemeStyle.BackColor = Color.White;
            dgvMatches.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvMatches.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvMatches.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMatches.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvMatches.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvMatches.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvMatches.ThemeStyle.HeaderStyle.Height = 50;
            dgvMatches.ThemeStyle.ReadOnly = true;
            dgvMatches.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvMatches.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMatches.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvMatches.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvMatches.ThemeStyle.RowsStyle.Height = 60;
            dgvMatches.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvMatches.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvMatches.CellContentClick += dgvMatches_CellContentClick;
            // 
            // colLostId
            // 
            colLostId.HeaderText = "Lost ID";
            colLostId.MinimumWidth = 6;
            colLostId.Name = "colLostId";
            colLostId.ReadOnly = true;
            colLostId.Visible = false;
            // 
            // colFoundId
            // 
            colFoundId.HeaderText = "Found ID";
            colFoundId.MinimumWidth = 6;
            colFoundId.Name = "colFoundId";
            colFoundId.ReadOnly = true;
            colFoundId.Visible = false;
            // 
            // colLostTitle
            // 
            colLostTitle.HeaderText = "Lost Item";
            colLostTitle.MinimumWidth = 6;
            colLostTitle.Name = "colLostTitle";
            colLostTitle.ReadOnly = true;
            // 
            // colFoundTitle
            // 
            colFoundTitle.HeaderText = "Found Item";
            colFoundTitle.MinimumWidth = 6;
            colFoundTitle.Name = "colFoundTitle";
            colFoundTitle.ReadOnly = true;
            // 
            // colCategory
            // 
            colCategory.HeaderText = "Category";
            colCategory.MinimumWidth = 6;
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            // 
            // colLocation
            // 
            colLocation.HeaderText = "Location";
            colLocation.MinimumWidth = 6;
            colLocation.Name = "colLocation";
            colLocation.ReadOnly = true;
            // 
            // colScore
            // 
            colScore.HeaderText = "Match Score";
            colScore.MinimumWidth = 6;
            colScore.Name = "colScore";
            colScore.ReadOnly = true;
            // 
            // colAction
            // 
            colAction.HeaderText = "Action";
            colAction.MinimumWidth = 6;
            colAction.Name = "colAction";
            colAction.ReadOnly = true;
            colAction.Text = "Match";
            // 
            // MatchItems
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvMatches);
            Controls.Add(lblItemMatchSub);
            Controls.Add(lblItemMatch);
            Name = "MatchItems";
            Size = new Size(1192, 716);
            ((System.ComponentModel.ISupportInitialize)dgvMatches).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblItemMatchSub;
        private Label lblItemMatch;
        private Guna.UI2.WinForms.Guna2DataGridView dgvMatches;
        private DataGridViewTextBoxColumn colLostId;
        private DataGridViewTextBoxColumn colFoundId;
        private DataGridViewTextBoxColumn colLostTitle;
        private DataGridViewTextBoxColumn colFoundTitle;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn colScore;
        private DataGridViewButtonColumn colAction;
    }
}
