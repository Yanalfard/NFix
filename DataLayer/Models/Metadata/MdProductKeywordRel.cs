using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdProductKeywordRel
    {
        [Key]
        public int id { get; set; }
        public int ProductId { get; set; }
        public int KeywordId { get; set; }
    }
}
