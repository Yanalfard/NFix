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
                client.UserName = client.UserName.Trim().ToLower().Replace(" ", "");
                client.TellNo = client.TellNo.Trim().ToLower().Replace(" ", "");
                if (_userPass.SelectAllUserPasss().Any(u => u.Username == client.UserName))
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
                        IsActive = client.IsActive,
                        Auth = Guid.NewGuid().ToString(),
                        Username = client.UserName,
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(client.Password, "SHA256"),
                        RoleId = 1
                    };
                    bool add = _userPass.AddUserPass(addUserPass);
                    if (add)
                    {
                        TblClient tblClient = new TblClient();

                        tblClient.UserPassId = addUserPass.id;
                        tblClient.TellNo = client.TellNo;
                        tblClient.Name = client.Name;
                        tblClient.InviteCode = "کد معرف";
                        tblClient.PremiumTill = new DateTime().ToString();
                        tblClient.Status = 1;
                        tblClient.Address = "آدرس";
                        tblClient.Email = "ایمیل";
                        tblClient.IdentificationNo = "کد ملی";
                        tblClient.IsPremium = false;
                        tblClient.PostalCode = "کد پستی";
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
                Address = client.Address,
                Email = client.Email,
                IdentificationNo = client.IdentificationNo,
                InviteCode = client.InviteCode,
                IsPremium = client.IsPremium,
                PostalCode = client.PostalCode,
                PremiumTill = client.PremiumTill,
                Status = client.Status
            };
            return View(userViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(UserViewModel client)
        {
            client.UserName = client.UserName.Trim().ToLower().Replace(" ", "");
            client.TellNo = client.TellNo.Trim().ToLower().Replace(" ", "");
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
                    InviteCode = client.InviteCode,
                    PremiumTill = client.PremiumTill,
                    Status = client.Status,
                    Address = client.Address,
                    Email = client.Email,
                    IdentificationNo = client.IdentificationNo,
                    IsPremium = client.IsPremium,
                    PostalCode = client.PostalCode,
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
            bool b = _client.DeleteClient(id);
            bool c = _userPass.DeleteUserPass(client.UserPassId);
            return JavaScript("");
        }


        public ActionResult EditPass(int id, string name)
        {
            ViewBag.UserID = id;
            ViewBag.UserName = name;
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPass(int UserID, string UserName, ChangePasswordUserTutorViewModel changePass)
        {

            if (ModelState.IsValid)
            {
                TblClient selectClient = _client.SelectClientById(UserID);
                TblUserPass selectUser = _userPass.SelectUserPassById(selectClient.UserPassId);
                TblUserPass tblUser = new TblUserPass()
                {
                    id = selectUser.id,
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(changePass.Password, "SHA256"),
                    Auth = selectUser.Auth,
                    IsActive = selectUser.IsActive,
                    RoleId = selectUser.RoleId,
                    Username = selectUser.Username,

                };
                bool x = _userPass.UpdateUserPass(tblUser, selectUser.id);
                return JavaScript("UIkit.modal(document.getElementById('ModalChangePassword')).hide();doneEdit();");

            }
            ViewBag.UserID = UserID;
            ViewBag.UserName = UserName;
            return PartialView("EditPass", changePass);
        }

        #endregion
    }
}