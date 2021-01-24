using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataLayer.Models.Regular;

namespace DataLayer.ViewModel
{
    public class LiveShowCaseViewModel
    {
        [Display(Name = "کد")]
        public int id { get; set; }
        [Display(Name = "تیتر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [Display(Name = "کانال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.Text)]
        public string Chanel { get; set; }
        [Display(Name = "عکس")]
        public string MainImage { get; set; }
        [Display(Name = "توضیحات مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.MultilineText)]
        public string DescriptionShort { get; set; }
        [Display(Name = "توضیحات کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string DescriptionLong { get; set; }
        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.DateTime)]
        public DateTime TimeStart { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.Text)]
        public long Price { get; set; }
        [Display(Name = "خانه؟")]
        public bool IsHome { get; set; }
        [Display(Name = "نام مربی")]
        [DataType(DataType.Text)]
        public string ToutorName { get; set; }

        public LiveShowCaseViewModel(TblLive live)
        {
            id = live.id;
            Title = live.Title;
            Chanel = live.Chanel;
            MainImage = live.MainImage;
            DescriptionShort = live.DescriptionShort;
            DescriptionLong = live.DescriptionLong;
            TimeStart = live.TimeStart;
            Price = live.Price ?? 0;
            IsHome = live.IsHome;
            ToutorName = new Services.Impl.TutorService().SelectTutorById(live.ToutorId).Name;
        }

        public LiveShowCaseViewModel()
        {

        }
    }
}
