using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModel
{
    public class AdminViewModel
    {
        [Display(Name = "نام کاربری ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string UserName { get; set; }
        [Display(Name = "کلمه عبور فعلی")]
        public string OldPassword { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور جدید")]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }
        public int id { get; set; }
        public string Auth { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }

    }
}
