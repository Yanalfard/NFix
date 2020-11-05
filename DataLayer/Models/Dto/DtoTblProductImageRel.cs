using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblProductImageRel : Metadata.MdProductImageRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public Metadata.MdProductImageRel ToRegular()
        {
            return new Metadata.MdProductImageRel();
        }

        public DtoTblProductImageRel(Metadata.MdProductImageRel productImageRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblProductImageRel(Metadata.MdProductImageRel productImageRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblProductImageRel()
        {
        }
    }
}