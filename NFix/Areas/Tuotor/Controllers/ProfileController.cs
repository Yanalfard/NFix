using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Tuotor.Controllers
{
    public class ProfileController : Controller
    {
        private UserPassService _userPass = new UserPassService();
        private TutorService _tutor = new TutorService();
        private VideoService _video = new VideoService();
        private TuotorVideoRelService _tuotorVideoRelService = new TuotorVideoRelService();
        // GET: Tuotor/Profile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Info()
        {
            var selectUser = _userPass.SelectUserPassByUsername(User.Identity.Name);
            var selectTutor = _tutor.SelectTutorByUserPassId(selectUser.id);
            return PartialView(selectTutor);

        }
        public ActionResult VideoTable()
        {
            var selectUser = _userPass.SelectUserPassByUsername(User.Identity.Name);
            var selectTutor = _tutor.SelectTutorByUserPassId(selectUser.id);
            var selectVideoByToturId = _tuotorVideoRelService.SelectTuotorVideoRelByToutorId(selectTutor.id);
            List<TblVideo> selectVideoById = new List<TblVideo>();
            selectVideoByToturId.ForEach(i => selectVideoById.Add(_video.SelectVideoById(i.VideoId)));
            return PartialView(selectVideoById);
        }
        public ActionResult UploadVideo()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult UploadVideo(TblVideo video, HttpPostedFileBase VideoUrl, HttpPostedFileBase VidioDemoUrl, HttpPostedFileBase MainImage)
        {
            var selectUser = _userPass.SelectUserPassByUsername(User.Identity.Name);
            var selectTutor = _tutor.SelectTutorByUserPassId(selectUser.id);
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
            bool b1 = _video.AddVideo(video);
            TblTuotorVideoRel tuotorVideoRel = new TblTuotorVideoRel()
            {
                VideoId = video.id,
                ToutorId = selectTutor.id,
            };
            bool x1 = _tuotorVideoRelService.AddTuotorVideoRel(tuotorVideoRel);
            return RedirectToAction("Index");
        }
        public ActionResult ViewProfile()
        {
            var selectUser = _userPass.SelectUserPassByUsername(User.Identity.Name);
            var selectTutor = _tutor.SelectTutorByUserPassId(selectUser.id);

            return PartialView(selectTutor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult ViewProfile(TblTutor tutor, HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                TblTutor selectTutor = _tutor.SelectTutorById(tutor.id);
                string fullPathLogo = Request.MapPath("/Resources/Tutor/" + selectTutor.MainImage);
                if (System.IO.File.Exists(fullPathLogo))
                {
                    System.IO.File.Delete(fullPathLogo);
                }
                tutor.MainImage = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                Image.SaveAs(Server.MapPath("/Resources/Tutor/" + tutor.MainImage));

                tutor.Description = selectTutor.Description;
                tutor.IdentificationNo = selectTutor.IdentificationNo;
                tutor.Name = selectTutor.Name;
                tutor.TellNo = selectTutor.TellNo;
                tutor.UserPassId = selectTutor.UserPassId;
                _tutor.UpdateTutor(tutor, tutor.id);
                return RedirectToAction("Index");
            }
            return View(tutor);
        }
        public ActionResult VideoBlock()
        {
            var selectUser = _userPass.SelectUserPassByUsername(User.Identity.Name);
            var selectTutor = _tutor.SelectTutorByUserPassId(selectUser.id);
            var selectVideoByToturId = _tuotorVideoRelService.SelectTuotorVideoRelByToutorId(selectTutor.id);
            List<TblVideo> selectVideoById = new List<TblVideo>();
            selectVideoByToturId.ForEach(i => selectVideoById.Add(_video.SelectVideoById(i.VideoId)));
            return PartialView(selectVideoById);
        }


        public ActionResult DeleteVideo(int id)
        {
            TblVideo selectVideo = _video.SelectVideoById(id);
            string fullPathImage = Request.MapPath("/Resources/Videos/Image/" + selectVideo.MainImage);
            string fullPathVideo = Request.MapPath("/Resources/Videos/" + selectVideo.VideoUrl);
            string fullPathVideoDemo = Request.MapPath("/Resources/Videos/Demo/" + selectVideo.VidioDemoUrl);
            if (System.IO.File.Exists(fullPathImage))
            {
                System.IO.File.Delete(fullPathImage);
            }
            if (System.IO.File.Exists(fullPathVideo))
            {
                System.IO.File.Delete(fullPathVideo);
            }
            if (System.IO.File.Exists(fullPathVideoDemo))
            {
                System.IO.File.Delete(fullPathVideoDemo);
            };
            bool del = _video.DeleteVideo(id);
            return JavaScript("");
        }

        public ActionResult EditVideo(int id)
        {
            return PartialView(_video.SelectVideoById(id));
        }
        [HttpPost]
        public ActionResult EditVideo(TblVideo video, HttpPostedFileBase VideoUrl, HttpPostedFileBase VidioDemoUrl, HttpPostedFileBase MainImage)
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
                    System.IO.File.Delete(Server.MapPath("/Resources/Videos/Demo/" + video.VidioDemoUrl));
                }
                video.VidioDemoUrl = Guid.NewGuid().ToString() + Path.GetExtension(VidioDemoUrl.FileName);
                VidioDemoUrl.SaveAs(Server.MapPath("/Resources/Videos/Demo/" + video.VidioDemoUrl));
            }
            bool b1 = _video.UpdateVideo(video, video.id);
            return RedirectToAction("Index");
        }
    }
}