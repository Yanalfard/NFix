using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class VideoService : IVideoService
    {
        public bool AddVideo(TblVideo video)
        {
            return new VideoRepo().Add(video);
        }
        public bool DeleteVideo(int id)
        {
            return new VideoRepo().Delete<TblVideo>(id);
        }
        public bool UpdateVideo(TblVideo video, int logId)
        {
            return new VideoRepo().Update(video, logId);
        }
        public List<TblVideo> SelectAllVideos()
        {
            return new VideoRepo().SelectAll<TblVideo>().Cast<TblVideo>().ToList();
        }
        public TblVideo SelectVideoById(int id)
        {
            return new VideoRepo().SelectById<TblVideo>(id);
        }
        public TblVideo SelectVideoByTitle(string title)
        {
            return new VideoRepo().SelectVideoByTitle(title);
        }
        public List<TblVideo> SelectVideoByIsOnline(bool isOnline)
        {
            return new VideoRepo().SelectVideoByIsOnline(isOnline);
        }
        public List<TblVideo> SelectVideoByIsHome(bool isHome)
        {
            return new VideoRepo().SelectVideoByIsHome(isHome);
        }

    }
}