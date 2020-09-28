using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VideoTable()
        {
            return View();
        }

        public ActionResult VideoAdder()
        {
            return View();
        }

        public ActionResult BlogTable()
        {
            return View();
        }

        public ActionResult BlogAdder()
        {
            return View();
        }

        public ActionResult TutorTable()
        {
            return View();
        }

        public ActionResult TutorAdder()
        {
            return View();
        }

        public ActionResult ProductTable()
        {
            return View();
        }

        public ActionResult ProductAdder()
        {
            return View();
        }

        public ActionResult OrderTable()
        {
            return View();
        }

        public ActionResult UserTable()
        {
            return View();
        }

        public ActionResult UserAdder()
        {
            return View();
        }

    }
}