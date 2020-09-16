using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class CatagoryRepo : HeartRepo, ICatagoryRepo
    {
        private MainProvider _main;
        public CatagoryRepo()
        {
            _main = new MainProvider();
        }
        public TblCatagory SelectCatagoryByName(string name)
        {
            return _main.SelectCatagoryByName(name);
        }
        public List<TblCatagory> SelectCatagoryByCatagoryId(int catagoryId)
        {
            return _main.SelectCatagoryByCatagoryId(catagoryId);
        }

    }
}