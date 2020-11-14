using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeSearchController : Controller
    {
        private VideoService _video = new VideoService(); 
        // GET: HomeSearch
        public ActionResult Index(string q)
        {
            ViewBag.Searvh = q;
            List<TblVideo> list = new List<TblVideo>();
            list.AddRange(_video.SelectAllVideos().Where(i => i.Title.Contains(q) || i.DescriptionDemo.Contains(q) || i.Description.Contains(q)).Distinct());
            return View(list);
        }
    }
}