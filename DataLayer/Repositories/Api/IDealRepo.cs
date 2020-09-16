using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IDealRepo
    {
        TblDeal SelectDealByName(string name);
        List<TblDeal> SelectDealByIsValid(bool isValid);

    }
}