using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdClientProductRel
    {
        [Key]
        public int id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
    }
}
