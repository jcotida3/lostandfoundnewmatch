using LFsystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using LFsystem.Helpers;
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
                        (title, description, type, category_id, location_id, 
                         status, reporter_id, student_name, student_contact, image_path, created_at)
                         VALUES (@title, @description, @type, @category_id, @location_id,
                                 @status, @reporter_id, @student_name, @student_contact, @image_path, @created_at)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", item.Title);
                        cmd.Parameters.AddWithValue("@description", item.Description);
                        cmd.Parameters.AddWithValue("@type", item.Type);
                        cmd.Parameters.AddWithValue("@category_id", item.CategoryId);
                        cmd.Parameters.AddWithValue("@location_id", item.LocationId);
                        cmd.Parameters.AddWithValue("@status", item.Status ?? "Pending");
                        cmd.Parameters.AddWithValue("@reporter_id", item.ReporterId);
                        cmd.Parameters.AddWithValue("@student_name", item.StudentName);
                        cmd.Parameters.AddWithValue("@student_contact", item.StudentEmail);
                        cmd.Parameters.AddWithValue("@image_path", item.ImagePath ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@created_at", item.DateReported);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message);
                return false;
            }
        }

        // UPDATED: Clean, corrected, and supports Lost/Found filtering
        public DataTable GetItems(
            out int totalRecords,
            string search = "",
            string status = null,
            int? categoryId = null,
            int? locationId = null,
            string typeFilter = "",    // Lost / Found / "" (all)
            int page = 1,
            int pageSize = 10)
        {
            totalRecords = 0;
            DataTable dt = new DataTable();

            using var conn = Database.GetConnection();
            conn.Open();

            // COUNT QUERY
            string countQuery = @"
                SELECT COUNT(*)
                FROM items i
                WHERE i.status != 'Rejected'
                  AND (@status IS NULL OR i.status = @status)
                  AND (@type = '' OR LOWER(i.type) = LOWER(@type))
                  AND (@categoryId IS NULL OR i.category_id = @categoryId)
                  AND (@locationId IS NULL OR i.location_id = @locationId)
                  AND (@searchText = '' OR i.title LIKE @searchText OR i.description LIKE @searchText)
            ";

            using (var countCmd = new MySqlCommand(countQuery, conn))
            {
                countCmd.Parameters.AddWithValue("@status", status);
                countCmd.Parameters.AddWithValue("@type", typeFilter);
                countCmd.Parameters.AddWithValue("@categoryId", categoryId.HasValue ? categoryId : (object)DBNull.Value);
                countCmd.Parameters.AddWithValue("@locationId", locationId.HasValue ? locationId : (object)DBNull.Value);
                countCmd.Parameters.AddWithValue("@searchText", "%" + search + "%");

                totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());
            }

            int offset = (page - 1) * pageSize;

            // MAIN SELECT QUERY
            string query = @"
                SELECT i.id, i.title, i.description, 
                       c.name AS category, 
                       i.type,
                       l.name AS location, 
                       i.reporter_id, 
                       u.name AS reporter_name, 
                       i.created_at, 
                       i.image_path, 
                       i.status,
                       i.matched_item_id
                FROM items i
                LEFT JOIN categories c ON i.category_id = c.id
                LEFT JOIN locations l ON i.location_id = l.id
                LEFT JOIN users u ON i.reporter_id = u.id
                   WHERE i.status != 'Rejected'
                  AND (@status IS NULL OR i.status = @status)
                  AND (@type = '' OR LOWER(i.type) = LOWER(@type))
                  AND (@categoryId IS NULL OR i.category_id = @categoryId)
                  AND (@locationId IS NULL OR i.location_id = @locationId)
                  AND (@searchText = '' OR i.title LIKE @searchText OR i.description LIKE @searchText)
                ORDER BY i.created_at DESC
                LIMIT @pageSize OFFSET @offset
            ";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@type", typeFilter);
            cmd.Parameters.AddWithValue("@categoryId", categoryId.HasValue ? categoryId : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@locationId", locationId.HasValue ? locationId : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@searchText", "%" + search + "%");
            cmd.Parameters.AddWithValue("@pageSize", pageSize);
            cmd.Parameters.AddWithValue("@offset", offset);

            var da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
        // Inside your ItemService.cs class

        
       

        
    }
}