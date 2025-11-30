using Guna.UI2.WinForms;
using LFsystem.Helpers;
using LFsystem.Services;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;

namespace LFsystem.Views.Pages
{
    public partial class ManageItems : UserControl
    {
        #region Fields
        private int currentPage = 1;
        private int pageSize = 10; // items per page
        private int totalRecords = 0;
        private int totalPages = 0;
        private string typeFilter = "";
        private readonly Font titleFont = new Font("Segoe UI", 10, FontStyle.Bold);
        private readonly Font descFont = new Font("Segoe UI", 9, FontStyle.Regular);
        private readonly Font statusFont = new Font("Segoe UI", 9, FontStyle.Bold);

        private readonly System.Windows.Forms.Timer searchTimer;
        #endregion

        #region Constructor
        public ManageItems()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadFilters();

            // Event handlers
            btnPreviousPage.Click += BtnPreviousPage_Click;
            btnNextPage.Click += BtnNextPage_Click;
            cmbStatus.SelectedIndexChanged += Filters_Changed;
            cmbCategory.SelectedIndexChanged += Filters_Changed;
            cmbLocation.SelectedIndexChanged += Filters_Changed;
            cmbDepartment.SelectedIndexChanged += Filters_Changed;
            searchBox.TextChanged += TxtSearch_TextChanged;
            btnClearFilter.Click += BtnClearFilter_Click;
            tblItems.CellFormatting += TblItems_CellFormatting;
            tblItems.CellMouseClick += TblItems_CellMouseClick;
            

            // Initialize search debounce timer
            searchTimer = new System.Windows.Forms.Timer { Interval = 300 };
            searchTimer.Tick += (s, e) => { searchTimer.Stop(); LoadItems(); };

            LoadItems();
        }
        #endregion

        #region DataGridView Setup
        private void SetupDataGridView()
        {
            tblItems.AutoGenerateColumns = false;
            tblItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tblItems.ReadOnly = true;
            tblItems.AllowUserToResizeRows = false;
            tblItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tblItems.RowTemplate.Height = 80;
            tblItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            tblItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            if (tblItems.Columns.Contains("colItem"))
                tblItems.Columns["colItem"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            tblItems.CellPainting += TblItems_CellPainting;
        }

        private void TblItems_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = tblItems.Rows[e.RowIndex];

            if (e.ColumnIndex == tblItems.Columns["colItem"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                var tag = row.Cells[e.ColumnIndex].Tag as object[];
                Image img = tag?[0] as Image ?? Properties.Resources.default_item;
                string description = tag?[1]?.ToString() ?? "";
                string title = row.Cells[e.ColumnIndex].Value?.ToString() ?? "";

                if (img != null)
                    e.Graphics.DrawImage(img, new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 10, 55, 55));

                e.Graphics.DrawString(title, titleFont, Brushes.Black,
                    new RectangleF(e.CellBounds.X + 70, e.CellBounds.Y + 10, e.CellBounds.Width - 75, 20));
                e.Graphics.DrawString(description, descFont, Brushes.Gray,
                    new RectangleF(e.CellBounds.X + 70, e.CellBounds.Y + 30, e.CellBounds.Width - 75, e.CellBounds.Height - 35));
            }
            else if (e.ColumnIndex == tblItems.Columns["colStatus"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                string statusText = e.Value?.ToString() ?? "N/A";
                Color backColor, foreColor;

                switch (statusText.ToUpper())
                {
                    case "APPROVED":
                        backColor = Color.FromArgb(198, 239, 206);
                        foreColor = Color.FromArgb(0, 97, 0);
                        break;
                    case "PENDING":
                        backColor = Color.FromArgb(255, 235, 156);
                        foreColor = Color.FromArgb(156, 101, 0);
                        break;
                    case "REJECTED":
                       backColor = Color.FromArgb(255, 192, 192);
                       foreColor = Color.FromArgb(139, 0, 0);
                        break;
                    default:
                        backColor = Color.LightGray;
                        foreColor = Color.Black;
                        break;
                }

                SizeF textSize = e.Graphics.MeasureString(statusText, statusFont);
                int paddingX = 10, paddingY = 4;
                Rectangle pillRect = new Rectangle(
                    e.CellBounds.X + (e.CellBounds.Width - (int)textSize.Width - paddingX) / 2,
                    e.CellBounds.Y + (e.CellBounds.Height - (int)textSize.Height - paddingY) / 2,
                    (int)textSize.Width + paddingX,
                    (int)textSize.Height + paddingY);

                using (Brush backBrush = new SolidBrush(backColor))
                    e.Graphics.FillRectangle(backBrush, pillRect);
                using (Brush foreBrush = new SolidBrush(foreColor))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    e.Graphics.DrawString(statusText, statusFont, foreBrush, pillRect, sf);
                }
            }
            else if (e.ColumnIndex == tblItems.Columns["colActions"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                int iconSize = 25;
                int spacing = 12;

                int y = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;

                var visibleIcons = new List<Image>();
                visibleIcons.Add(Properties.Resources.view_icon); // View always

                int reporterId = Convert.ToInt32(tblItems.Rows[e.RowIndex].Cells["colReportedById"].Value);
                string status = tblItems.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString() ?? "";

                if (Session.Role == "Admin" || (Session.Role == "Staff" && reporterId == Session.UserId))
                    visibleIcons.Add(Properties.Resources.edit_icon);

                if (Session.Role == "Super Admin")
                    visibleIcons.Add(Properties.Resources.delete_icon);

                // Add Approve icon only if status is Pending
                if (Session.Role == "Admin" && status.ToUpper() == "PENDING") { 
                    visibleIcons.Add(Properties.Resources.approve_icon);
                    visibleIcons.Add(Properties.Resources.reject_icon);
                }
                int totalWidth = visibleIcons.Count * iconSize + (visibleIcons.Count - 1) * spacing;
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;

                Rectangle[] iconRects = new Rectangle[visibleIcons.Count];

                for (int i = 0; i < visibleIcons.Count; i++)
                {
                    iconRects[i] = new Rectangle(startX + i * (iconSize + spacing), y, iconSize, iconSize);

                    using (var bmp = new Bitmap(visibleIcons[i], new Size(iconSize, iconSize)))
                    {
                        e.Graphics.DrawImage(bmp, iconRects[i]);
                    }
                }

                tblItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = iconRects;
            }
        }



        private void TblItems_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tblItems.Columns[e.ColumnIndex].Name == "colType")
            {
                string val = e.Value?.ToString()?.ToLower() ?? "";
                e.CellStyle!.ForeColor = val switch
                {
                    "lost" => Color.Red,
                    "found" => Color.Green,
                    _ => Color.Black
                };
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
        }
        #endregion

        #region Filters
        private void LoadFilters()
        {
            LoadStatusFilter();
            LoadFilter(cmbCategory, "categories", "All Categories");
            LoadFilter(cmbLocation, "locations", "All Locations");
            LoadFilter(cmbDepartment, "departments", "All Departments");
            LoadTypeFilter();
        }
        private void LoadTypeFilter()
        {
            cmbType.Items.Clear();
            cmbType.Items.AddRange(new[] { "All", "Lost", "Found" });
            cmbType.SelectedIndex = 0;

            cmbType.SelectedIndexChanged += (s, e) =>
            {
                switch (cmbType.SelectedItem.ToString().ToLower())
                {
                    case "lost":
                        typeFilter = "lost";
                        break;
                    case "found":
                        typeFilter = "found";
                        break;
                    default:
                        typeFilter = "";
                        break;
                }

                currentPage = 1;
                LoadItems();
            };
        }

        private void LoadStatusFilter()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new[] { "All", "Approved", "Pending" });
            cmbStatus.SelectedIndex = 0;
        }
       

        private void LoadFilter(ComboBox combo, string table, string placeholder)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var query = $"SELECT id, name FROM {table}";
                var da = new MySqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);

                var row = dt.NewRow();
                row["id"] = 0;
                row["name"] = placeholder;
                dt.Rows.InsertAt(row, 0);

                combo.DataSource = dt;
                combo.DisplayMember = "name";
                combo.ValueMember = "id";
                combo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {table}: {ex.Message}");
            }
        }
        #endregion

        #region Load Items
        private void LoadItems()
        {
            try
            {
                // Safely handle nullable SelectedItem
                string status = (cmbStatus.SelectedItem?.ToString() ?? "All") == "All" ? "" : cmbStatus.SelectedItem!.ToString()!;

                int? categoryId = Convert.ToInt32(cmbCategory.SelectedValue) == 0 ? null : Convert.ToInt32(cmbCategory.SelectedValue);
                int? locationId = Convert.ToInt32(cmbLocation.SelectedValue) == 0 ? null : Convert.ToInt32(cmbLocation.SelectedValue);
                int? departmentId = Convert.ToInt32(cmbDepartment.SelectedValue) == 0 ? null : Convert.ToInt32(cmbDepartment.SelectedValue);

                string search = searchBox.Text.Trim();

                ItemService service = new ItemService();
                DataTable dt = service.GetItems(out totalRecords,
                                                search,
                                                status,
                                                categoryId,
                                                locationId,
                                                departmentId,
                                                typeFilter,
                                                currentPage,
                                                pageSize);

                totalPages = Math.Max(1, (int)Math.Ceiling(totalRecords / (double)pageSize));

                tblItems.Rows.Clear();
                Image defaultImg = Properties.Resources.default_item;

                foreach (DataRow row in dt.Rows)
                {
                    int rowIndex = tblItems.Rows.Add();
                    tblItems.Rows[rowIndex].Cells["colItemId"].Value = row["id"];

                    // Handle possible null image_path
                    string imgPath = row["image_path"] != DBNull.Value ? row["image_path"]!.ToString()! : "";
                    Image imgToUse = defaultImg;
                    if (!string.IsNullOrEmpty(imgPath))
                    {
                        string fullPath = Path.Combine(Application.StartupPath, imgPath);
                        if (File.Exists(fullPath))
                        {
                            using var original = Image.FromFile(fullPath);
                            imgToUse = new Bitmap(original, new Size(55, 55));
                        }
                    }

                    // Handle possible null description/title
                    string description = row["description"] != DBNull.Value ? row["description"]!.ToString()! : "";
                    string title = row["title"] != DBNull.Value ? row["title"]!.ToString()! : "";

                    tblItems.Rows[rowIndex].Cells["colItem"].Tag = new object[]
                    {
                imgToUse,
                description
                    };
                    tblItems.Rows[rowIndex].Cells["colItem"].Value = title;

                    tblItems.Rows[rowIndex].Cells["colCategory"].Value = row["category"] != DBNull.Value ? row["category"]!.ToString()! : "";
                    tblItems.Rows[rowIndex].Cells["colType"].Value = row["type"] != DBNull.Value ? row["type"]!.ToString()! : "";
                    tblItems.Rows[rowIndex].Cells["colStatus"].Value = row["status"] != DBNull.Value ? row["status"]!.ToString()! : "";
                    tblItems.Rows[rowIndex].Cells["colLocation"].Value = row["location"] != DBNull.Value ? row["location"]!.ToString()! : "";
                    tblItems.Rows[rowIndex].Cells["colDepartment"].Value = row["department"] != DBNull.Value ? row["department"]!.ToString()! : "";
                    tblItems.Rows[rowIndex].Cells["colReportedBy"].Value = row["reporter_name"] != DBNull.Value ? row["reporter_name"]!.ToString()! : "";
                    tblItems.Rows[rowIndex].Cells["colReportedById"].Value = row["reporter_id"] != DBNull.Value ? Convert.ToInt32(row["reporter_id"]) : 0;

                    tblItems.Rows[rowIndex].Cells["colDateTime"].Value =
                        row["date_created"] != DBNull.Value ? Convert.ToDateTime(row["date_created"]).ToString("MMMM dd, yyyy hh:mm tt") : "";
                    tblItems.Rows[rowIndex].Cells["colActions"].Value = "View";
                }

                AdjustRowHeights();
                UpdatePaginationControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

        #endregion

        #region Pagination
        private void BtnPreviousPage_Click(object? sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadItems();
            }
        }

        private void BtnNextPage_Click(object? sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadItems();
            }
        }

        private void UpdatePaginationControls()
        {
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}";
            btnPreviousPage.Enabled = totalRecords > 0 && currentPage > 1;
            btnNextPage.Enabled = totalRecords > 0 && currentPage < totalPages;
        }
        #endregion

        #region Row Height Adjustment
        private void AdjustRowHeights()
        {
            foreach (DataGridViewRow row in tblItems.Rows)
            {
                string title = row.Cells["colItem"].Value?.ToString() ?? "";
                var tag = row.Cells["colItem"].Tag as object[];
                string description = tag?[1]?.ToString() ?? "";

                Size titleSize = TextRenderer.MeasureText(title, titleFont,
                    new Size(tblItems.Columns["colItem"].Width - 75, int.MaxValue), TextFormatFlags.WordBreak);
                Size descSize = TextRenderer.MeasureText(description, descFont,
                    new Size(tblItems.Columns["colItem"].Width - 75, int.MaxValue), TextFormatFlags.WordBreak);

                row.Height = Math.Max(80, titleSize.Height + descSize.Height + 20);
            }
        }
       

        #endregion

        #region Event Handlers
        private void Filters_Changed(object? sender, EventArgs e)
        {
            currentPage = 1;
            LoadItems();
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            currentPage = 1;
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void BtnClearFilter_Click(object? sender, EventArgs e)
        {
            typeFilter = "";

            currentPage = 1;
            cmbStatus.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbLocation.SelectedIndex = 0;
            cmbDepartment.SelectedIndex = 0;
            searchBox.Clear();
            LoadItems();
        }

        private void TblItems_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (tblItems.Columns[e.ColumnIndex].Name != "colActions") return;

            var cell = tblItems.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var rects = cell.Tag as Rectangle[];
            if (rects == null) return;

            // Get row data
            int reporterId = Convert.ToInt32(tblItems.Rows[e.RowIndex].Cells["colReportedById"].Value);
            string status = tblItems.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString() ?? "";
            int itemId = Convert.ToInt32(tblItems.Rows[e.RowIndex].Cells["colItemId"].Value);

            // Dynamically map rectangles to icons
            int index = 0;
            Rectangle btnView = rects[index++];

            Rectangle btnEdit = Rectangle.Empty;
            if (Session.Role == "Admin" || (Session.Role == "Staff" && reporterId == Session.UserId))
                btnEdit = rects[index++];

            Rectangle btnDelete = Rectangle.Empty;
            if (Session.Role == "Super Admin")
                btnDelete = rects[index++];

            Rectangle btnApprove = Rectangle.Empty;
            Rectangle btnReject = Rectangle.Empty;
            if (Session.Role == "Admin" && status.ToUpper() == "PENDING")
            {
                btnApprove = rects[index++];
                btnReject = rects[index++];

            }

            // Convert click coordinates
            var clickPoint = tblItems.PointToClient(Cursor.Position);

            // Handle clicks
            if (btnView.Contains(clickPoint))
            {
                new ViewItemForm(itemId).ShowDialog();
            }
            else if (btnEdit.Contains(clickPoint))
            {
                if (Session.Role == "Admin" || (Session.Role == "Staff" && reporterId == Session.UserId))
                {
                    new EditItemForm(itemId).ShowDialog();
                    LoadItems();
                }
                else
                {
                    MessageBox.Show("You can only edit your own reports.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (btnApprove.Contains(clickPoint))
            {
                if (MessageBox.Show("Approve this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using var conn = Database.GetConnection();
                        conn.Open();
                        string query = "UPDATE items SET status='Approved' WHERE id=@id";
                        using var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", itemId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Item approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error approving item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadItems();
                }
            }
            if (btnReject != Rectangle.Empty && btnReject.Contains(clickPoint))
            {
                if (MessageBox.Show("Reject this item?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using var conn = Database.GetConnection();
                        conn.Open();
                        string query = "UPDATE items SET status='Rejected' WHERE id=@id";
                        using var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", itemId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Item rejected successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error rejecting item: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadItems();
                }
                return;
            }
            else if (btnDelete.Contains(clickPoint))
            {
                if (MessageBox.Show("Delete this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using var conn = Database.GetConnection();
                        conn.Open();
                        string query = "DELETE FROM items WHERE id=@id";
                        using var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", itemId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadItems();
                }
            }
        }
        public void SetStatusFilter(string status)
        {
            // Find the index that matches the status (case-insensitive)
            int index = cmbStatus.Items.IndexOf(status);
            if (index >= 0)
                cmbStatus.SelectedIndex = index;
            else
                cmbStatus.SelectedIndex = 0; // fallback to "All"

            // Reload items after changing the filter
            currentPage = 1;
            LoadItems();
        }
        private void TblItems_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != tblItems.Columns["colActions"].Index)
            {
                tblItems.Cursor = Cursors.Default;
                return;
            }

            var cell = tblItems.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var rects = cell.Tag as Rectangle[];
            if (rects == null)
            {
                tblItems.Cursor = Cursors.Default;
                return;
            }

            // Get mouse position relative to the DataGridView
            var pt = tblItems.PointToClient(Cursor.Position);

            bool overIcon = false;
            foreach (var r in rects)
            {
                if (r.Contains(pt))
                {
                    overIcon = true;
                    break;
                }
            }

            tblItems.Cursor = overIcon ? Cursors.Hand : Cursors.Default;
        }

        private void TblItems_CellMouseLeave(object sender, EventArgs e)
        {
            tblItems.Cursor = Cursors.Default;
        }

        #endregion
    }
}

