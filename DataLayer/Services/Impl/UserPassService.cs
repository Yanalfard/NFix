using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class UserPassService : IUserPassService
    {
        public bool AddUserPass(TblUserPass userPass)
        {
            return new UserPassRepo().Add(userPass);
        }
        public bool DeleteUserPass(int id)
        {
            return new UserPassRepo().Delete<TblUserPass>(id);
        }
        public bool UpdateUserPass(TblUserPass userPass, int logId)
        {
            return new UserPassRepo().Update(userPass, logId);
        }
        public List<TblUserPass> SelectAllUserPasss()
        {
            return new UserPassRepo().SelectAll<TblUserPass>().Cast<TblUserPass>().ToList();
        }
        public TblUserPass SelectUserPassById(int id)
        {
            return new UserPassRepo().SelectById<TblUserPass>(id);
        }
        public TblUserPass SelectUserPassByUsernameAndPassword(string username ,string password)
        {
            return new UserPassRepo().SelectUserPassByUsernameAndPassword(username, password);
        }
        public TblUserPass SelectUserPassByUsername(string username)
        {
            return new UserPassRepo().SelectUserPassByUsername(username);
        }
        public TblUserPass SelectUserPassByPassword(string password)
        {
            return new UserPassRepo().SelectUserPassByPassword(password);
        }
        public List<TblUserPass> SelectUserPassByIsActive(bool isActive)
        {
            return new UserPassRepo().SelectUserPassByIsActive(isActive);
        }

    }
}