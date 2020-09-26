using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        // GET: User/Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}