using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdVideoCommentRel
    {
        [Key]
        public int id { get; set; }
        public int VideoId { get; set; }
        public int CommentId { get; set; }

    }
}
