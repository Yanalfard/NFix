using DataLayer.Models.Regular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Dto
{
    public class DtoTblVideoCommentRel : Metadata.MdVideoCommentRel
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public Metadata.MdVideoCommentRel ToRegular()
        {
            return new Metadata.MdVideoCommentRel();
        }

        public DtoTblVideoCommentRel(Metadata.MdVideoCommentRel rel)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblVideoCommentRel(Metadata.MdVideoCommentRel rel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblVideoCommentRel()
        {
        }
    }
}
