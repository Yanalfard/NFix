using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdLog
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "لاگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string LogText { get; set; }

        [Display(Name = "رقم جابجا شده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long MoneyTransfered { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime Date { get; set; }
    }
}
