using System.Collections.Generic;
using System.Linq;
using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblVideo : TblVideo
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public virtual List<TblTuotorVideoRel> TuotorVideoRel { get; set; }
        public string TuotorName { get; set; }

        public TblVideo ToRegular()
        {
            return new TblVideo();
        }

        public DtoTblVideo(TblVideo video)
        {
            id = video.id;
            VideoUrl = video.VideoUrl;
            VidioDemoUrl = video.VidioDemoUrl;
            MainImage = video.MainImage;
            Title = video.Title;
            Description = video.Description;
            DescriptionDemo = video.DescriptionDemo;
            DateSubmited = video.DateSubmited;
            IsOnline = video.IsOnline;
            ViewCount = video.ViewCount;
            IsHome = video.IsHome;
            Raiting = video.Raiting;
            ShareLink = video.ShareLink;
            TuotorVideoRel = video.TblTuotorVideoRel.ToList();
            try
            {
                TuotorName = new NFixEntities().TblVideo.SingleOrDefault(i => i.id == video.id).TblTuotorVideoRel.FirstOrDefault().TblTutor.Name;
            }
            catch
            {
                TuotorName = "";
            }
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