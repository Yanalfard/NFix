using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;

namespace NFix.Controllers
{
    public class HomeLivesController : Controller
    {
        // GET: HomeLives
        [Route("AllLives")]
        public ActionResult AllLives()
        {
            List<TblLive> lives = new LiveService().SelectAllLives();
            return View(lives);
        }
    }
}