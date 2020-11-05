using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdBlogKeywordRel
    {
        [Key]
        public int id { get; set; }
        public int BlogId { get; set; }
        public int KeywordId { get; set; }
    }
}
