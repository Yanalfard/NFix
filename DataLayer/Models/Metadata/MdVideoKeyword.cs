using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdVideoKeyword
    {
        [Key]
        public int id { get; set; }

        public int VideoId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }
    }
}
