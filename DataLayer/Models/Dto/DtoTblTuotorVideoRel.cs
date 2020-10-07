using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblTuotorVideoRel : TblTuotorVideoRel
    {
        public virtual TblTutor Tutor { get; set; }
        public virtual TblVideo Video { get; set; }

        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblTuotorVideoRel ToRegular()
        {
            return new TblTuotorVideoRel();
        }

        public DtoTblTuotorVideoRel(TblTuotorVideoRel tuotorVideoRel)
        {
            Tutor = tuotorVideoRel.TblTutor;
            Video = tuotorVideoRel.TblVideo;
            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblTuotorVideoRel(TblTuotorVideoRel tuotorVideoRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblTuotorVideoRel()
        {
        }
    }
}