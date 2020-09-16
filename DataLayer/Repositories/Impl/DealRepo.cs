using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class DealRepo : HeartRepo, IDealRepo
    {
        private MainProvider _main;
        public DealRepo()
        {
            _main = new MainProvider();
        }
        public TblDeal SelectDealByName(string name)
        {
            return _main.SelectDealByName(name);
        }
        public List<TblDeal> SelectDealByIsValid(bool isValid)
        {
            return _main.SelectDealByIsValid(isValid);
        }

    }
}