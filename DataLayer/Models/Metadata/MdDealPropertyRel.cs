using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdDealPropertyRel
    {
        [Key]
        public int id { get; set; }
        public int DealId { get; set; }
        public int PropertyId { get; set; }
    }
}
