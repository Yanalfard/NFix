using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeTutorsController : Controller
    {
        // GET: HomeTutors
        public ActionResult TutorsPage()
        {
            return PartialView();
        }
        public ActionResult TutorView()
        {
            return View();
        }
    }
}