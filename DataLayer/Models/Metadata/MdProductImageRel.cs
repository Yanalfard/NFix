using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdProductImageRel
    {
        [Key]
        public int id { get; set; }
        public int ProductId { get; set; }
        public int ImageId { get; set; }
    }
}
