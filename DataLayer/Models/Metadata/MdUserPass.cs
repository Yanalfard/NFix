
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdUserPass
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Username { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }

        public string Auth { get; set; }

        [Display(Name = "فعال؟")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsActive { get; set; }

        public int RoleId { get; set; }

    }
}
