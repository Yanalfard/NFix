﻿using DataLayer.Models.Dto;
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
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.UI;

namespace NFix.Controllers
{
    public class HomeAccountController : Controller
    {
        private ClientService _client = new ClientService();
        private UserPassService _userPass = new UserPassService();
        private CatagoryService _catagory = new CatagoryService();





        private async Task<bool> IsCaptchaValid(string response)
        {
            try
            {
                var secret = "6LfeB-IZAAAAAFJGzrD4-Vz9B4GPnjaps0gjQwFq";
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        {"secret", secret},
                        {"response", response},
                        {"remoteip", Request.UserHostAddress}
                    };

                    var content = new FormUrlEncodedContent(values);
                    var verify = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);

                    return verify.IsSuccessStatusCode;

                    //var captchaResponseJson = await verify.Content.ReadAsStringAsync();
                    //var captchaResult = JsonConvert.DeserializeObject<CaptchaResponseViewModel>(captchaResponseJson);
                    //return captchaResult.Success
                    //       && captchaResult.Action == "contact_us"
                    //       && captchaResult.Score > 0.5;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        // GET: HomeAccount
        public ActionResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public async Task<ActionResult> Login(RegisterViewModel client, string ReturnUrl = "/")
        {
            var isCaptchaValid = await IsCaptchaValid(client.GoogleCapcha);
            if (isCaptchaValid)
            {
                string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(client.Password, "SHA256");
                TblUserPass user = _userPass.SelectUserPassByUsernameAndPassword(client.UserName.Trim().ToLower(), hashPassword);
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        TblClient selectClient = _client.SelectClientByUserPassId(user.id);
                        if (selectClient != null)
                        {
                            TblClient updateClient = new TblClient();
                            updateClient.id = selectClient.id;
                            updateClient.Name = selectClient.Name;
                            updateClient.IdentificationNo = selectClient.IdentificationNo;
                            updateClient.TellNo = selectClient.TellNo;
                            updateClient.Email = selectClient.Email;
                            updateClient.Address = selectClient.Address;
                            updateClient.PostalCode = selectClient.PostalCode;
                            updateClient.UserPassId = selectClient.UserPassId;
                            updateClient.Status = selectClient.Status;
                            updateClient.PremiumTill = selectClient.PremiumTill;
                            updateClient.InviteCode = selectClient.InviteCode;
                            if (DateTime.Parse(selectClient.PremiumTill) >= DateTime.Now)
                            {
                                updateClient.IsPremium = true;
                            }
                            else if (DateTime.Parse(selectClient.PremiumTill) < DateTime.Now)
                            {
                                updateClient.IsPremium = false;
                            }
                            bool update = _client.UpdateClient(updateClient, selectClient.id);
                        };
                        FormsAuthentication.SetAuthCookie(user.Username, client.RememberMe);
                        //return JavaScript("window.location = window.location.href.replace('?LoginInUser=true', '');document.getElementById('LoginForm').disabled = true;UIkit.modal(document.getElementById('ModalLogin')).hide();");
                        return JavaScript("UIkit.modal(document.getElementById('ModalLogin')).hide();window.location = window.location.href='/Home/Index'");
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
            }
            else
            {
                ModelState.AddModelError("GoogleCapcha", "شما ربات هستید");
            };
            return PartialView("Login", client);
        }
        public ActionResult Register()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public async Task<ActionResult> Register(RegisterViewModel client)
        {
            var isCaptchaValid = await IsCaptchaValid(client.GoogleCapcha);
            if (isCaptchaValid)
            {
                string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(client.Password, "SHA256");

                client.Name = client.UserName;
                client.UserName = client.UserName.Trim().ToLower().Replace(" ", "");
                client.Email = client.Email.Trim().ToLower().Replace(" ", "");
                if (ModelState.IsValid)
                {
                    if (_userPass.SelectAllUserPasss().Any(u => u.Username == client.UserName))
                    {
                        ModelState.AddModelError("Username", "نام کاربری  وارد شده تکراری است");
                    }
                    else if (_client.SelectAllClients().Any(u => u.Email == client.Email))
                    {
                        ModelState.AddModelError("Email", "ایمیل  وارد شده تکراری است");
                        client.Email = "";
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
                                TellNo = "شماره تلفن",
                                Name = client.Name,
                                InviteCode = "کد معرف",
                                PremiumTill = new DateTime().ToString(),
                                Status = 1,
                                Address = "آدرس",
                                Email = client.Email,
                                IdentificationNo = "کد ملی",
                                IsPremium = false,
                                PostalCode = "کد پستی",
                            };

                            bool addClient = _client.AddClient(tblClient);
                            if (addClient)
                            {
                                string body = PartialToStringClass.RenderPartialView("HomeAccount", "ActiviationEmail", addUserPass);
                                SendEmail.Send(client.Email, "ایمیل فعالسازی", body);
                                ModelState.Clear();
                                return JavaScript("alert('ثبت نام شما انجام شد و لینک فعال سازی به ایمیل شما ارسال شد');UIkit.modal(document.getElementById('ModalRegister')).hide();");
                                //return JavaScript("location.reload(true)");
                            };
                        };
                    };
                };
                return PartialView("Register", client);
            }
            else
            {
                ModelState.AddModelError("GoogleCapcha", "شما ربات هستید");
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
                TblUserPass tblUserPass = new TblUserPass()
                {
                    id = user.id,
                    Auth = user.Auth,
                    IsActive = user.IsActive,
                    Password = user.Password,
                    RoleId = user.RoleId,
                    Username = user.Username,
                };
                bool x = _userPass.UpdateUserPass(tblUserPass, user.id);
                return Redirect("/Home/Index?active=true");
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
        public ActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userPass.SelectAllUserPasss().SingleOrDefault(u => u.Username == forgot.UserName);
                    if (user != null)
                    {
                        if (user.IsActive)
                        {
                            TblClient client = _client.SelectClientByUserPassId(user.id);
                            if (client == null || client.Email == null || client.Email.Trim().Replace(" ", "") == "ایمیل")
                            {
                                ModelState.AddModelError("UserName", "ایمیل کاربر نامعتر است لطفا با پشتیبانی تماس بگیرید");
                            }
                            else
                            {
                                string bodyEmail =
                                    PartialToStringClass.RenderPartialView("HomeAccount", "RecoveryPass", user);
                                SendEmail.Send(client.Email, "بازیابی کلمه عبور", bodyEmail);
                                //return Redirect("/Home/Index?recoveryPassword=true");
                                ModelState.Clear();
                                return JavaScript("UIkit.modal(document.getElementById('ModalForget')).hide(); alert('ایمیلی حاوی لینک بازیابی کلمه عبور به ایمیل شما ارسال شد');");

                            }
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
                        ModelState.AddModelError("Password", "کاربری یافت نشد");
                    }
                    else
                    {

                        user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(recovery.Password, "SHA256");
                        user.Auth = Guid.NewGuid().ToString();
                        TblUserPass tblUserPass = new TblUserPass()
                        {
                            id = user.id,
                            Auth = user.Auth,
                            IsActive = user.IsActive,
                            Password = user.Password,
                            RoleId = user.RoleId,
                            Username = user.Username,
                        };
                        bool x = _userPass.UpdateUserPass(tblUserPass, user.id);

                        // return Redirect("/Home/Index?DoneChangePassword=true");
                        return JavaScript("alert('رمز شما تغیر یافت');UIkit.modal(document.getElementById('RecoveryPassword')).hide();;window.location ='/Home/Index';");
                    }
                }
                return PartialView("RecoveryPassword", recovery);
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
        public ActionResult LoginPageShowModal()
        {
            return Redirect("/Home/Index?LoginInUser=true");
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