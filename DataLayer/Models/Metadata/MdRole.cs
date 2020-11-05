using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdRole
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "نام سیستمی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

    }
}
