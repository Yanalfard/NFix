using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdComment
    {
        [Key]
        public int id { get; set; }

        public int ClientId { get; set; }

        [Display(Name = "کامنت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Body { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime DateSubmited { get; set; }

        [Display(Name = "تایید شده؟")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsValid { get; set; }
    }
}
