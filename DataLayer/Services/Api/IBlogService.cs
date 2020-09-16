using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;

namespace DataLayer.Services.Api
{
    public interface IBlogService : IBlogRepo
    {
        List<TblComment>SelectCommentsByBlogId(int blogId);
        List<TblKeyword>SelectKeywordsByBlogId(int blogId);

    }
}