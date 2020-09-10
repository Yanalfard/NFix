using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class ProductImageRelRepo : HeartRepo, IProductImageRelRepo
    {
        private MainProvider _main;
        public ProductImageRelRepo()
        {
            _main = new MainProvider();
        }
        public List<TblProductImageRel> SelectProductImageRelByProductId(int productId)
        {
            return _main.SelectProductImageRel(productId, MainProvider.ProductImageRel.ProductId);
        }
        public List<TblProductImageRel> SelectProductImageRelByImageId(int imageId)
        {
            return _main.SelectProductImageRel(imageId, MainProvider.ProductImageRel.ImageId);
        }

    }
}