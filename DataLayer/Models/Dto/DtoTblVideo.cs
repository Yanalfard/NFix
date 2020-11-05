using System.Collections.Generic;
using System.Linq;
using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblVideo : Metadata.MdVideo
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public virtual List<Metadata.MdTuotorVideoRel> TuotorVideoRel { get; set; }
        public string TuotorName { get; set; }

        public Metadata.MdVideo ToRegular()
        {
            return new Metadata.MdVideo();
        }

        public DtoTblVideo(Metadata.MdVideo video)
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

        public DtoTblVideo(Metadata.MdVideo video, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblVideo()
        {
        }
    }
}