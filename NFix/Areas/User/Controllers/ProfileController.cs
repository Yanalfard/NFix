using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        private ClientService _client = new ClientService();
        private UserPassService _user = new UserPassService();

        // GET: User/Profile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Info()
        {
            TblUserPass SelectUser = _user.SelectUserPassByUsername(User.Identity.Name);
            TblClient selectClientByUserName = _client.SelectClientByUserPassId(SelectUser.id);
            if (selectClientByUserName == null)
            {
                return HttpNotFound();
            }
            return PartialView(selectClientByUserName);
        }
        public ActionResult EditInfo()
        {
            TblUserPass SelectUser = _user.SelectUserPassByUsername(User.Identity.Name);
            TblClient selectClientByUserName = _client.SelectClientByUserPassId(SelectUser.id);
            if (selectClientByUserName == null)
            {
                return HttpNotFound();
            }
            return PartialView(selectClientByUserName);
        }
        public ActionResult ShopCart()
        {
            return PartialView();
        }
        public ActionResult History()
        {
            return PartialView();
        }
    }
}