using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblAd : Metadata.MdAd
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public DtoTblAd(Metadata.MdAd ad)
        {
            id = ad.id;
            Link = ad.Link;
            Image = ad.Image;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblAd(Metadata.MdAd ad, HttpStatusCode statusEffect, string errorStr)
        {
            id = ad.id;
            Link = ad.Link;
            Image = ad.Image;

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblAd()
        {
        }
    }
}