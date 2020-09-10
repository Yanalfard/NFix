using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblDealPropertyRel : TblDealPropertyRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblDealPropertyRel ToRegular()
        {
            return new TblDealPropertyRel();
        }

        public DtoTblDealPropertyRel(TblDealPropertyRel dealPropertyRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblDealPropertyRel(TblDealPropertyRel dealPropertyRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblDealPropertyRel()
        {
        }
    }
}