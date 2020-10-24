using DataLayer.Models.Dto;
using DataLayer.Models.Regular;
using DataLayer.Services.Api;
using DataLayer.Services.Impl;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeVideoController : Controller
    {
        private VideoService _video;
        public HomeVideoController()
        {
            _video = new VideoService();
        }
        // GET: HomeVideo
        public ActionResult VideosPage()
        {
            var allVideo = _video.SelectAllVideos();
            return PartialView(allVideo);
        }
        public ActionResult VideoView(int id)
        {
            TblVideo selectVideoById = _video.SelectVideoById(id);
            DtoTblVideo result = new DtoTblVideo()
            {
                VideoUrl = selectVideoById.VideoUrl,
                VidioDemoUrl = selectVideoById.VidioDemoUrl,
                MainImage = selectVideoById.MainImage,
                Title = selectVideoById.Title,
                Description = selectVideoById.Description,
                DescriptionDemo = selectVideoById.DescriptionDemo,
                DateSubmited = selectVideoById.DateSubmited,
                IsOnline = selectVideoById.IsOnline,
                ViewCount = selectVideoById.ViewCount,
                IsHome = selectVideoById.IsHome,
                Raiting = selectVideoById.Raiting,
                ShareLink = selectVideoById.ShareLink,
            };
            return View(result);
        }

        public ActionResult VideoRecommendations()
        {
            return PartialView();
        }
    }
}