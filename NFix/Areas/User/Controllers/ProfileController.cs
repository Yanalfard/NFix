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
            
            if (selectClientByUserName.PremiumTill != "")
            {
                int daysTillFinished = ((DateTime.Parse(selectClientByUserName.PremiumTill) - DateTime.Now).Days);
                int totalDays = 0;
                int totalMonth = 0;
                if (daysTillFinished <= 365 && daysTillFinished > 183)
                {
                    totalDays = 365;
                    totalMonth = 12;
                }
                else if (daysTillFinished <= 183 && daysTillFinished > 91)
                {
                    totalDays = 183;
                    totalMonth = 6;
                }
                else if (daysTillFinished <= 91 && daysTillFinished > 30)
                {
                    totalDays = 91;
                    totalMonth = 3;
                }
                else if (daysTillFinished <= 30)
                {
                    totalDays = 1;
                }
                ViewBag.totalMonth = totalMonth;
                ViewBag.daysTillFinished = daysTillFinished;
                ViewBag.totalDays = totalDays;
            }
            else
            {
                ViewBag.totalMonth = 0;
                ViewBag.daysTillFinished = 0;
                ViewBag.totalDays = 0;
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