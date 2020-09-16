using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class ProductCommentRelRepo : HeartRepo, IProductCommentRelRepo
    {
        private MainProvider _main;
        public ProductCommentRelRepo()
        {
            _main = new MainProvider();
        }
        public List<TblProductCommentRel> SelectProductCommentRelByProductId(int productId)
        {
            return _main.SelectProductCommentRel(productId, MainProvider.ProductCommentRel.ProductId);
        }
        public List<TblProductCommentRel> SelectProductCommentRelByCommentId(int commentId)
        {
            return _main.SelectProductCommentRel(commentId, MainProvider.ProductCommentRel.CommentId);
        }

    }
}