/*using LFsystem.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace LFsystem.Services
{
    public class ClaimService
    {
        private MySqlConnection _conn;

        public ClaimService()
        {
            _conn = Database.Instance.GetConnection();
        }

        public List<Claim> GetAllClaims()
        {
            var claims = new List<Claim>();
            _conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM claims", _conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                claims.Add(new Claim
                {
                    ID = Convert.ToInt32(reader["id"]),
                    ItemID = Convert.ToInt32(reader["item_id"]),
                    ClaimantID = Convert.ToInt32(reader["claimant_id"]),
                    Status = reader["status"].ToString(),
                    DateClaimed = Convert.ToDateTime(reader["date_claimed"])
                });
            }
            _conn.Close();
            return claims;
        }

        // TODO: Add AddClaim, UpdateClaim, DeleteClaim methods
    }
}
*/