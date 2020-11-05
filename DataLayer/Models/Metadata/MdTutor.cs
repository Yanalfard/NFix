using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdTutor
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

        [Display(Name = "عکس اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string MainImage { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        public int UserPassId { get; set; }

        [Display(Name = "تخصص")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Specialty { get; set; }
    }
}
