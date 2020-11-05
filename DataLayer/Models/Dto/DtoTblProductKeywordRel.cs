using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblProductKeywordRel : Metadata.MdProductKeywordRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public Metadata.MdProductKeywordRel ToRegular()
        {
            return new Metadata.MdProductKeywordRel();
        }

        public DtoTblProductKeywordRel(Metadata.MdProductKeywordRel productKeywordRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblProductKeywordRel(Metadata.MdProductKeywordRel productKeywordRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblProductKeywordRel()
        {
        }
    }
}