using System.Configuration;
using MySql.Data.MySqlClient;

namespace LFsystem.Services
{
    public static class Database
    {
        // Read connection string once at startup
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        /// <summary>
        /// Returns a new MySqlConnection using the stored connection string
        /// </summary>
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
