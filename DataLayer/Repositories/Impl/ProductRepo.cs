using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class ProductRepo : HeartRepo, IProductRepo
    {
        private MainProvider _main;
        public ProductRepo()
        {
            _main = new MainProvider();
        }
        public TblProduct SelectProductByName(string name)
        {
            return _main.SelectProductByName(name);
        }
        public List<TblProduct> SelectProductByCatagoryId(int catagoryId)
        {
            return _main.SelectProductByCatagoryId(catagoryId);
        }
        public List<TblProduct> SelectProductByIsSuggested(bool isSuggested)
        {
            return _main.SelectProductByIsSuggested(isSuggested);
        }

    }
}