using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblProductPropertyRel : TblProductPropertyRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblProductPropertyRel ToRegular()
        {
            return new TblProductPropertyRel();
        }

        public DtoTblProductPropertyRel(TblProductPropertyRel productPropertyRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblProductPropertyRel(TblProductPropertyRel productPropertyRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblProductPropertyRel()
        {
        }
    }
}