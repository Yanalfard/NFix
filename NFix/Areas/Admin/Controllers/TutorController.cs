using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class TutorController : Controller
    {
        // GET: Admin/Tutor
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

    }
}