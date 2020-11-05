using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblTuotorVideoRel : Metadata.MdTuotorVideoRel
    {
        public virtual Metadata.MdTutor Tutor { get; set; }
        public virtual Metadata.MdVideo Video { get; set; }

        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public Metadata.MdTuotorVideoRel ToRegular()
        {
            return new Metadata.MdTuotorVideoRel();
        }

        public DtoTblTuotorVideoRel(Metadata.MdTuotorVideoRel tuotorVideoRel)
        {
            Tutor = tuotorVideoRel.TblTutor;
            Video = tuotorVideoRel.TblVideo;
            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblTuotorVideoRel(Metadata.MdTuotorVideoRel tuotorVideoRel, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblTuotorVideoRel()
        {
        }
    }
}