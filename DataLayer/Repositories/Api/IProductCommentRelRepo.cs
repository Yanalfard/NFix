using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IProductCommentRelRepo
    {
        List<TblProductCommentRel> SelectProductCommentRelByProductId(int productId);
        List<TblProductCommentRel> SelectProductCommentRelByCommentId(int commentId);

    }
}