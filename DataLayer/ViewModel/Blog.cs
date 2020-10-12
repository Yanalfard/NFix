using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer.ViewModel
{
    public class BlogViewModel
    {
        public int id { get; set; }
        public string MainImage { get; set; }
        public string Body { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public int LikeCount { get; set; }
        public string Title { get; set; }
    }
}
