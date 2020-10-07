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

        public TblBlogCommentRel ToRegular()
        {
            return new TblBlogCommentRel();
        }

        public DtoTblBlogCommentRel(TblBlogCommentRel blogCommentRel)
        {
            Blog = blogCommentRel.TblBlog;
            Comment = blogCommentRel.TblComment;
            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblBlogCommentRel(TblBlogCommentRel blogCommentRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblBlogCommentRel()
        {
        }
    }
}