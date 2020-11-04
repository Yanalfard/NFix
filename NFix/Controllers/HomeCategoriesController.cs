using DataLayer.Models.Dto;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeCategoriesController : Controller
    {
        private VideoCatagoryService _videoCatagory = new VideoCatagoryService();
        private VideoService _video = new VideoService();

        // GET: HomeCategories
        public ActionResult CategoriesPage()
        {
            var AllCategori = _videoCatagory.SelectAllVideoCatagorys();
            return PartialView(AllCategori);
        }
        [Route("CategoryView/{id}/{name}")]
        public ActionResult CategoryView(int id, string name)
        {
            TblVideoCatagory selectCategoryById = _videoCatagory.SelectVideoCatagoryById(id);

            ViewBag.CatagoryName = name;
            ViewBag.ImageName = selectCategoryById.Image;
            List<TblVideo> selectAllVideo = _video.SelectAllVideos().Where(i => i.CatagoryId == id).ToList();
            return View(selectAllVideo);
        }
    }
}