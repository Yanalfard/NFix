using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblDiscount : Metadata.MdDiscount
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public DtoTblDiscount(Metadata.MdDiscount discount)
        {
            id = discount.id;
            Name = discount.Name;
            Discount = discount.Discount;
            Count = discount.Count;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblDiscount(Metadata.MdDiscount discount, HttpStatusCode statusEffect, string errorStr)
        {
            id = discount.id;
            Name = discount.Name;
            Discount = discount.Discount;
            Count = discount.Count;

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblDiscount()
        {
        }
    }
}