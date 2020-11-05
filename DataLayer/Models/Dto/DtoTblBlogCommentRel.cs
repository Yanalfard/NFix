using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblBlogCommentRel : Metadata.MdBlogCommentRel
    {
        public virtual Metadata.MdBlog Blog { get; set; }
        public virtual Metadata.MdComment Comment { get; set; }
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public Metadata.MdVideoCommentRel ToRegular()
        {
            return new Metadata.MdVideoCommentRel();
        }

        public DtoTblBlogCommentRel(Metadata.MdBlogCommentRel VideoCommentRel)
        {
            Blog = VideoCommentRel.TblBlog;
            Comment = VideoCommentRel.TblComment;
            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblBlogCommentRel(DtoTblBlogCommentRel VideoCommentRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblBlogCommentRel()
        {
        }
    }
}