using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class TuotorVideoRelService : ITuotorVideoRelService
    {
        public bool AddTuotorVideoRel(TblTuotorVideoRel tuotorVideoRel)
        {
            return new TuotorVideoRelRepo().Add(tuotorVideoRel);
        }
        public bool DeleteTuotorVideoRel(int id)
        {
            return new TuotorVideoRelRepo().Delete<TblTuotorVideoRel>(id);
        }
        public bool UpdateTuotorVideoRel(TblTuotorVideoRel tuotorVideoRel, int logId)
        {
            return new TuotorVideoRelRepo().Update(tuotorVideoRel, logId);
        }
        public List<TblTuotorVideoRel> SelectAllTuotorVideoRels()
        {
            return new TuotorVideoRelRepo().SelectAll<TblTuotorVideoRel>().Cast<TblTuotorVideoRel>().ToList();
        }
        public TblTuotorVideoRel SelectTuotorVideoRelById(int id)
        {
            return new TuotorVideoRelRepo().SelectById<TblTuotorVideoRel>(id);
        }
        public List<TblTuotorVideoRel> SelectTuotorVideoRelByToutorId(int toutorId)
        {
            return new TuotorVideoRelRepo().SelectTuotorVideoRelByToutorId(toutorId);
        }
        public List<TblTuotorVideoRel> SelectTuotorVideoRelByVideoId(int videoId)
        {
            return new TuotorVideoRelRepo().SelectTuotorVideoRelByVideoId(videoId);
        }

    }
}