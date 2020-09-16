using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IProductImageRelRepo
    {
        List<TblProductImageRel> SelectProductImageRelByProductId(int productId);
        List<TblProductImageRel> SelectProductImageRelByImageId(int imageId);

    }
}