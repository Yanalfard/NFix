using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class BlogService : IBlogService
    {
        public bool AddBlog(TblBlog blog)
        {
            return new BlogRepo().Add(blog);
        }
        public bool DeleteBlog(int id)
        {
            return new BlogRepo().Delete<TblBlog>(id);
        }
        public bool UpdateBlog(TblBlog blog, int logId)
        {
            return new BlogRepo().Update(blog, logId);
        }
        public List<TblBlog> SelectAllBlogs()
        {
            return new BlogRepo().SelectAll<TblBlog>().Cast<TblBlog>().ToList();
        }
        public TblBlog SelectBlogById(int id)
        {
            return new BlogRepo().SelectById<TblBlog>(id);
        }
        public List<TblComment>SelectCommentsByBlogId(int blogId)
        {
            List<TblBlogCommentRel> stp1 = new BlogCommentRelRepo().SelectBlogCommentRelByBlogId(blogId);
            List<TblComment> stp2 = new List<TblComment>();
            foreach (TblBlogCommentRel rel in stp1)
                stp2.Add(new CommentRepo().SelectById<TblComment>(rel.CommentId));
            return stp2;
        }
        public List<TblKeyword>SelectKeywordsByBlogId(int blogId)
        {
            List<TblBlogKeywordRel> stp1 = new BlogKeywordRelRepo().SelectBlogKeywordRelByBlogId(blogId);
            List<TblKeyword> stp2 = new List<TblKeyword>();
            foreach (TblBlogKeywordRel rel in stp1)
                stp2.Add(new KeywordRepo().SelectById<TblKeyword>(rel.KeywordId));
            return stp2;
        }

    }
}