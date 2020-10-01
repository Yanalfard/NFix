using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeVideoController : Controller
    {
        // GET: HomeVideo
        public ActionResult VideosPage()
        {
            return View();
        }
        public ActionResult VideoView()
        {
            return View();
        }
    }
}