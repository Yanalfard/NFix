using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;

namespace DataLayer.Services.Api
{
    public interface IClientService : IClientRepo
    {
        List<TblProduct>SelectProductsByClientId(int clientId);

    }
}