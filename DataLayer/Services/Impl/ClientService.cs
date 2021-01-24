using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class ClientService : IClientService
    {
        public bool AddClient(TblClient client)
        {
            return new ClientRepo().Add(client);
        }
        public bool DeleteClient(int id)
        {
            return new ClientRepo().Delete<TblClient>(id);
        }
        public bool UpdateClient(TblClient client, int logId)
        {
            return new ClientRepo().Update(client, logId);
        }
        public List<TblClient> SelectAllClients()
        {
            return new ClientRepo().SelectAll<TblClient>().Cast<TblClient>().ToList();
        }
        public TblClient SelectClientById(int id)
        {
            return new ClientRepo().SelectById<TblClient>(id);
        }
        public TblClient SelectClientByName(string name)
        {
            return new ClientRepo().SelectClientByName(name);
        }
        public TblClient SelectClientByIdentificationNo(string identificationNo)
        {
            return new ClientRepo().SelectClientByIdentificationNo(identificationNo);
        }
        public TblClient SelectClientByTellNo(string tellNo)
        {
            return new ClientRepo().SelectClientByTellNo(tellNo);
        }
        public TblClient SelectClientByEmail(string email)
        {
            return new ClientRepo().SelectClientByEmail(email);
        }
        public TblClient SelectClientByUserPassId(int userPassId)
        {
            return new ClientRepo().SelectClientByUserPassId(userPassId);
        }
        public List<TblClient> SelectClientByIsPremium(bool isPremium)
        {
            return new ClientRepo().SelectClientByIsPremium(isPremium);
        }
        public List<TblProduct>SelectProductsByClientId(int clientId)
        {
            List<TblClientProductRel> stp1 = new ClientProductRelRepo().SelectClientProductRelByClientId(clientId);
            List<TblProduct> stp2 = new List<TblProduct>();
            foreach (TblClientProductRel rel in stp1)
                stp2.Add(new ProductRepo().SelectById<TblProduct>(Convert.ToInt32(rel.ProductId)));
            return stp2;
        }

    }
}