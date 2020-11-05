using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblProductCommentRel : Metadata.MdProductCommentRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public Metadata.MdProductCommentRel ToRegular()
        {
            return new Metadata.MdProductCommentRel();
        }

        public DtoTblProductCommentRel(Metadata.MdProductCommentRel productCommentRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblProductCommentRel(Metadata.MdProductCommentRel productCommentRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblProductCommentRel()
        {
        }
    }
}