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
        private TuotorVideoRelService _tuotorVideoRel = new TuotorVideoRelService();
        private VideoCatagoryService _videoCatagory = new VideoCatagoryService();
        private ClientService _client = new ClientService();
        private CommentService _comment = new CommentService();
        private VideoCommentRelService _videoComment = new VideoCommentRelService();

        public ActionResult VideoTable(int? id)
        {
            if (id != null)
            {
                List<TblVideo> tblVideo = new List<TblVideo>();
                _tuotorVideoRel.SelectTuotorVideoRelByToutorId(id.Value).ForEach(i => tblVideo.Add(_video.SelectVideoById(i.VideoId)));
                return View(tblVideo);
            }
            var allVideo = _video.SelectAllVideos();
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
            bool b1 = _video.AddVideo(video);
            return RedirectToAction("VideoTable");
        }
        public ActionResult VideoEdit(int id)
        {
            var video = _video.SelectVideoById(id);
            ViewBag.Tags = string.Join("،", video.TblVideoKeyword.Select(t => t.Name).ToList());
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
            bool b1 = _video.UpdateVideo(video, video.id);
            return RedirectToAction("VideoTable");
        }
        public ActionResult DeleteVideo(int id)
        {
            bool del = _video.DeleteVideo(id);
            return JavaScript("");
        }
        public ActionResult VideoComments(int? id)
        {
            List<TblComment> allComments = new List<TblComment>();
            if (id == null)
            {
                _videoComment.SelectAllVideoCommentRels().ForEach(i => allComments.Add(_comment.SelectCommentById(i.CommentId)));
            }
            else
            {
                _videoComment.SelectVideoCommentRelByVideoId(id.Value).ForEach(i => allComments.Add(_comment.SelectCommentById(i.CommentId)));
            }
            return View(allComments);
        }
        public ActionResult ViewClientInfo(int id)
        {
            var c = _client.SelectClientById(id);
            return PartialView(_client.SelectClientById(id));
        }
        public ActionResult ShowHideComments(int id, int videoId)
        {
            TblComment selectCommentById = _comment.SelectCommentById(id);
            if (selectCommentById.IsValid)
            {
                selectCommentById.IsValid = false;
            }
            else
            {
                selectCommentById.IsValid = true;
            }
            TblComment tblComment = new TblComment()
            {
                Body = selectCommentById.Body,
                ClientId = selectCommentById.ClientId,
                id = selectCommentById.id,
                IsValid = selectCommentById.IsValid,
                DateSubmited = selectCommentById.DateSubmited,

            };

            bool x = _comment.UpdateComment(tblComment, id);
            return RedirectToAction("VideoComments/" + videoId);
        }
        public ActionResult DeleteComment(int id)
        {
            _comment.DeleteComment(id);
            return JavaScript("");
        }
        public ActionResult VideoKeyWords()
        {
            return View();
        }
        #endregion
    }
}