using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModel
{
    public class ActiveViewModel
    {
        public string id { get; set; }
       
    }
    public class LoginViewModel
    {
        public int id { get; set; }
        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }
        [Display(Name = "نام کاربری ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string UserName { get; set; }
        [Display(Name = "کد واژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class RegisViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.PhoneNumber)]
        public string TellNo { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نیست")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string Email { get; set; }
        [Display(Name = "نام کاربری ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string UserName { get; set; }
        [Display(Name = "کد واژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار کد واژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }
    }
    public class RegisterViewModel
    {
        public int id { get; set; }
        [Display(Name = "نام")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        public string Name { get; set; }
        [Display(Name = "کد ملی")]
        public string IdentificationNo { get; set; }
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.PhoneNumber)]
        public string TellNo { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نیست")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }
        public string PostalCode { get; set; }
        [Display(Name = "نام کاربری ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string UserName { get; set; }
        [Display(Name = "کد واژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار کد واژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }
        public int UserPassId { get; set; }
        public int Status { get; set; }
        public bool IsPremium { get; set; }
        public string PremiumTill { get; set; }
        public string InviteCode { get; set; }
    } 
    public class ForgotPasswordViewModel
    {
        [Display(Name = "نام کابری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }
    }

    public class RecoveryPasswordViewModel
    {
        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Display(Name = "کلمه عبور فعلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }
    }


    public class ChangePasswordUserTutorViewModel
    {

        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }
    }
}
