using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblProperty : Metadata.MdProperty
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public DtoTblProperty(Metadata.MdProperty property)
        {
            id = property.id;
            Name = property.Name;
            Description = property.Description;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblProperty(Metadata.MdProperty property, HttpStatusCode statusEffect, string errorStr)
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