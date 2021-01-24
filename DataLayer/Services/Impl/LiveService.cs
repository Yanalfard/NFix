using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class LiveService : ILiveService
    {
        public bool AddLive(TblLive Live)
        {
            return new LiveRepo().Add(Live);
        }
        public bool DeleteLive(int id)
        {
            return new LiveRepo().Delete<TblLive>(id);
        }
        public bool UpdateLive(TblLive live, int logId)
        {
            return new LiveRepo().Update(live, logId);
        }
        public List<TblLive> SelectAllLives()
        {
            return new LiveRepo().SelectAll<TblLive>().Cast<TblLive>().ToList();
        }
        public TblLive SelectLiveById(int id)
        {
            return new LiveRepo().SelectById<TblLive>(id);
        }
    }
}