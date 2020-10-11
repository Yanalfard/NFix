using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
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