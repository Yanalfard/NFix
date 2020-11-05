using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdVideo
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "ویدیو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string VideoUrl { get; set; }

        [Display(Name = "دمو ویدیو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string VidioDemoUrl { get; set; }

        [Display(Name = "عکس اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string MainImage { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "توضیحات دمو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string DescriptionDemo { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime DateSubmited { get; set; }

        public bool IsOnline { get; set; }

        public int ViewCount { get; set; }

        [Display(Name = "آیا در خانه است؟")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsHome { get; set; }
        [Display(Name = "امتیاز")]
        public int Raiting { get; set; }

        public string ShareLink { get; set; }

        public int CatagoryId { get; set; }
    }
}
