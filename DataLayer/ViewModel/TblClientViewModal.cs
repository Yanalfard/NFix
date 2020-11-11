using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModel
{
    public class TblClientViewModal
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string IdentificationNo { get; set; }
        public string TellNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int UserPassId { get; set; }
        public int Status { get; set; }
        public int DaysTillFinished { get; set; } = 0;
        public int TotalDays { get; set; } = 0;
        public int TotalMonth { get; set; } = 0;
        public double Percentage { get; set; } = 0;
        public bool IsPremium { get; set; }
        public string PremiumTill { get; set; }
        public string InviteCode { get; set; }
    }
}
