using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class ProductImageRelService : IProductImageRelService
    {
        public bool AddProductImageRel(TblProductImageRel productImageRel)
        {
            return new ProductImageRelRepo().Add(productImageRel);
        }
        public bool DeleteProductImageRel(int id)
        {
            return new ProductImageRelRepo().Delete<TblProductImageRel>(id);
        }
        public bool UpdateProductImageRel(TblProductImageRel productImageRel, int logId)
        {
            return new ProductImageRelRepo().Update(productImageRel, logId);
        }
        public List<TblProductImageRel> SelectAllProductImageRels()
        {
            return new ProductImageRelRepo().SelectAll<TblProductImageRel>().Cast<TblProductImageRel>().ToList();
        }
        public TblProductImageRel SelectProductImageRelById(int id)
        {
            return new ProductImageRelRepo().SelectById<TblProductImageRel>(id);
        }
        public List<TblProductImageRel> SelectProductImageRelByProductId(int productId)
        {
            return new ProductImageRelRepo().SelectProductImageRelByProductId(productId);
        }
        public List<TblProductImageRel> SelectProductImageRelByImageId(int imageId)
        {
            return new ProductImageRelRepo().SelectProductImageRelByImageId(imageId);
        }

    }
}