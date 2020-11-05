using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblKeyword : Metadata.MdKeyword
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public DtoTblKeyword(Metadata.MdKeyword keyword)
        {
            id = keyword.id;
            Name = keyword.Name;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblKeyword(Metadata.MdKeyword keyword, HttpStatusCode statusEffect, string errorStr)
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