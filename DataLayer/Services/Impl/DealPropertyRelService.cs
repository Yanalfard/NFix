using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class DealPropertyRelService : IDealPropertyRelService
    {
        public bool AddDealPropertyRel(TblDealPropertyRel dealPropertyRel)
        {
            return new DealPropertyRelRepo().Add(dealPropertyRel);
        }
        public bool DeleteDealPropertyRel(int id)
        {
            return new DealPropertyRelRepo().Delete<TblDealPropertyRel>(id);
        }
        public bool UpdateDealPropertyRel(TblDealPropertyRel dealPropertyRel, int logId)
        {
            return new DealPropertyRelRepo().Update(dealPropertyRel, logId);
        }
        public List<TblDealPropertyRel> SelectAllDealPropertyRels()
        {
            return new DealPropertyRelRepo().SelectAll<TblDealPropertyRel>().Cast<TblDealPropertyRel>().ToList();
        }
        public TblDealPropertyRel SelectDealPropertyRelById(int id)
        {
            return new DealPropertyRelRepo().SelectById<TblDealPropertyRel>(id);
        }
        public List<TblDealPropertyRel> SelectDealPropertyRelByDealId(int dealId)
        {
            return new DealPropertyRelRepo().SelectDealPropertyRelByDealId(dealId);
        }
        public List<TblDealPropertyRel> SelectDealPropertyRelByPropertyId(int propertyId)
        {
            return new DealPropertyRelRepo().SelectDealPropertyRelByPropertyId(propertyId);
        }

    }
}