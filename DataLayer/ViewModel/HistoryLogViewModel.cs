using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModel
{
    public class HistoryLogViewModel
    {
        public int id { get; set; }
        public string LogText { get; set; }
        public long MoneyTransfered { get; set; }
        public System.DateTime Date { get; set; }
        public string ClientTell { get; set; }
        public bool IsValid { get; set; }
        public Nullable<int> PriceId { get; set; }
        public Nullable<int> Discount { get; set; }
    }
}
