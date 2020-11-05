using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblDeal : Metadata.MdDeal
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public Metadata.MdDeal ToRegular()
        {
            return new Metadata.MdDeal();
        }

        public DtoTblDeal(Metadata.MdDeal deal)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblDeal(Metadata.MdDeal deal, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblDeal()
        {
        }
    }
}