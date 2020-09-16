using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblProductImageRel : TblProductImageRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblProductImageRel ToRegular()
        {
            return new TblProductImageRel();
        }

        public DtoTblProductImageRel(TblProductImageRel productImageRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblProductImageRel(TblProductImageRel productImageRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblProductImageRel()
        {
        }
    }
}