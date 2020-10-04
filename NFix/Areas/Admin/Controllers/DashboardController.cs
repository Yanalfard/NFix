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

        #region Video

        public ActionResult VideoTable()
        {
            return View();
        }

        public ActionResult VideoAdder()
        {
            return View();
        }

        public ActionResult VideoComments()
        {
            return View();
        }

        public ActionResult VideoKeyWords()
        {
            return View();
        }

        #endregion

        #region Blog

        public ActionResult BlogTable()
        {
            return View();
        }

        public ActionResult BlogAdder()
        {
            return View();
        }

        public ActionResult BlogComments()
        {
            return View();
        }

        public ActionResult BlogKeyWords()
        {
            return View();
        }

        #endregion

        #region Tutor

        public ActionResult TutorTable()
        {
            return View();
        }

        public ActionResult TutorAdder()
        {
            return View();
        }

        #endregion

        #region Product

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


        #endregion

        #region User

        public ActionResult UserTable()
        {
            return View();
        }

        public ActionResult UserAdder()
        {
            return View();
        }


        #endregion
    }
}