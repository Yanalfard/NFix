using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class TuotorVideoRelRepo : HeartRepo, ITuotorVideoRelRepo
    {
        private MainProvider _main;
        public TuotorVideoRelRepo()
        {
            _main = new MainProvider();
        }
        public List<TblTuotorVideoRel> SelectTuotorVideoRelByToutorId(int toutorId)
        {
            return _main.SelectTuotorVideoRel(toutorId, MainProvider.TuotorVideoRel.ToutorId);
        }
        public List<TblTuotorVideoRel> SelectTuotorVideoRelByVideoId(int videoId)
        {
            return _main.SelectTuotorVideoRel(videoId, MainProvider.TuotorVideoRel.VideoId);
        }

    }
}