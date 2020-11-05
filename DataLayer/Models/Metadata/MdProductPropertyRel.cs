using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdProductPropertyRel
    {
        [Key]
        public int id { get; set; }
        public int ProductId { get; set; }
        public int PropertyId { get; set; }
    }
}
