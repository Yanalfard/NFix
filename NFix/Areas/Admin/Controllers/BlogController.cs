using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        // GET: Admin/Blog
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

    }
}