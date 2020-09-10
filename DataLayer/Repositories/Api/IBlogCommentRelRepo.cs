using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IBlogCommentRelRepo
    {
        List<TblBlogCommentRel> SelectBlogCommentRelByBlogId(int blogId);
        List<TblBlogCommentRel> SelectBlogCommentRelByCommentId(int commentId);

    }
}