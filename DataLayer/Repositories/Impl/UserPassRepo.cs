using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class UserPassRepo : HeartRepo, IUserPassRepo
    {
        private MainProvider _main;
        public UserPassRepo()
        {
            _main = new MainProvider();
        }
        public TblUserPass SelectUserPassByUsernameAndPassword(string username ,string password)
        {
            return _main.SelectUserPassByUsernameAndPassword(username, password);
        }
        public TblUserPass SelectUserPassByUsername(string username)
        {
            return _main.SelectUserPassByUsername(username);
        }
        public TblUserPass SelectUserPassByPassword(string password)
        {
            return _main.SelectUserPassByPassword(password);
        }
        public List<TblUserPass> SelectUserPassByIsActive(bool isActive)
        {
            return _main.SelectUserPassByIsActive(isActive);
        }

    }
}