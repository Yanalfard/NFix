using DataLayer.Models.Dto;
using DataLayer.Models.Regular;
using DataLayer.Services.Api;
using DataLayer.Services.Impl;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class VideoController : Controller
    {
        // GET: Admin/Video
        #region Video
        private VideoService _video = new VideoService();
        public ActionResult VideoTable()
        {
            var allVideo = _video.SelectAllVideos();
            //List<DtoTblVideo> result = MethodRepo.ConvertToDto<TblVideo, DtoTblVideo>(allVideo);
            return View(allVideo);
        }
        public ActionResult VideoAdder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VideoAdder(TblVideo video, HttpPostedFileBase VideoUrl, HttpPostedFileBase VidioDemoUrl, HttpPostedFileBase MainImage)
        {

            if (MainImage != null)
            {
                video.MainImage = Guid.NewGuid().ToString() + Path.GetExtension(MainImage.FileName);
                MainImage.SaveAs(Server.MapPath("/Resources/Videos/Image/" + video.MainImage));
            }
            if (VideoUrl != null)
            {
                video.VideoUrl = Guid.NewGuid().ToString() + Path.GetExtension(VideoUrl.FileName);
                VideoUrl.SaveAs(Server.MapPath("/Resources/Videos/" + video.VideoUrl));
            }
            if (VidioDemoUrl != null)
            {
                video.VidioDemoUrl = Guid.NewGuid().ToString() + Path.GetExtension(VidioDemoUrl.FileName);
                VidioDemoUrl.SaveAs(Server.MapPath("/Resources/Videos/Demo/" + video.VidioDemoUrl));
            }

            video.DateSubmited = DateTime.Now.ToShortDateString();
            bool b1= _video.AddVideo(video);
            return RedirectToAction("VideoTable");
        }
        public ActionResult VideoEdit(int id)
        {
            var video = _video.SelectVideoById(id);
            return View(video);
        }
        [HttpPost]
        public ActionResult VideoEdit(TblVideo video, HttpPostedFileBase VideoUrl, HttpPostedFileBase VidioDemoUrl, HttpPostedFileBase MainImage)
        {

            if (MainImage != null)
            {
                if (video.MainImage != null)
                {
                    System.IO.File.Delete(Server.MapPath("/Resources/Videos/Image/" + video.MainImage));
                }
                video.MainImage = Guid.NewGuid().ToString() + Path.GetExtension(MainImage.FileName);
                MainImage.SaveAs(Server.MapPath("/Resources/Videos/Image/" + video.MainImage));
            }
            if (VideoUrl != null)
            {
                if (video.VideoUrl != null)
                {
                    System.IO.File.Delete(Server.MapPath("/Resources/Videos/" + video.VideoUrl));
                }
                video.VideoUrl = Guid.NewGuid().ToString() + Path.GetExtension(VideoUrl.FileName);
                VideoUrl.SaveAs(Server.MapPath("/Resources/Videos/" + video.VideoUrl));
            }
            if (VidioDemoUrl != null)
            {
                if (video.VidioDemoUrl != null)
                {
                    System.IO.File.Delete(Server.MapPath("/Reso urces/Videos/Demo/" + video.VidioDemoUrl));
                }
                video.VidioDemoUrl = Guid.NewGuid().ToString() + Path.GetExtension(VidioDemoUrl.FileName);
                VidioDemoUrl.SaveAs(Server.MapPath("/Resources/Videos/Demo/" + video.VidioDemoUrl));
            }
            bool b1= _video.UpdateVideo(video, video.id);
            return RedirectToAction("VideoTable");
        }
        public ActionResult DeleteVideo(int id)
        {
            bool del = _video.DeleteVideo(id);
            return JavaScript("");
        }
        public ActionResult VideoComments()
        {
            return View();
        }
        public ActionResult VideoKeyWords()
        {
            return View();
        }
        #endregion
    }
}