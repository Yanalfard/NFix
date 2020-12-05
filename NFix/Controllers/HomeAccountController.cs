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
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.UI;
using System.Configuration;

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
                //Localhost
                var secret = "6LfeB-IZAAAAAFJGzrD4-Vz9B4GPnjaps0gjQwFq";
                //Site
                //var secret = "6LfeB-IZAAAAAFJGzrD4-Vz9B4GPnjaps0gjQwFq";
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

                    //return verify.IsSuccessStatusCode;

                    var captchaResponseJson = await verify.Content.ReadAsStringAsync();
                    var captchaResult = JsonConvert.DeserializeObject<CaptchaResponseViewModel>(captchaResponseJson);
                    return captchaResult.Success
                           && captchaResult.Action == "contact_us"
                           && captchaResult.Score > 0.5;
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
        public async Task<ActionResult> Login(LoginViewModel client, string GoogleCapcha, string ReturnUrl = "/")
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isCaptchaValid = await IsCaptchaValid(GoogleCapcha);
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
                                return JavaScript("UIkit.modal(document.getElementById('Modal-Show')).hide();window.location = window.location.href='/'");
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
                        ModelState.AddModelError("UserName", "ورود غیر مجاز");
                    };
                }

                return PartialView("Login", client);
            }
            catch
            {
                return Redirect("/fallback.html");
            }


        }
        public ActionResult LoginModal(string ReturnUrl = "/")
        {
            if (ReturnUrl != "/")
            {
                return PartialView();
            }
            return null;
        }
        public ActionResult Register()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public async Task<ActionResult> Register(RegisViewModel client, string GoogleCapcha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isCaptchaValid = await IsCaptchaValid(GoogleCapcha);
                    if (isCaptchaValid)
                    {
                        string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(client.Password, "SHA256");
                        client.Name = client.UserName;
                        client.UserName = client.UserName.Trim().ToLower().Replace(" ", "");
                        client.Email = client.Email.Trim().ToLower().Replace(" ", "");
                        client.TellNo = client.TellNo.Trim().ToLower().Replace(" ", "");
                        if (_userPass.SelectAllUserPasss().Any(u => u.Username == client.UserName))
                        {
                            ModelState.AddModelError("Username", "نام کاربری  وارد شده تکراری است");
                        }
                        else if (_client.SelectAllClients().Any(u => u.Email == client.Email))
                        {
                            ModelState.AddModelError("Email", "ایمیل  وارد شده تکراری است");
                            client.Email = "";
                        }
                        else if (_client.SelectAllClients().Any(u => u.TellNo == client.TellNo))
                        {
                            ModelState.AddModelError("TellNo", "شماره وارد شده تکراری است");
                            client.TellNo = "";
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
                                    TellNo = client.TellNo,
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
                                    // string body = PartialToStringClass.RenderPartialView("HomeAccount", "ActiviationEmail", addUserPass);
                                    //SendEmail.Send(client.Email, "ایمیل فعالسازی", body);
                                    //ModelState.Clear();
                                    string message = ConfigurationManager.AppSettings["MyDomain"] + "/ActiveUser/" + addUserPass.Auth;
                                    Sms.SendSms(tblClient.TellNo, message, "RegisterNfix");
                                    return JavaScript("UIkit.modal(document.getElementById('Modal-Show')).hide();UIkit.notification('لینک فعال سازی به شماره شما ارسال شد')");
                                    // return JavaScript("alert('ثبت نام شما انجام شد و لینک فعال سازی به شماره شما ارسال شد');UIkit.modal(document.getElementById('ModalRegister')).hide();");
                                    //return JavaScript("location.reload(true)");
                                };
                            };
                        };
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "ورود غیر مجاز");
                    };
                }

                return PartialView("Register", client);
            }
            catch
            {
                return Redirect("/fallback.html");
            }

        }
        [Route("ActiveUser/{id}")]
        public ActionResult ActiveUser()
        {
            return View();
        }
        [HttpPost]
        [Route("ActiveUser/{id}")]
        public ActionResult ActiveUser(ActiveViewModel check)
        {
            try
            {
                var user = _userPass.SelectAllUserPasss().SingleOrDefault(u => u.Auth == check.id);
                if (user == null)
                {
                    ModelState.AddModelError("id", "حساب کاربری شما یافت نشد");
                    return View(check);
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
                return Redirect("/?ReturnUrl=Active");
            }
            catch
            {
                return Redirect("/fallback.html");
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
                return Redirect("/fallback.html");
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
                return Redirect("/fallback.html");
            }
        }
        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel forgot, string GoogleCapcha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isCaptchaValid = await IsCaptchaValid(GoogleCapcha);
                    if (isCaptchaValid)
                    {
                        var user = _userPass.SelectAllUserPasss().SingleOrDefault(u => u.Username == forgot.UserName);
                        if (user != null)
                        {
                            if (user.IsActive)
                            {
                                TblClient client = _client.SelectClientByUserPassId(user.id);
                                if (client == null || client.TellNo == null || client.TellNo.Trim().Replace(" ", "") == "تلفن")
                                {
                                    ModelState.AddModelError("UserName", "شماره تلفن کاربر نامعتر است لطفا با پشتیبانی تماس بگیرید");
                                }
                                else
                                {
                                    //string bodyEmail =
                                    //    PartialToStringClass.RenderPartialView("HomeAccount", "RecoveryPass", user);
                                    //SendEmail.Send(client.Email, "بازیابی کلمه عبور", bodyEmail);
                                    string message = ConfigurationManager.AppSettings["MyDomain"] + "/Recovery/" + user.Auth;
                                    Sms.SendSms(client.TellNo, message, "ForgotPasswordNfix");
                                    //return Redirect("/Home/Index?recoveryPassword=true");
                                    ModelState.Clear();
                                    return JavaScript("UIkit.modal(document.getElementById('Modal-Show')).hide(); UIkit.notification('متنی حاوی لینک بازیابی کلمه عبور به شماره شما ارسال شد');");

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
                    else
                    {
                        ModelState.AddModelError("UserName", "ورود غیر مجاز");
                    };
                }
                return PartialView("ForgotPassword", forgot);
            }
            catch
            {
                return Redirect("/fallback.html");
            }
        }
        [Route("Recovery/{id}")]
        public ActionResult Recovery(string id)
        {
            try
            {
                var user = _userPass.SelectAllUserPasss().SingleOrDefault(u => u.Auth == id);
                if (user == null)
                {
                    return Redirect("/fallback.html");
                }
                ViewBag.recovery = user.id;
                return View();
            }
            catch
            {
                return Redirect("/fallback.html");
            }
           
        }
        public ActionResult RecoveryPassword(int id)
        {
            try
            {
                return PartialView();
            }
            catch
            {
                return Redirect("/fallback.html");
            }
        }
        [HttpPost]
        public ActionResult RecoveryPassword(int id, RecoveryPasswordViewModel recovery)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userPass.SelectAllUserPasss().SingleOrDefault(u => u.id == id);
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
                        return Redirect("/?ReturnUrl=RecoveryPassWord");
                    }
                }
                return PartialView("RecoveryPassword", recovery);
            }
            catch
            {
                return Redirect("/fallback.html");
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
                return Redirect("/fallback.html");
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
                return Redirect("/fallback.html");
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