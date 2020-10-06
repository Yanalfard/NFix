using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class BlogCommentRelService : IBlogCommentRelService
    {
        public bool AddBlogCommentRel(TblBlogCommentRel blogCommentRel)
        {
            return new BlogCommentRelRepo().Add(blogCommentRel);
        }
        public bool DeleteBlogCommentRel(int id)
        {
            return new BlogCommentRelRepo().Delete<TblBlogCommentRel>(id);
        }
        public bool UpdateBlogCommentRel(TblBlogCommentRel blogCommentRel, int logId)
        {
            return new BlogCommentRelRepo().Update(blogCommentRel, logId);
        }
        public List<TblBlogCommentRel> SelectAllBlogCommentRels()
        {
            return new BlogCommentRelRepo().SelectAll<TblBlogCommentRel>().Cast<TblBlogCommentRel>().ToList();
        }
        public TblBlogCommentRel SelectBlogCommentRelById(int id)
        {
            return new BlogCommentRelRepo().SelectById<TblBlogCommentRel>(id);
        }
        public List<TblBlogCommentRel> SelectBlogCommentRelByBlogId(int blogId)
        {
            return new BlogCommentRelRepo().SelectBlogCommentRelByBlogId(blogId);
        }
        public List<TblBlogCommentRel> SelectBlogCommentRelByCommentId(int commentId)
        {
            return new BlogCommentRelRepo().SelectBlogCommentRelByCommentId(commentId);
        }

    }
}