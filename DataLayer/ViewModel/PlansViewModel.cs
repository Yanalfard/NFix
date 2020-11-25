using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModel
{
    public class PlansViewModel
    {
        public int id { get; set; }
        public string PriceName { get; set; }
        public int Price { get; set; }
        public int SumPrice { get; set; }
        public int Discount { get; set; }
    }
}
