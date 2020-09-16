using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class ClientRepo : HeartRepo, IClientRepo
    {
        private MainProvider _main;
        public ClientRepo()
        {
            _main = new MainProvider();
        }
        public TblClient SelectClientByName(string name)
        {
            return _main.SelectClientByName(name);
        }
        public TblClient SelectClientByIdentificationNo(string identificationNo)
        {
            return _main.SelectClientByIdentificationNo(identificationNo);
        }
        public TblClient SelectClientByTellNo(string tellNo)
        {
            return _main.SelectClientByTellNo(tellNo);
        }
        public TblClient SelectClientByEmail(string email)
        {
            return _main.SelectClientByEmail(email);
        }
        public TblClient SelectClientByUserPassId(int userPassId)
        {
            return _main.SelectClientByUserPassId(userPassId);
        }
        public List<TblClient> SelectClientByIsPremium(bool isPremium)
        {
            return _main.SelectClientByIsPremium(isPremium);
        }

    }
}