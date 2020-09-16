using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class ProductKeywordRelService : IProductKeywordRelService
    {
        public TblProductKeywordRel AddProductKeywordRel(TblProductKeywordRel productKeywordRel)
        {
            return new ProductKeywordRelRepo().Add(productKeywordRel);
        }
        public bool DeleteProductKeywordRel(int id)
        {
            return new ProductKeywordRelRepo().Delete<TblProductKeywordRel>(id);
        }
        public bool UpdateProductKeywordRel(TblProductKeywordRel productKeywordRel, int logId)
        {
            return new ProductKeywordRelRepo().Update(productKeywordRel, logId);
        }
        public List<TblProductKeywordRel> SelectAllProductKeywordRels()
        {
            return new ProductKeywordRelRepo().SelectAll<TblProductKeywordRel>().Cast<TblProductKeywordRel>().ToList();
        }
        public TblProductKeywordRel SelectProductKeywordRelById(int id)
        {
            return new ProductKeywordRelRepo().SelectById<TblProductKeywordRel>(id);
        }
        public List<TblProductKeywordRel> SelectProductKeywordRelByProductId(int productId)
        {
            return new ProductKeywordRelRepo().SelectProductKeywordRelByProductId(productId);
        }
        public List<TblProductKeywordRel> SelectProductKeywordRelByKeywordId(int keywordId)
        {
            return new ProductKeywordRelRepo().SelectProductKeywordRelByKeywordId(keywordId);
        }

    }
}