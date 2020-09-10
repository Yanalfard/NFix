using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class ProductKeywordRelRepo : HeartRepo, IProductKeywordRelRepo
    {
        private MainProvider _main;
        public ProductKeywordRelRepo()
        {
            _main = new MainProvider();
        }
        public List<TblProductKeywordRel> SelectProductKeywordRelByProductId(int productId)
        {
            return _main.SelectProductKeywordRel(productId, MainProvider.ProductKeywordRel.ProductId);
        }
        public List<TblProductKeywordRel> SelectProductKeywordRelByKeywordId(int keywordId)
        {
            return _main.SelectProductKeywordRel(keywordId, MainProvider.ProductKeywordRel.KeywordId);
        }

    }
}