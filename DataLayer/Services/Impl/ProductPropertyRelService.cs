using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class ProductPropertyRelService : IProductPropertyRelService
    {
        public TblProductPropertyRel AddProductPropertyRel(TblProductPropertyRel productPropertyRel)
        {
            return new ProductPropertyRelRepo().Add(productPropertyRel);
        }
        public bool DeleteProductPropertyRel(int id)
        {
            return new ProductPropertyRelRepo().Delete<TblProductPropertyRel>(id);
        }
        public bool UpdateProductPropertyRel(TblProductPropertyRel productPropertyRel, int logId)
        {
            return new ProductPropertyRelRepo().Update(productPropertyRel, logId);
        }
        public List<TblProductPropertyRel> SelectAllProductPropertyRels()
        {
            return new ProductPropertyRelRepo().SelectAll<TblProductPropertyRel>().Cast<TblProductPropertyRel>().ToList();
        }
        public TblProductPropertyRel SelectProductPropertyRelById(int id)
        {
            return new ProductPropertyRelRepo().SelectById<TblProductPropertyRel>(id);
        }
        public List<TblProductPropertyRel> SelectProductPropertyRelByProductId(int productId)
        {
            return new ProductPropertyRelRepo().SelectProductPropertyRelByProductId(productId);
        }
        public List<TblProductPropertyRel> SelectProductPropertyRelByPropertyId(int propertyId)
        {
            return new ProductPropertyRelRepo().SelectProductPropertyRelByPropertyId(propertyId);
        }

    }
}