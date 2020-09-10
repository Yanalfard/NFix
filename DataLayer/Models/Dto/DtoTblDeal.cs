using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblDeal : TblDeal
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public TblDeal ToRegular()
        {
            return new TblDeal();
        }

        public DtoTblDeal(TblDeal deal)
        {

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblDeal(TblDeal deal, HttpStatusCode statusEffect, string errorStr)
        {

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblDeal()
        {
        }
    }
}