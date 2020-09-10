using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IClientRepo
    {
        TblClient SelectClientByName(string name);
        TblClient SelectClientByIdentificationNo(string identificationNo);
        TblClient SelectClientByTellNo(string tellNo);
        TblClient SelectClientByEmail(string email);
        TblClient SelectClientByUserPassId(int userPassId);
        List<TblClient> SelectClientByIsPremium(bool isPremium);

    }
}