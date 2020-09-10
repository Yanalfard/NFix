using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class BlogKeywordRelRepo : HeartRepo, IBlogKeywordRelRepo
    {
        private MainProvider _main;
        public BlogKeywordRelRepo()
        {
            _main = new MainProvider();
        }
        public List<TblBlogKeywordRel> SelectBlogKeywordRelByBlogId(int blogId)
        {
            return _main.SelectBlogKeywordRel(blogId, MainProvider.BlogKeywordRel.BlogId);
        }
        public List<TblBlogKeywordRel> SelectBlogKeywordRelByKeywordId(int keywordId)
        {
            return _main.SelectBlogKeywordRel(keywordId, MainProvider.BlogKeywordRel.KeywordId);
        }

    }
}