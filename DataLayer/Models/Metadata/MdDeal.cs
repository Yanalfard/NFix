using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdDeal
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "طول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Length { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long Price { get; set; }

        [Display(Name = "تایید شده؟")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsValid { get; set; }
    }
}
