using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class AdService : IAdService
    {
        public TblAd AddAd(TblAd ad)
        {
            return new AdRepo().Add(ad);
        }
        public bool DeleteAd(int id)
        {
            return new AdRepo().Delete<TblAd>(id);
        }
        public bool UpdateAd(TblAd ad, int logId)
        {
            return new AdRepo().Update(ad, logId);
        }
        public List<TblAd> SelectAllAds()
        {
            return new AdRepo().SelectAll<TblAd>().Cast<TblAd>().ToList();
        }
        public TblAd SelectAdById(int id)
        {
            return new AdRepo().SelectById<TblAd>(id);
        }
        public TblAd SelectAdByImage(string image)
        {
            return new AdRepo().SelectAdByImage(image);
        }

    }
}