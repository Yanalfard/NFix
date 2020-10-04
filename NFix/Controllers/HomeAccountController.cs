using DataLayer.Models.Dto;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeAccountController : Controller
    {
        // GET: HomeAccount
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(TblClient client)
        {
            return View();
        }

        public ActionResult Register()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Register(DtoTblClient client)
        {
            return View();
        }
    }
}