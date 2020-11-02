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
using DataLayer.ViewModel;

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
            TblUserPass user = _userPass.SelectUserPassByUsernameAndPassword(client.UserName.Trim().ToLower(), hashPassword);
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
            client.Name = client.UserName;
            if (ModelState.IsValid)
            {
                if (_userPass.SelectAllUserPasss().Any(u => u.Username == client.UserName))
                {
                    ModelState.AddModelError("Username", "نام کاربری  وارد شده تکراری است");
                }
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
                        Username = client.UserName.Trim().ToLower(),
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(client.Password, "SHA256"),
                        RoleId = 1
                    };
                    bool add = _userPass.AddUserPass(addUserPass);
                    if (add)
                    {
                        TblClient tblClient = new TblClient()
                        {
                            UserPassId = addUserPass.id,
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
                            string body = PartialToStringClass.RenderPartialView("HomeAccount", "ActiviationEmail", client);
                            SendEmail.Send(client.Email, "ایمیل فعالسازی", body);
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




        public ActionResult ForgotPassword()
        {
            try
            {
                return PartialView();
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }


        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel forgot, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //if (!MethodRepo.CheckRechapcha(form))
                    //{
                    //    ViewBag.Message = "لطفا گزینه من ربات نیستم را تکمیل کنید";
                    //    return View(forgot);
                    //}
                    var user = _userPass.SelectAllUserPasss().SingleOrDefault(u => u.Username == forgot.UserName);
                    if (user != null)
                    {
                        if (user.IsActive)
                        {
                            string bodyEmail =
                                PartialToStringClass.RenderPartialView("HomeAccount", "RecoveryPass", user);
                            SendEmail.Send(_client.SelectClientByUserPassId(user.id).Email, "بازیابی کلمه عبور", bodyEmail);
                            return View("SuccesForgotPassword", user);
                        }
                        else
                        {
                            ModelState.AddModelError("UserName", "حساب کاربری شما فعال نیست");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "کاربری یافت نشد");
                    }
                }
                return PartialView("ForgotPassword", forgot);
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }

        public ActionResult RecoveryPassword(string id)
        {
            try
            {
                return PartialView();
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }

        [HttpPost]
        public ActionResult RecoveryPassword(string id, RecoveryPasswordViewModel recovery)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userPass.SelectAllUserPasss().SingleOrDefault(u => u.Auth == id);
                    if (user == null)
                    {
                        return HttpNotFound();
                    }
                    user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(recovery.Password, "SHA256");
                    user.Auth = Guid.NewGuid().ToString();
                    return Redirect("/Login?recovery=true");
                }
                return View();
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }





        public ActionResult ActiviationEmail()
        {
            try
            {
                return PartialView();
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }

        public ActionResult RecoveryPass()
        {
            try
            {
                return PartialView();
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