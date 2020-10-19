using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer.ViewModel
{
    public class TutorViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string IdentificationNo { get; set; }
        public string TellNo { get; set; }
        public string MainImage { get; set; }
        public string Description { get; set; }
        public int UserPassId { get; set; }
    }
}
