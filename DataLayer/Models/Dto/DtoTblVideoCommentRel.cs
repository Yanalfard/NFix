using DataLayer.Models.Regular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Dto
{
    public class DtoTblVideoCommentRel : TblVideoCommentRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblVideoCommentRel ToRegular()
        {
            return new TblVideoCommentRel();
        }

        public DtoTblVideoCommentRel(TblVideoCommentRel rel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblVideoCommentRel(TblVideoCommentRel rel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblVideoCommentRel()
        {
        }
    }
}
