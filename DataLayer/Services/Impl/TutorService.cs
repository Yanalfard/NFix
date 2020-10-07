using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class TutorService : ITutorService
    {
        public bool AddTutor(TblTutor tutor)
        {
            return new TutorRepo().Add(tutor);
        }
        public bool DeleteTutor(int id)
        {
            return new TutorRepo().Delete<TblTutor>(id);
        }
        public bool UpdateTutor(TblTutor tutor, int logId)
        {
            return new TutorRepo().Update(tutor, logId);
        }
        public List<TblTutor> SelectAllTutors()
        {
            return new TutorRepo().SelectAll<TblTutor>().Cast<TblTutor>().ToList();
        }
        public TblTutor SelectTutorById(int id)
        {
            return new TutorRepo().SelectById<TblTutor>(id);
        }
        public TblTutor SelectTutorByName(string name)
        {
            return new TutorRepo().SelectTutorByName(name);
        }
        public TblTutor SelectTutorByIdentificationNo(string identificationNo)
        {
            return new TutorRepo().SelectTutorByIdentificationNo(identificationNo);
        }
        public TblTutor SelectTutorByTellNo(string tellNo)
        {
            return new TutorRepo().SelectTutorByTellNo(tellNo);
        }
        public TblTutor SelectTutorByUserPassId(int userPassId)
        {
            return new TutorRepo().SelectTutorByUserPassId(userPassId);
        }

    }
}