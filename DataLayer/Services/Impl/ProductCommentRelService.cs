using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class ProductCommentRelService : IProductCommentRelService
    {
        public TblProductCommentRel AddProductCommentRel(TblProductCommentRel productCommentRel)
        {
            return new ProductCommentRelRepo().Add(productCommentRel);
        }
        public bool DeleteProductCommentRel(int id)
        {
            return new ProductCommentRelRepo().Delete<TblProductCommentRel>(id);
        }
        public bool UpdateProductCommentRel(TblProductCommentRel productCommentRel, int logId)
        {
            return new ProductCommentRelRepo().Update(productCommentRel, logId);
        }
        public List<TblProductCommentRel> SelectAllProductCommentRels()
        {
            return new ProductCommentRelRepo().SelectAll<TblProductCommentRel>().Cast<TblProductCommentRel>().ToList();
        }
        public TblProductCommentRel SelectProductCommentRelById(int id)
        {
            return new ProductCommentRelRepo().SelectById<TblProductCommentRel>(id);
        }
        public List<TblProductCommentRel> SelectProductCommentRelByProductId(int productId)
        {
            return new ProductCommentRelRepo().SelectProductCommentRelByProductId(productId);
        }
        public List<TblProductCommentRel> SelectProductCommentRelByCommentId(int commentId)
        {
            return new ProductCommentRelRepo().SelectProductCommentRelByCommentId(commentId);
        }

    }
}