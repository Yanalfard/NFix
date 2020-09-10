using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class AdRepo : HeartRepo, IAdRepo
    {
        private MainProvider _main;
        public AdRepo()
        {
            _main = new MainProvider();
        }
        public TblAd SelectAdByImage(string image)
        {
            return _main.SelectAdByImage(image);
        }

    }
}