using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblClientProductRel : Metadata.MdClientProductRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public Metadata.MdClientProductRel ToRegular()
        {
            return new Metadata.MdClientProductRel();
        }

        public DtoTblClientProductRel(Metadata.MdClientProductRel clientProductRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblClientProductRel(Metadata.MdClientProductRel clientProductRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblClientProductRel()
        {
        }
    }
}