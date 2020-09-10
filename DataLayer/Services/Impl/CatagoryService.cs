using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class CatagoryService : ICatagoryService
    {
        public TblCatagory AddCatagory(TblCatagory catagory)
        {
            return new CatagoryRepo().Add(catagory);
        }
        public bool DeleteCatagory(int id)
        {
            return new CatagoryRepo().Delete<TblCatagory>(id);
        }
        public bool UpdateCatagory(TblCatagory catagory, int logId)
        {
            return new CatagoryRepo().Update(catagory, logId);
        }
        public List<TblCatagory> SelectAllCatagorys()
        {
            return new CatagoryRepo().SelectAll<TblCatagory>().Cast<TblCatagory>().ToList();
        }
        public TblCatagory SelectCatagoryById(int id)
        {
            return new CatagoryRepo().SelectById<TblCatagory>(id);
        }
        public TblCatagory SelectCatagoryByName(string name)
        {
            return new CatagoryRepo().SelectCatagoryByName(name);
        }
        public List<TblCatagory> SelectCatagoryByCatagoryId(int catagoryId)
        {
            return new CatagoryRepo().SelectCatagoryByCatagoryId(catagoryId);
        }

    }
}