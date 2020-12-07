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
        public bool IsActive { get; set; }
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [Display(Name ="نام")]
        [MaxLength(100,ErrorMessage ="تعداد کاراکتر بیشتر است")]
        public string Name { get; set; } 
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [Display(Name ="تخصص")]
        [MaxLength(100,ErrorMessage ="تعداد کاراکتر بیشتر است")]
        public string Specialty { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "کد ملی")]
        [MaxLength(10, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string IdentificationNo { get; set; }
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(11, ErrorMessage = "تعداد کاراکتر کم است")]
        [MaxLength(11, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression("09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}", ErrorMessage = "{0} معتبر نیست")]
        [RegularExpression("[0]{1}[9]{1}[0-9]{9}", ErrorMessage = "شماره تلفن وارد شده معتبر نمی باشد")]
        public string TellNo { get; set; }
        public string MainImage { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره تلفن")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام کاربری")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string Username { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "رمز")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string Password { get; set; }
        public int UserPassId { get; set; }
    }
}
