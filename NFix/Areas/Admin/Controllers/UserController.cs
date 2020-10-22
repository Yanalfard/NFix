using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataLayer;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.ViewModel;

namespace NFix.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private ClientService _client = new ClientService();
        private UserPassService _userPass = new UserPassService();
        // GET: Admin/User
        #region User

        public ActionResult UserTable()
        {
            return View(_client.SelectAllClients().OrderByDescending(i => i.id));
        }

        public ActionResult UserAdder()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserAdder(UserViewModel client)
        {
            if (ModelState.IsValid)
            {
                if (_userPass.SelectAllUserPasss().Any(u => u.Username == client.UserName.ToLower()))
                {
                    ModelState.AddModelError("UserName", "نام کاربری تکراریست");
                }
                else if (_client.SelectAllClients().Any(u => u.TellNo == client.TellNo))
                {
                    ModelState.AddModelError("TellNo", "تلفن  وارد شده تکراری است");
                }
                else
                {
                    TblUserPass addUserPass = new TblUserPass()
                    {
                        IsActive = true,
                        Auth = Guid.NewGuid().ToString(),
                        Username = client.UserName.ToLower(),
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(client.Password, "SHA256"),
                        RoleId = 1
                    };
                    bool add = _userPass.AddUserPass(addUserPass);
                    if (add)
                    {
                        TblClient tblClient = new TblClient()
                        {
                            UserPassId = _userPass.SelectUserPassByUsername(client.UserName).id,
                            TellNo = client.TellNo,
                            Name = client.Name,
                            InviteCode = "",
                            PremiumTill = "",
                            Status = 1,
                            Address = "",
                            Email = "",
                            IdentificationNo = "",
                        };
                        bool addClient = _client.AddClient(tblClient);
                        if (addClient)
                        {
                            return RedirectToAction("UserTable");
                        };
                    };
                };
            };
            return View(client);
        }

        public ActionResult UserEdit(int id)
        {
            var client = _client.SelectClientById(id);
            UserViewModel userViewModel = new UserViewModel()
            {
                id = client.id,
                Name = client.Name,
                TellNo = client.TellNo,
                Password = client.TblUserPass.Password,
                UserName = client.TblUserPass.Username,
                UserPassId = client.UserPassId,
                IsActive = client.TblUserPass.IsActive,
            };
            return View(userViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(UserViewModel client)
        {

            if (_userPass.SelectAllUserPasss().Where(i => i.id != client.id).Any(u => u.Username == client.UserName.ToLower()))
            {
                ModelState.AddModelError("UserName", "نام کاربری تکراریست");
            }
            else if (_client.SelectAllClients().Where(i => i.id != client.id).Any(u => u.TellNo == client.TellNo))
            {
                ModelState.AddModelError("TellNo", "تلفن  وارد شده تکراری است");
            }
            else
            {
                TblClient tblClient = new TblClient()
                {
                    id = client.id,
                    UserPassId = client.UserPassId,
                    TellNo = client.TellNo,
                    Name = client.Name,
                    InviteCode = "",
                    PremiumTill = "",
                    Status = 1,
                    Address = "",
                    Email = "",
                    IdentificationNo = "",
                };
                bool addClient = _client.UpdateClient(tblClient, client.id);
                var selectUser = _userPass.SelectUserPassById(client.UserPassId);
                TblUserPass addUserPass = new TblUserPass()
                {
                    id = selectUser.id,
                    IsActive = client.IsActive,
                    Auth = Guid.NewGuid().ToString(),
                    Username = client.UserName.ToLower(),
                    Password = selectUser.Password,
                    RoleId = 1,

                };
                bool add = _userPass.UpdateUserPass(addUserPass, client.UserPassId);
                if (add)
                {
                    return RedirectToAction("UserTable");
                };
            };

            return View(client);
        }


        public ActionResult DeleteUser(int id)
        {
            var client = _client.SelectClientById(id);
            _client.DeleteClient(id);
            _userPass.DeleteUserPass(client.UserPassId);
            return JavaScript("");
        }
        #endregion
    }
}