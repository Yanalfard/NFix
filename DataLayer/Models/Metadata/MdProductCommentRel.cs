using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdProductCommentRel
    {
        [Key]
        public int id { get; set; }
        public int ProductId { get; set; }
        public int CommentId { get; set; }
    }
}
