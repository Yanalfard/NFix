using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class DiscountRepo : HeartRepo, IDiscountRepo
    {
        private MainProvider _main;
        public DiscountRepo()
        {
            _main = new MainProvider();
        }
        public TblDiscount SelectDiscountByName(string name)
        {
            return _main.SelectDiscountByName(name);
        }

    }
}