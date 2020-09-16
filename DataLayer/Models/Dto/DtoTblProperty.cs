using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblProperty : TblProperty
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public DtoTblProperty(TblProperty property)
        {
            id = property.id;
            Name = property.Name;
            Description = property.Description;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblProperty(TblProperty property, HttpStatusCode statusEffect, string errorStr)
        {
            id = property.id;
            Name = property.Name;
            Description = property.Description;

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblProperty()
        {
        }
    }
}