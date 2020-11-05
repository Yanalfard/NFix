using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblProductPropertyRel : Metadata.MdProductPropertyRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public Metadata.MdProductPropertyRel ToRegular()
        {
            return new Metadata.MdProductPropertyRel();
        }

        public DtoTblProductPropertyRel(Metadata.MdProductPropertyRel productPropertyRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblProductPropertyRel(Metadata.MdProductPropertyRel productPropertyRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblProductPropertyRel()
        {
        }
    }
}