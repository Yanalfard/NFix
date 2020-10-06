using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class ClientProductRelService : IClientProductRelService
    {
        public bool AddClientProductRel(TblClientProductRel clientProductRel)
        {
            return new ClientProductRelRepo().Add(clientProductRel);
        }
        public bool DeleteClientProductRel(int id)
        {
            return new ClientProductRelRepo().Delete<TblClientProductRel>(id);
        }
        public bool UpdateClientProductRel(TblClientProductRel clientProductRel, int logId)
        {
            return new ClientProductRelRepo().Update(clientProductRel, logId);
        }
        public List<TblClientProductRel> SelectAllClientProductRels()
        {
            return new ClientProductRelRepo().SelectAll<TblClientProductRel>().Cast<TblClientProductRel>().ToList();
        }
        public TblClientProductRel SelectClientProductRelById(int id)
        {
            return new ClientProductRelRepo().SelectById<TblClientProductRel>(id);
        }
        public List<TblClientProductRel> SelectClientProductRelByClientId(int clientId)
        {
            return new ClientProductRelRepo().SelectClientProductRelByClientId(clientId);
        }
        public List<TblClientProductRel> SelectClientProductRelByProductId(int productId)
        {
            return new ClientProductRelRepo().SelectClientProductRelByProductId(productId);
        }
        public List<TblClientProductRel> SelectClientProductRelByDate(int date)
        {
            return new ClientProductRelRepo().SelectClientProductRelByDate(date);
        }
        public List<TblClientProductRel> SelectClientProductRelByCount(int count)
        {
            return new ClientProductRelRepo().SelectClientProductRelByCount(count);
        }

    }
}