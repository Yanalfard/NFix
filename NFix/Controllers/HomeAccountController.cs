using DataLayer.Models.Dto;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NFix.Utilities;
using DataLayer.Utilities;

namespace NFix.Controllers
{
    public class HomeAccountController : Controller
    {
        private ClientService _client = new ClientService();
        private UserPassService _userPass = new UserPassService();
        private CatagoryService _catagory = new CatagoryService();

        // GET: HomeAccount
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Login(DtoTblClient client, string ReturnUrl = "/")
        {
            //if (!MethodRepo.CheckRechapcha(form))
            //{
            //    ViewBag.Message = "لطفا گزینه من ربات نیستم را تکمیل کنید";
            //    return PartialView("Login", client);
            //}
            string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(client.Password, "SHA256");
            TblUserPass user = _userPass.SelectUserPassByUsernameAndPassword(client.UserName.ToLower(), hashPassword);
            if (user != null)
            {
                if (user.IsActive)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, client.RememberMe);
                    return JavaScript("document.getElementById('LoginForm').disabled = true;UIkit.modal(document.getElementById('ModalLogin')).hide();location.reload(true)");
                }
                else
                {
                    ModelState.AddModelError("UserName", "حساب کاربری شما فعال نیست");
                }
            }
            else
            {
                ModelState.AddModelError("UserName", "کاربری با اطلاعات وارد شده یافت نشد");
            }
            return PartialView("Login", client);
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
            client.UserName = client.Email;
            if (ModelState.IsValid)
            {

                if (_client.SelectAllClients().Any(u => u.Email == client.Email))
                {
                    ModelState.AddModelError("Email", "ایمیل  وارد شده تکراری است");
                }
                else
                {

                    TblUserPass addUserPass = new TblUserPass()
                    {
                        IsActive = false,
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
                            TellNo = "",
                            Name = client.Name,
                            InviteCode = "",
                            PremiumTill = "",
                            Status = 1,
                            Address = "",
                            Email = client.Email,
                            IdentificationNo = "",
                        };
                        bool addClient = _client.AddClient(tblClient);
                        if (addClient)
                        {
                            return JavaScript("document.getElementById('RegisterForm').reset();alert('ثبت نام شما انجام شد و لینک فعال سازی به ایمیل شما ارسال شد');UIkit.modal(document.getElementById('ModalLogin')).show();");
                            //return JavaScript("location.reload(true)");
                        };
                    };
                };
            };
            return PartialView("Register", client);
        }


        public ActionResult ActiveUser(string id)
        {
            try
            {
                var user = _userPass.SelectAllUserPasss().SingleOrDefault(u => u.Auth == id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                user.IsActive = true;
                user.Auth = Guid.NewGuid().ToString();
                ViewBag.UserName = user.Username;
                _userPass.UpdateUserPass(user, user.id);
                return View();
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }

        public ActionResult LogOff()
        {
            try
            {
                FormsAuthentication.SignOut();
                return Redirect("/");
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }




        public ActionResult Category()
        {
            var product_Groups = _catagory.SelectAllCatagorys().Where(g => g.CatagoryId == null);
            return PartialView(product_Groups.ToList());
        }


        public ActionResult Category2()
        {
            var product_Groups = _catagory.SelectAllCatagorys().Where(g => g.CatagoryId == null);
            return PartialView(product_Groups.ToList());
        }

    }
}