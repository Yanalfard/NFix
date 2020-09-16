using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;

namespace DataLayer.Services.Api
{
    public interface IDealService : IDealRepo
    {
        List<TblProperty>SelectPropertysByDealId(int dealId);

    }
}