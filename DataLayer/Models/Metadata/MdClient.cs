using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdClient
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string IdentificationNo { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string TellNo { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Address { get; set; }

        [Display(Name = "کد پستی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PostalCode { get; set; }

        public int UserPassId { get; set; }

        public int Status { get; set; }

        [Display(Name = "ویژه؟")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsPremium { get; set; }

        [Display(Name = "کاربر ویژه تا تاریخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PremiumTill { get; set; }

        public string InviteCode { get; set; }
    }
}
