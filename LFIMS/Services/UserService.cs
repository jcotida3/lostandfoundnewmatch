using LFsystem.Models;
using MySql.Data.MySqlClient;
using System;

namespace LFsystem.Services
{
    public class UserService
    {
        public User? GetUserByUsername(string username)
        {
            User? user = null; 
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT id, username, password, name, email, role, IsActive
                                     FROM users 
                                     WHERE username = @username 
                                     LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    ID = reader.GetInt32("id"),
                                    Username = reader.GetString("username"),
                                    PasswordHash = reader.GetString("password"),
                                    FullName = reader.IsDBNull(reader.GetOrdinal("name")) ? "" : reader.GetString("name"),
                                    Email = reader.GetString("email"),
                                    Role = reader.GetString("role"),
                                    IsActive = reader.GetBoolean("IsActive")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user: " + ex.Message);
            }

            return user;
        }
    }
}
