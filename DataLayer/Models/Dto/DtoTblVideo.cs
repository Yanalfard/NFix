using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblVideo : TblVideo
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblVideo ToRegular()
        {
            return new TblVideo();
        }

        public DtoTblVideo(TblVideo video)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblVideo(TblVideo video, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblVideo()
        {
        }
    }
}