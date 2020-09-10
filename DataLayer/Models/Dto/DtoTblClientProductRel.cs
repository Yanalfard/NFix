using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblClientProductRel : TblClientProductRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblClientProductRel ToRegular()
        {
            return new TblClientProductRel();
        }

        public DtoTblClientProductRel(TblClientProductRel clientProductRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblClientProductRel(TblClientProductRel clientProductRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblClientProductRel()
        {
        }
    }
}