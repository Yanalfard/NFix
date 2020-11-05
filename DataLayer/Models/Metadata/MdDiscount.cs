using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdDiscount
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Discount { get; set; }

        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Count { get; set; }
    }
}
