using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class DealPropertyRelRepo : HeartRepo, IDealPropertyRelRepo
    {
        private MainProvider _main;
        public DealPropertyRelRepo()
        {
            _main = new MainProvider();
        }
        public List<TblDealPropertyRel> SelectDealPropertyRelByDealId(int dealId)
        {
            return _main.SelectDealPropertyRel(dealId, MainProvider.DealPropertyRel.DealId);
        }
        public List<TblDealPropertyRel> SelectDealPropertyRelByPropertyId(int propertyId)
        {
            return _main.SelectDealPropertyRel(propertyId, MainProvider.DealPropertyRel.PropertyId);
        }

    }
}