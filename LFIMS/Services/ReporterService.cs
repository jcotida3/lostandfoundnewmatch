/*using LFsystem.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace LFsystem.Services
{
    public class ReporterService
    {
        private MySqlConnection _conn;

        public ReporterService()
        {
            _conn = Database.Instance.GetConnection();
        }

        public List<Reporter> GetAllReporters()
        {
            var reporters = new List<Reporter>();
            _conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM reporters", _conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                reporters.Add(new Reporter
                {
                    ID = Convert.ToInt32(reader["id"]),
                    FullName = reader["full_name"].ToString(),
                    Email = reader["email"].ToString(),
                    Phone = reader["phone"].ToString(),
                    StudentID = reader["student_id"].ToString(),
                    CreatedAt = Convert.ToDateTime(reader["created_at"])
                });
            }
            _conn.Close();
            return reporters;
        }

        // TODO: Add AddReporter, UpdateReporter, DeleteReporter methods
    }
}
*/