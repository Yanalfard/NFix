using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class VideoRepo : HeartRepo, IVideoRepo
    {
        private MainProvider _main;
        public VideoRepo()
        {
            _main = new MainProvider();
        }
        public TblVideo SelectVideoByTitle(string title)
        {
            return _main.SelectVideoByTitle(title);
        }
        public List<TblVideo> SelectVideoByIsOnline(bool isOnline)
        {
            return _main.SelectVideoByIsOnline(isOnline);
        }
        public List<TblVideo> SelectVideoByIsHome(bool isHome)
        {
            return _main.SelectVideoByIsHome(isHome);
        }

    }
}