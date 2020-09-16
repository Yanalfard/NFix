using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class BlogCommentRelRepo : HeartRepo, IBlogCommentRelRepo
    {
        private MainProvider _main;
        public BlogCommentRelRepo()
        {
            _main = new MainProvider();
        }
        public List<TblBlogCommentRel> SelectBlogCommentRelByBlogId(int blogId)
        {
            return _main.SelectBlogCommentRel(blogId, MainProvider.BlogCommentRel.BlogId);
        }
        public List<TblBlogCommentRel> SelectBlogCommentRelByCommentId(int commentId)
        {
            return _main.SelectBlogCommentRel(commentId, MainProvider.BlogCommentRel.CommentId);
        }

    }
}