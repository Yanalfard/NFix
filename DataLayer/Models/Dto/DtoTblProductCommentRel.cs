using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblProductCommentRel : TblProductCommentRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblProductCommentRel ToRegular()
        {
            return new TblProductCommentRel();
        }

        public DtoTblProductCommentRel(TblProductCommentRel productCommentRel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblProductCommentRel(TblProductCommentRel productCommentRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblProductCommentRel()
        {
        }
    }
}