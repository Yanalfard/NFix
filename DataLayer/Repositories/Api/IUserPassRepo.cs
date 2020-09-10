using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IUserPassRepo
    {
        TblUserPass SelectUserPassByUsernameAndPassword(string username ,string password);
        TblUserPass SelectUserPassByUsername(string username);
        TblUserPass SelectUserPassByPassword(string password);
        List<TblUserPass> SelectUserPassByIsActive(bool isActive);

    }
}