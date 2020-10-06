using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class DiscountService : IDiscountService
    {
        public bool AddDiscount(TblDiscount discount)
        {
            return new DiscountRepo().Add(discount);
        }
        public bool DeleteDiscount(int id)
        {
            return new DiscountRepo().Delete<TblDiscount>(id);
        }
        public bool UpdateDiscount(TblDiscount discount, int logId)
        {
            return new DiscountRepo().Update(discount, logId);
        }
        public List<TblDiscount> SelectAllDiscounts()
        {
            return new DiscountRepo().SelectAll<TblDiscount>().Cast<TblDiscount>().ToList();
        }
        public TblDiscount SelectDiscountById(int id)
        {
            return new DiscountRepo().SelectById<TblDiscount>(id);
        }
        public TblDiscount SelectDiscountByName(string name)
        {
            return new DiscountRepo().SelectDiscountByName(name);
        }

    }
}