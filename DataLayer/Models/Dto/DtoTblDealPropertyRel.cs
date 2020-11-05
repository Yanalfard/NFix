using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblDealPropertyRel : Metadata.MdDealPropertyRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public Metadata.MdDealPropertyRel ToRegular()
        {
            return new Metadata.MdDealPropertyRel();
        }

        public DtoTblDealPropertyRel(Metadata.MdDealPropertyRel dealPropertyRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblDealPropertyRel(Metadata.MdDealPropertyRel dealPropertyRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblDealPropertyRel()
        {
        }
    }
}