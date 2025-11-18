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

        private void TblItems_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = tblItems.Rows[e.RowIndex];

            if (e.ColumnIndex == tblItems.Columns["colItem"].Index)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);

                var tag = row.Cells[e.ColumnIndex].Tag as object[];
                Image img = tag?[0] as Image;
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

                int btnWidth = 50, btnHeight = 25, spacing = 5;
                int totalWidth = btnWidth * 3 + spacing * 2;
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
                int y = e.CellBounds.Y + (e.CellBounds.Height - btnHeight) / 2;

                Rectangle btnView = new Rectangle(startX, y, btnWidth, btnHeight);
                Rectangle btnEdit = new Rectangle(startX + btnWidth + spacing, y, btnWidth, btnHeight);
                Rectangle btnDelete = new Rectangle(startX + (btnWidth + spacing) * 2, y, btnWidth, btnHeight);

                row.Cells[e.ColumnIndex].Tag = new Rectangle[] { btnView, btnEdit, btnDelete };

                using (Brush viewBrush = new SolidBrush(Color.FromArgb(66, 133, 244)))
                    e.Graphics.FillRectangle(viewBrush, btnView);
                e.Graphics.DrawString("View", new Font("Segoe UI", 8), Brushes.White, btnView,
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                if (Session.Role == "Admin")
                {
                    using (Brush editBrush = new SolidBrush(Color.FromArgb(52, 168, 83)))
                        e.Graphics.FillRectangle(editBrush, btnEdit);
                    e.Graphics.DrawString("Edit", new Font("Segoe UI", 8), Brushes.White, btnEdit,
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                if (Session.Role == "SuperAdmin")
                {
                    using (Brush deleteBrush = new SolidBrush(Color.FromArgb(234, 67, 53)))
                        e.Graphics.FillRectangle(deleteBrush, btnDelete);
                    e.Graphics.DrawString("Delete", new Font("Segoe UI", 8), Brushes.White, btnDelete,
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
            }
        }

        private void TblItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tblItems.Columns[e.ColumnIndex].Name == "colType")
            {
                string val = e.Value?.ToString()?.ToLower() ?? "";
                e.CellStyle.ForeColor = val switch
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
                string status = cmbStatus.SelectedItem?.ToString() == "All" ? "" : cmbStatus.SelectedItem?.ToString();

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
                                                currentPage,
                                                pageSize);

                totalPages = Math.Max(1, (int)Math.Ceiling(totalRecords / (double)pageSize));

                tblItems.Rows.Clear();
                Image defaultImg = Properties.Resources.default_item;

                foreach (DataRow row in dt.Rows)
                {
                    int rowIndex = tblItems.Rows.Add();
                    tblItems.Rows[rowIndex].Cells["colItemId"].Value = row["id"];

                    Image imgToUse = defaultImg;
                    string imgPath = row["image_path"].ToString();
                    if (!string.IsNullOrEmpty(imgPath))
                    {
                        string fullPath = Path.Combine(Application.StartupPath, imgPath);
                        if (File.Exists(fullPath))
                        {
                            using var original = Image.FromFile(fullPath);
                            imgToUse = new Bitmap(original, new Size(55, 55));
                        }
                    }

                    tblItems.Rows[rowIndex].Cells["colItem"].Tag = new object[]
                    {
                        imgToUse,
                        row["description"].ToString()
                    };
                    tblItems.Rows[rowIndex].Cells["colItem"].Value = row["title"];
                    tblItems.Rows[rowIndex].Cells["colCategory"].Value = row["category"];
                    tblItems.Rows[rowIndex].Cells["colType"].Value = row["type"];
                    tblItems.Rows[rowIndex].Cells["colStatus"].Value = row["status"];
                    tblItems.Rows[rowIndex].Cells["colLocation"].Value = row["location"];
                    tblItems.Rows[rowIndex].Cells["colDepartment"].Value = row["department"];
                    tblItems.Rows[rowIndex].Cells["colReportedBy"].Value = row["reporter_name"];
                    tblItems.Rows[rowIndex].Cells["colDateTime"].Value =
                        Convert.ToDateTime(row["date_created"]).ToString("MMMM dd, yyyy hh:mm tt");
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
        private void BtnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadItems();
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
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
        private void Filters_Changed(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadItems();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void BtnClearFilter_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            cmbStatus.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbLocation.SelectedIndex = 0;
            cmbDepartment.SelectedIndex = 0;
            searchBox.Clear();
            LoadItems();
        }

        private void TblItems_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (tblItems.Columns[e.ColumnIndex].Name == "colActions")
            {
                var cell = tblItems.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var rects = cell.Tag as Rectangle[];
                if (rects == null) return;

                Rectangle btnView = rects[0];
                Rectangle btnEdit = rects.Length > 1 ? rects[1] : Rectangle.Empty;
                Rectangle btnDelete = rects.Length > 2 ? rects[2] : Rectangle.Empty;

                // Convert mouse click coordinates
                var clickPoint = tblItems.PointToClient(Cursor.Position);

                if (btnView.Contains(clickPoint))
                {
                    int itemId = Convert.ToInt32(tblItems.Rows[e.RowIndex].Cells["colItemId"].Value);
                    var viewForm = new ViewItemForm(itemId);
                    viewForm.ShowDialog();
                }
                else if (Session.Role == "Admin" && btnEdit.Contains(clickPoint))
                {
                    int itemId = Convert.ToInt32(tblItems.Rows[e.RowIndex].Cells["colItemId"].Value);
                    var editForm = new EditItemForm(itemId);
                    editForm.ShowDialog();
                    LoadItems();
                }
                //else if (Session.Role == "SuperAdmin" && btnDelete.Contains(clickPoint))
                //{
                //    int itemId = Convert.ToInt32(tblItems.Rows[e.RowIndex].Cells["colItemId"].Value);
                //    // Call your delete logic
                //    DeleteItem(itemId);
                //    LoadItems();
                //}
            }
        }

        #endregion
    }
}

#region LoadItems process
//private void LoadItems()
//{
//    try
//    {
//        // --- 1. Prepare filter parameters ---
//        string status = cmbStatus.SelectedItem?.ToString() == "All" ? "" : cmbStatus.SelectedItem?.ToString();
//        int? categoryId = Convert.ToInt32(cmbCategory.SelectedValue) == 0 ? null : Convert.ToInt32(cmbCategory.SelectedValue);
//        int? locationId = Convert.ToInt32(cmbLocation.SelectedValue) == 0 ? null : Convert.ToInt32(cmbLocation.SelectedValue);
//        int? departmentId = Convert.ToInt32(cmbDepartment.SelectedValue) == 0 ? null : Convert.ToInt32(cmbDepartment.SelectedValue);
//        string search = searchBox.Text.Trim();

//        // --- 2. Open database connection ---
//        using var conn = Database.GetConnection();
//        conn.Open();

//        // --- 3. Build query with filters ---
//        string query = @"
//            SELECT SQL_CALC_FOUND_ROWS i.id, i.title, i.description, i.image_path,
//                   c.name AS category, i.type, i.status,
//                   l.name AS location, d.name AS department,
//                   u.name AS reporter_name, i.date_reported
//            FROM items i
//            LEFT JOIN categories c ON i.category_id = c.id
//            LEFT JOIN locations l ON i.location_id = l.id
//            LEFT JOIN departments d ON i.department_id = d.id
//            LEFT JOIN users u ON i.reported_by = u.id
//            WHERE (@search IS NULL OR i.title LIKE CONCAT('%', @search, '%'))
//              AND (@status IS NULL OR i.status = @status)
//              AND (@categoryId IS NULL OR i.category_id = @categoryId)
//              AND (@locationId IS NULL OR i.location_id = @locationId)
//              AND (@departmentId IS NULL OR i.department_id = @departmentId)
//            ORDER BY i.date_reported DESC
//            LIMIT @offset, @pageSize;";

//        int offset = (currentPage - 1) * pageSize;

//        using var cmd = new MySqlCommand(query, conn);
//        cmd.Parameters.AddWithValue("@search", string.IsNullOrEmpty(search) ? (object)DBNull.Value : search);
//        cmd.Parameters.AddWithValue("@status", string.IsNullOrEmpty(status) ? (object)DBNull.Value : status);
//        cmd.Parameters.AddWithValue("@categoryId", categoryId ?? (object)DBNull.Value);
//        cmd.Parameters.AddWithValue("@locationId", locationId ?? (object)DBNull.Value);
//        cmd.Parameters.AddWithValue("@departmentId", departmentId ?? (object)DBNull.Value);
//        cmd.Parameters.AddWithValue("@offset", offset);
//        cmd.Parameters.AddWithValue("@pageSize", pageSize);

//        // --- 4. Fill DataTable ---
//        DataTable dt = new DataTable();
//        using var da = new MySqlDataAdapter(cmd);
//        da.Fill(dt);

//        // --- 5. Get total records for pagination ---
//        using var totalCmd = new MySqlCommand("SELECT FOUND_ROWS();", conn);
//        totalRecords = Convert.ToInt32(totalCmd.ExecuteScalar());
//        totalPages = Math.Max(1, (int)Math.Ceiling(totalRecords / (double)pageSize));

//        // --- 6. Populate DataGridView ---
//        tblItems.Rows.Clear();
//        Image defaultImg = Properties.Resources.default_item;

//        foreach (DataRow row in dt.Rows)
//        {
//            int rowIndex = tblItems.Rows.Add();
//            tblItems.Rows[rowIndex].Cells["colItemId"].Value = row["id"];

//            Image imgToUse = defaultImg;
//            string imgPath = row["image_path"].ToString();
//            if (!string.IsNullOrEmpty(imgPath))
//            {
//                string fullPath = Path.Combine(Application.StartupPath, imgPath);
//                if (File.Exists(fullPath))
//                {
//                    using var original = Image.FromFile(fullPath);
//                    imgToUse = new Bitmap(original, new Size(55, 55));
//                }
//            }

//            tblItems.Rows[rowIndex].Cells["colItem"].Tag = new object[]
//            {
//                imgToUse,
//                row["description"].ToString()
//            };
//            tblItems.Rows[rowIndex].Cells["colItem"].Value = row["title"];
//            tblItems.Rows[rowIndex].Cells["colCategory"].Value = row["category"];
//            tblItems.Rows[rowIndex].Cells["colType"].Value = row["type"];
//            tblItems.Rows[rowIndex].Cells["colStatus"].Value = row["status"];
//            tblItems.Rows[rowIndex].Cells["colLocation"].Value = row["location"];
//            tblItems.Rows[rowIndex].Cells["colDepartment"].Value = row["department"];
//            tblItems.Rows[rowIndex].Cells["colReportedBy"].Value = row["reporter_name"];
//            tblItems.Rows[rowIndex].Cells["colDateTime"].Value =
//                Convert.ToDateTime(row["date_reported"]).ToString("MMMM dd, yyyy hh:mm tt");
//            tblItems.Rows[rowIndex].Cells["colActions"].Value = "View";
//        }

//        AdjustRowHeights();
//        UpdatePaginationControls();
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show("Error loading items: " + ex.Message);
//    }
//}
#endregion LoadItem Process