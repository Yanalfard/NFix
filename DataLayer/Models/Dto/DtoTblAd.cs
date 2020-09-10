using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblAd : TblAd
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public DtoTblAd(TblAd ad)
        {
            id = ad.id;
            Link = ad.Link;
            Image = ad.Image;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblAd(TblAd ad, HttpStatusCode statusEffect, string errorStr)
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