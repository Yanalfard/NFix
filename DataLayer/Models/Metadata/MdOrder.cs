using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdOrder
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "جمع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long Sum { get; set; }

        [Display(Name = "پرداخت شده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsFInaly { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime Date { get; set; }

        public int? DiscountId { get; set; }
    }
}
