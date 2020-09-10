using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;

namespace DataLayer.Services.Api
{
    public interface IProductService : IProductRepo
    {
        List<TblComment>SelectCommentsByProductId(int productId);
        List<TblImage>SelectImagesByProductId(int productId);
        List<TblKeyword>SelectKeywordsByProductId(int productId);
        List<TblProperty>SelectPropertysByProductId(int productId);

    }
}