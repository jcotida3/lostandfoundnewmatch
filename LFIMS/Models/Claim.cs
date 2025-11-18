using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFsystem.Models
{
    public class Claim
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int ClaimantID { get; set; }  // Staff/Admin who processes claim
        public string Status { get; set; }   // Pending, Approved, Rejected
        public DateTime DateClaimed { get; set; }
    }
}
