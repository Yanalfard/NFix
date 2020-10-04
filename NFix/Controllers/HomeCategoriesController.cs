using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeCategoriesController : Controller
    {
        // GET: HomeCategories
        public ActionResult CategoriesPage()
        {
            return PartialView();
        }
        public ActionResult CategoryView()
        {
            return View();
        }
    }
}