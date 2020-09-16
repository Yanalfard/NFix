using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class TutorRepo : HeartRepo, ITutorRepo
    {
        private MainProvider _main;
        public TutorRepo()
        {
            _main = new MainProvider();
        }
        public TblTutor SelectTutorByName(string name)
        {
            return _main.SelectTutorByName(name);
        }
        public TblTutor SelectTutorByIdentificationNo(string identificationNo)
        {
            return _main.SelectTutorByIdentificationNo(identificationNo);
        }
        public TblTutor SelectTutorByTellNo(string tellNo)
        {
            return _main.SelectTutorByTellNo(tellNo);
        }
        public TblTutor SelectTutorByUserPassId(int userPassId)
        {
            return _main.SelectTutorByUserPassId(userPassId);
        }

    }
}