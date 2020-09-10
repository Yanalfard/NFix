using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IProductKeywordRelRepo
    {
        List<TblProductKeywordRel> SelectProductKeywordRelByProductId(int productId);
        List<TblProductKeywordRel> SelectProductKeywordRelByKeywordId(int keywordId);

    }
}