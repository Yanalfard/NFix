using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IProductRepo
    {
        TblProduct SelectProductByName(string name);
        List<TblProduct> SelectProductByCatagoryId(int catagoryId);
        List<TblProduct> SelectProductByIsSuggested(bool isSuggested);

    }
}