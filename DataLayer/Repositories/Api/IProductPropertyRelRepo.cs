using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IProductPropertyRelRepo
    {
        List<TblProductPropertyRel> SelectProductPropertyRelByProductId(int productId);
        List<TblProductPropertyRel> SelectProductPropertyRelByPropertyId(int propertyId);

    }
}