using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblProductKeywordRel : TblProductKeywordRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblProductKeywordRel ToRegular()
        {
            return new TblProductKeywordRel();
        }

        public DtoTblProductKeywordRel(TblProductKeywordRel productKeywordRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblProductKeywordRel(TblProductKeywordRel productKeywordRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblProductKeywordRel()
        {
        }
    }
}