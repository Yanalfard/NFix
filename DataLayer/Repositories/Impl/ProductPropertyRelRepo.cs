using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class ProductPropertyRelRepo : HeartRepo, IProductPropertyRelRepo
    {
        private MainProvider _main;
        public ProductPropertyRelRepo()
        {
            _main = new MainProvider();
        }
        public List<TblProductPropertyRel> SelectProductPropertyRelByProductId(int productId)
        {
            return _main.SelectProductPropertyRel(productId, MainProvider.ProductPropertyRel.ProductId);
        }
        public List<TblProductPropertyRel> SelectProductPropertyRelByPropertyId(int propertyId)
        {
            return _main.SelectProductPropertyRel(propertyId, MainProvider.ProductPropertyRel.PropertyId);
        }

    }
}