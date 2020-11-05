using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdBlog
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "عکس اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string MainImage { get; set; }

        [Display(Name = "توضیحات اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Body { get; set; }

        [Display(Name = "توضیحات مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "تعداد لایک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int LikeCount { get; set; }
        
    }
}
