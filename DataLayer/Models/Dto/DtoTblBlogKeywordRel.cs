using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblBlogKeywordRel : TblBlogKeywordRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblBlogKeywordRel ToRegular()
        {
            return new TblBlogKeywordRel();
        }

        public DtoTblBlogKeywordRel(TblBlogKeywordRel blogKeywordRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblBlogKeywordRel(TblBlogKeywordRel blogKeywordRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblBlogKeywordRel()
        {
        }
    }
}