using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModel
{
    public class OrderViewModel
    {
        public int id { get; set; }
        public long Sum { get; set; }
        public bool IsFInaly { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> DiscountId { get; set; }
        public string TellClient { get; set; }
        public string Usernmae { get; set; }
    }
}
