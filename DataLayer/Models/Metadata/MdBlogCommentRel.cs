using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdBlogCommentRel
    {
        [Key]
        public int id { get; set; }
        public int BlogId { get; set; }
        public int CommentId { get; set; }
    }
}
