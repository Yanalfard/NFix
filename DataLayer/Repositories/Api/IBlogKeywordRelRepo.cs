using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IBlogKeywordRelRepo
    {
        List<TblBlogKeywordRel> SelectBlogKeywordRelByBlogId(int blogId);
        List<TblBlogKeywordRel> SelectBlogKeywordRelByKeywordId(int keywordId);

    }
}