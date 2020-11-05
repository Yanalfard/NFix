using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdAd
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "لینک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Link { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Image { get; set; }
    }
}
