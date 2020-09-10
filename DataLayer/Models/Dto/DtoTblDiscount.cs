using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblDiscount : TblDiscount
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public DtoTblDiscount(TblDiscount discount)
        {
            id = discount.id;
            Name = discount.Name;
            Discount = discount.Discount;
            Count = discount.Count;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblDiscount(TblDiscount discount, HttpStatusCode statusEffect, string errorStr)
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