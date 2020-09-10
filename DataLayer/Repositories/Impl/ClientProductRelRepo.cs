using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class ClientProductRelRepo : HeartRepo, IClientProductRelRepo
    {
        private MainProvider _main;
        public ClientProductRelRepo()
        {
            _main = new MainProvider();
        }
        public List<TblClientProductRel> SelectClientProductRelByClientId(int clientId)
        {
            return _main.SelectClientProductRel(clientId, MainProvider.ClientProductRel.ClientId);
        }
        public List<TblClientProductRel> SelectClientProductRelByProductId(int productId)
        {
            return _main.SelectClientProductRel(productId, MainProvider.ClientProductRel.ProductId);
        }
        public List<TblClientProductRel> SelectClientProductRelByDate(int date)
        {
            return _main.SelectClientProductRel(date, MainProvider.ClientProductRel.Date);
        }
        public List<TblClientProductRel> SelectClientProductRelByCount(int count)
        {
            return _main.SelectClientProductRel(count, MainProvider.ClientProductRel.Count);
        }

    }
}