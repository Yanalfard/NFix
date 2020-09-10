using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class DealService : IDealService
    {
        public TblDeal AddDeal(TblDeal deal)
        {
            return new DealRepo().Add(deal);
        }
        public bool DeleteDeal(int id)
        {
            return new DealRepo().Delete<TblDeal>(id);
        }
        public bool UpdateDeal(TblDeal deal, int logId)
        {
            return new DealRepo().Update(deal, logId);
        }
        public List<TblDeal> SelectAllDeals()
        {
            return new DealRepo().SelectAll<TblDeal>().Cast<TblDeal>().ToList();
        }
        public TblDeal SelectDealById(int id)
        {
            return new DealRepo().SelectById<TblDeal>(id);
        }
        public TblDeal SelectDealByName(string name)
        {
            return new DealRepo().SelectDealByName(name);
        }
        public List<TblDeal> SelectDealByIsValid(bool isValid)
        {
            return new DealRepo().SelectDealByIsValid(isValid);
        }
        public List<TblProperty>SelectPropertysByDealId(int dealId)
        {
            List<TblDealPropertyRel> stp1 = new DealPropertyRelRepo().SelectDealPropertyRelByDealId(dealId);
            List<TblProperty> stp2 = new List<TblProperty>();
            foreach (TblDealPropertyRel rel in stp1)
                stp2.Add(new PropertyRepo().SelectById<TblProperty>(rel.PropertyId));
            return stp2;
        }

    }
}