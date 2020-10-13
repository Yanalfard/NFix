using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Body { get; set; }
        [Display(Name = "توضیح مخثصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر زیاد است")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int LikeCount { get; set; }
        [Display(Name = "تیتر")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر زیاد است")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "کلمات کلیدی")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر زیاد است")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Keywords { get; set; }
    }
}
