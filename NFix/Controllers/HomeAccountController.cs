using DataLayer.Models.Dto;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NFix.Controllers
{
    public class HomeAccountController : Controller
    {
        private ClientService _client = new ClientService();
        private UserPassService _userPass = new UserPassService();
        // GET: HomeAccount
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Login(DtoTblClient client)
        {
            string hashPassword= FormsAuthentication.HashPasswordForStoringInConfigFile(client.Password, "SHA256");
            TblUserPass user= _userPass.SelectUserPassByUsernameAndPassword(client.UserName.ToLower(), hashPassword);
            if (user != null)
            {
                user.IsActive = true;
                if (user.IsActive)
                {
                    FormsAuthentication.SetAuthCookie(user.Username,client.RememberMe);
                    return JavaScript("document.getElementById('LoginForm').disabled = true;UIkit.modal(document.getElementById('ModalLogin')).hide();location.reload(true)");
                }
                else
                {
                    ModelState.AddModelError("UserName","حساب کاربری شما فعال نیست");
                }
            }
            else
            {
                ModelState.AddModelError("UserName", "کاربری با اطلاعات وارد شده یافت نشد");
            }
            return PartialView("Login",client);
        }

        public ActionResult Register()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Register(DtoTblClient client)
        {
            if (ModelState.IsValid)
            {
                if (_userPass.SelectAllUserPasss().Any(u => u.Username == client.UserName.ToLower()))
                {
                    ModelState.AddModelError("UserName", "نام کاربری تکراریست");
                }
                else if (_client.SelectAllClients().Any(u => u.Email == client.Email))
                {
                    ModelState.AddModelError("Email", "ایمیل وارد شده تکراری است");
                }
                else if (_client.SelectAllClients().Any(u => u.TellNo == client.TellNo))
                {
                    ModelState.AddModelError("TellNo", "تلفن  وارد شده تکراری است");
                }
                else
                {
                    TblUserPass addUserPass = new TblUserPass()
                    {
                        IsActive = false,
                        Auth = Guid.NewGuid().ToString(),
                        Username = client.UserName.ToLower(),
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(client.Password, "SHA256"),
                        RoleId = 12
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
                            return JavaScript("document.getElementById('RegisterForm').reset();alert('ثبت نام شما انجام شد');UIkit.modal(document.getElementById('ModalLogin')).show();");
                            //return JavaScript("location.reload(true)");
                        };
                    };
                };
            };
            return PartialView("Register", client);
        }
    }
}