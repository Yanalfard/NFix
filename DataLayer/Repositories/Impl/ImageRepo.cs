using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class ImageRepo : HeartRepo, IImageRepo
    {
        private MainProvider _main;
        public ImageRepo()
        {
            _main = new MainProvider();
        }
        public TblImage SelectImageByImage(string image)
        {
            return _main.SelectImageByImage(image);
        }

    }
}