using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface ITutorRepo
    {
        TblTutor SelectTutorByName(string name);
        TblTutor SelectTutorByIdentificationNo(string identificationNo);
        TblTutor SelectTutorByTellNo(string tellNo);
        TblTutor SelectTutorByUserPassId(int userPassId);

    }
}