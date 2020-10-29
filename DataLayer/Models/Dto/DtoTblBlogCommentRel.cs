using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblBlogCommentRel : TblBlogCommentRel
    {
        public virtual TblBlog Blog { get; set; }
        public virtual TblComment Comment { get; set; }
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblVideoCommentRel ToRegular()
        {
            return new TblVideoCommentRel();
        }

        public DtoTblBlogCommentRel(TblBlogCommentRel VideoCommentRel)
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