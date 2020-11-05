using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblBlogKeywordRel : Metadata.MdBlogKeywordRel
    {
        public virtual Metadata.MdBlog Blog { get; set; }
        public virtual Metadata.MdKeyword Keyword { get; set; }
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public Metadata.MdBlogKeywordRel ToRegular()
        {
            return new Metadata.MdBlogKeywordRel();
        }

        public DtoTblBlogKeywordRel(Metadata.MdBlogKeywordRel blogKeywordRel)
        {
            Blog = blogKeywordRel.TblBlog;
            Keyword = blogKeywordRel.TblKeyword;
            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblBlogKeywordRel(Metadata.MdBlogKeywordRel blogKeywordRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblBlogKeywordRel()
        {
        }
    }
}