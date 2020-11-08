using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModel
{
    public class UserViewModel
    {
        public int id { get; set; }
        public int UserPassId { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string Name { get; set; }
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [MaxLength(11, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        [DataType(DataType.PhoneNumber)]
        public string TellNo { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string UserName { get; set; }
        [Display(Name = "رمز")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(10, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string IdentificationNo { get; set; }
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        [EmailAddress(ErrorMessage ="لطفا ایمیل خود را وارد کنید")]
        public string Email { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public bool IsPremium { get; set; }
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string PremiumTill { get; set; }
        [MaxLength(45, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string InviteCode { get; set; }
        [MaxLength(45, ErrorMessage = "تعداد کاراکتر بیشتر است")]
        public string PostalCode { get; set; }
    }
}
