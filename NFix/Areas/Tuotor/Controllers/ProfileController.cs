using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace NFix.Areas.Tuotor.Controllers
{
    public class ProfileController : Controller
    {
        private UserPassService _userPass = new UserPassService();
        private TutorService _tutor = new TutorService();
        private VideoService _video = new VideoService();
        private TuotorVideoRelService _tuotorVideoRelService = new TuotorVideoRelService();
        private VideoCatagoryService _videoCatagory = new VideoCatagoryService();

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
            ViewBag.CatagoryId = new SelectList(_videoCatagory.SelectAllVideoCatagorys(), "id", "Name");
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

            TblTutor selectTutor = _tutor.SelectTutorById(tutor.id);

            selectTutor.Description = tutor.Description;
            selectTutor.IdentificationNo = tutor.IdentificationNo;
            selectTutor.Name = tutor.Name;
            selectTutor.id = tutor.id;
            selectTutor.Specialty = tutor.Specialty;
            selectTutor.TellNo = tutor.TellNo;
            selectTutor.UserPassId = tutor.UserPassId;
            selectTutor.MainImage = tutor.MainImage;
            bool d=_tutor.UpdateTutor(tutor, tutor.id);
            var isAjax = this.Request.IsAjaxRequest();

            return Json(new { result = "ok", Id = selectTutor.id }, JsonRequestBehavior.AllowGet);


            //return JavaScript("doneEdit();");
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
            TblVideo tblVideo = _video.SelectVideoById(id);
            ViewBag.CatagoryId = new SelectList(_videoCatagory.SelectAllVideoCatagorys(), "id", "Name", tblVideo.CatagoryId);

            return PartialView(tblVideo);
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


        public ActionResult EditPass()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPass(ChangePasswordViewModel changePass)
        {
            if (ModelState.IsValid)
            {
                string hassPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(changePass.OldPassword, "SHA256");
                TblUserPass selectUser = _userPass.SelectUserPassByUsername(User.Identity.Name);
                TblTutor selectTutor = _tutor.SelectTutorByUserPassId(selectUser.id);
                TblUserPass chechUser = _userPass.SelectUserPassByUsernameAndPassword(selectUser.Username, hassPassword);
                if (chechUser != null)
                {
                    TblUserPass tblUser = new TblUserPass()
                    {
                        id = selectUser.id,
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(changePass.Password, "SHA256"),
                        Auth = selectUser.Auth,
                        IsActive = selectUser.IsActive,
                        RoleId = selectUser.RoleId,
                        Username = selectUser.Username,
                    };
                    bool x = _userPass.UpdateUserPass(tblUser, selectUser.id);
                    return JavaScript("UIkit.modal(document.getElementById('ModalChangePassword')).hide();doneEdit();");

                }
                else
                {
                    ModelState.AddModelError("OldPassword", "رمز قدیمی اشتباه می باشد");
                }
            }
            return PartialView("EditPass", changePass);
        }


        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase Image, int id)
        {

            if (Image != null)
            {
                var isAjax = this.Request.IsAjaxRequest();
                // Thread.Sleep(3000); // simulating a long running process
                TblTutor selectTutor = _tutor.SelectTutorById(id);
                TblTutor tblTutor = new TblTutor();
                selectTutor.MainImage = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                Image.SaveAs(Server.MapPath("/Resources/Tutor/" + selectTutor.MainImage));
                tblTutor.Description = selectTutor.Description;
                tblTutor.IdentificationNo = selectTutor.IdentificationNo;
                tblTutor.Name = selectTutor.Name;
                tblTutor.id = selectTutor.id;
                tblTutor.Specialty = selectTutor.Specialty;
                tblTutor.TellNo = selectTutor.TellNo;
                tblTutor.UserPassId = selectTutor.UserPassId;
                tblTutor.MainImage = selectTutor.MainImage;
                bool d = _tutor.UpdateTutor(tblTutor, selectTutor.id);
            }
            return RedirectToAction("Index");
            //return JavaScript("location.reload(true)");
          //  return Json(new { FileName = "/Uploads/filename.ext" }, "text/html", JsonRequestBehavior.AllowGet);
        }
    }
}