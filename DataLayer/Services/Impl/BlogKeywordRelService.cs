using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class BlogKeywordRelService : IBlogKeywordRelService
    {
        public bool AddBlogKeywordRel(TblBlogKeywordRel blogKeywordRel)
        {
            return new BlogKeywordRelRepo().Add(blogKeywordRel);
        }
        public bool DeleteBlogKeywordRel(int id)
        {
            return new BlogKeywordRelRepo().Delete<TblBlogKeywordRel>(id);
        }
        public bool UpdateBlogKeywordRel(TblBlogKeywordRel blogKeywordRel, int logId)
        {
            return new BlogKeywordRelRepo().Update(blogKeywordRel, logId);
        }
        public List<TblBlogKeywordRel> SelectAllBlogKeywordRels()
        {
            return new BlogKeywordRelRepo().SelectAll<TblBlogKeywordRel>().Cast<TblBlogKeywordRel>().ToList();
        }
        public TblBlogKeywordRel SelectBlogKeywordRelById(int id)
        {
            return new BlogKeywordRelRepo().SelectById<TblBlogKeywordRel>(id);
        }
        public List<TblBlogKeywordRel> SelectBlogKeywordRelByBlogId(int blogId)
        {
            return new BlogKeywordRelRepo().SelectBlogKeywordRelByBlogId(blogId);
        }
        public List<TblBlogKeywordRel> SelectBlogKeywordRelByKeywordId(int keywordId)
        {
            return new BlogKeywordRelRepo().SelectBlogKeywordRelByKeywordId(keywordId);
        }

    }
}