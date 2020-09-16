using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblImage : TblImage
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public DtoTblImage(TblImage image)
        {
            id = image.id;
            Image = image.Image;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblImage(TblImage image, HttpStatusCode statusEffect, string errorStr)
        {
            id = image.id;
            Image = image.Image;

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblImage()
        {
        }
    }
}