using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdProduct
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime DateSubmited { get; set; }

        [Display(Name = "امتیاز")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Raiting { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long Price { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "توضیح کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string DescriptionHtml { get; set; }

        public int? CatagoryId { get; set; }

        [Display(Name = "تعداد")]
        public int? Count { get; set; }

        [Display(Name = "پیشنهادی؟")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsSuggested { get; set; }

        [Display(Name = "تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Discount { get; set; }

        public int Status { get; set; }
    }
}
