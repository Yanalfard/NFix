using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IClientProductRelRepo
    {
        List<TblClientProductRel> SelectClientProductRelByClientId(int clientId);
        List<TblClientProductRel> SelectClientProductRelByProductId(int productId);
        List<TblClientProductRel> SelectClientProductRelByDate(int date);
        List<TblClientProductRel> SelectClientProductRelByCount(int count);

    }
}