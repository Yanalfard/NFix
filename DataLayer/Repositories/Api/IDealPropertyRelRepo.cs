using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IDealPropertyRelRepo
    {
        List<TblDealPropertyRel> SelectDealPropertyRelByDealId(int dealId);
        List<TblDealPropertyRel> SelectDealPropertyRelByPropertyId(int propertyId);

    }
}