using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblKeyword : TblKeyword
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public DtoTblKeyword(TblKeyword keyword)
        {
            id = keyword.id;
            Name = keyword.Name;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblKeyword(TblKeyword keyword, HttpStatusCode statusEffect, string errorStr)
        {
            id = keyword.id;
            Name = keyword.Name;

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblKeyword()
        {
        }
    }
}