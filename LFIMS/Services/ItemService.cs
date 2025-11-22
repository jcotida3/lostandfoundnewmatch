using LFsystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace LFsystem.Services
{
    public class ItemService
    {
        public bool AddItem(ItemModel item)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO items
                        (title, description, type, category_id, location_id, department_id,
                         status, reporter_id, student_name, student_contact, image_path, date_created)
                         VALUES (@title, @description, @type, @category_id, @location_id, @department_id,
                                 @status, @reporter_id, @student_name, @student_contact, @image_path, @date_created)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", item.Title);
                        cmd.Parameters.AddWithValue("@description", item.Description);
                        cmd.Parameters.AddWithValue("@type", item.Type);
                        cmd.Parameters.AddWithValue("@category_id", item.CategoryId);
                        cmd.Parameters.AddWithValue("@location_id", item.LocationId);
                        cmd.Parameters.AddWithValue("@department_id", item.DepartmentId);
                        cmd.Parameters.AddWithValue("@status", item.Status ?? "Pending");
                        cmd.Parameters.AddWithValue("@reporter_id", item.ReporterId);
                        cmd.Parameters.AddWithValue("@student_name", item.StudentName);
                        cmd.Parameters.AddWithValue("@student_contact", item.StudentEmail);
                        cmd.Parameters.AddWithValue("@image_path", item.ImagePath ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@date_created", item.DateReported);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
            public DataTable GetItems(out int totalRecords, string search = "", string status = "",
                                  int? categoryId = null, int? locationId = null, int? departmentId = null,
                                  int page = 1, int pageSize = 10)
            {
                totalRecords = 0;
                DataTable dt = new DataTable();

                using var conn = Database.GetConnection();
                conn.Open();

                // Count total records
                string countQuery = @"
                SELECT COUNT(*) FROM items i
                WHERE (@status = '' OR i.status = @status)
                  AND (@categoryId IS NULL OR i.category_id = @categoryId)
                  AND (@locationId IS NULL OR i.location_id = @locationId)
                  AND (@departmentId IS NULL OR i.department_id = @departmentId)
                  AND (@searchText = '' OR i.title LIKE @searchText OR i.description LIKE @searchText)";

                using (var countCmd = new MySqlCommand(countQuery, conn))
                {
                    countCmd.Parameters.AddWithValue("@status", status ?? "");
                    countCmd.Parameters.AddWithValue("@categoryId", categoryId.HasValue ? categoryId.Value : (object)DBNull.Value);
                    countCmd.Parameters.AddWithValue("@locationId", locationId.HasValue ? locationId.Value : (object)DBNull.Value);
                    countCmd.Parameters.AddWithValue("@departmentId", departmentId.HasValue ? departmentId.Value : (object)DBNull.Value);
                    countCmd.Parameters.AddWithValue("@searchText", "%" + search + "%");

                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());
                }

                int offset = (page - 1) * pageSize;

                string query = @"
                SELECT i.id, i.title, i.description, c.name AS category, i.type,
                       l.name AS location, d.name AS department, reporter_id,
                       u.name AS reporter_name, i.date_created, i.image_path, i.status
                FROM items i
                LEFT JOIN categories c ON i.category_id = c.id
                LEFT JOIN locations l ON i.location_id = l.id
                LEFT JOIN departments d ON i.department_id = d.id
                LEFT JOIN users u ON i.reporter_id = u.id
                WHERE (@status = '' OR i.status = @status)
                  AND (@categoryId IS NULL OR i.category_id = @categoryId)
                  AND (@locationId IS NULL OR i.location_id = @locationId)
                  AND (@departmentId IS NULL OR i.department_id = @departmentId)
                  AND (@searchText = '' OR i.title LIKE @searchText OR i.description LIKE @searchText)
                ORDER BY i.date_created DESC
                LIMIT @pageSize OFFSET @offset";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", status ?? "");
                cmd.Parameters.AddWithValue("@categoryId", categoryId.HasValue ? categoryId.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@locationId", locationId.HasValue ? locationId.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@departmentId", departmentId.HasValue ? departmentId.Value : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@searchText", "%" + search + "%");
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@offset", offset);

                var da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            

        }
}

