using DataLayer.Models.Dto;
using DataLayer.Models.Regular;
using DataLayer.Services.Api;
using DataLayer.Services.Impl;
using DataLayer.Utilities;
using DataLayer.ViewModel;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NFix.Controllers
{
    public class HomeVideoController : Controller
    {
        private VideoService _video = new VideoService();
        private ClientService _client = new ClientService();
        private UserPassService _userPass = new UserPassService();
        private CommentService _comment = new CommentService();
        private VideoCommentRelService _videoComment = new VideoCommentRelService();
        private VideoKeywordService _videoKeywords = new VideoKeywordService();

        public HomeVideoController()
        {

        }
        // GET: HomeVideo
        public ActionResult VideosPage()
        {
            var allVideo = _video.SelectAllVideos();
            return PartialView(allVideo.OrderByDescending(i => i.DateSubmited).Take(20));
        }
        public ActionResult AllVideos()
        {
            var allVideo = _video.SelectAllVideos();
            return View(allVideo.OrderByDescending(i => i.DateSubmited));
        }
        [Route("VideoView/{id}/{title}")]
        public ActionResult VideoView(int id, string title)
        {
            ViewBag.Title = title;
            TblVideo selectVideoById = _video.SelectVideoById(id);
            TblVideo tblVideo = new TblVideo();
            tblVideo.ViewCount = selectVideoById.ViewCount + 1;
            tblVideo.DateSubmited = selectVideoById.DateSubmited;
            tblVideo.Description = selectVideoById.Description;
            tblVideo.DescriptionDemo = selectVideoById.DescriptionDemo;
            tblVideo.id = selectVideoById.id;
            tblVideo.IsHome = selectVideoById.IsHome;
            tblVideo.IsOnline = selectVideoById.IsOnline;
            tblVideo.MainImage = selectVideoById.MainImage;
            tblVideo.Raiting = selectVideoById.Raiting;
            tblVideo.ShareLink = selectVideoById.ShareLink;
            tblVideo.Title = selectVideoById.Title;
            tblVideo.VideoUrl = selectVideoById.VideoUrl;
            tblVideo.VidioDemoUrl = selectVideoById.VidioDemoUrl;
            bool x = _video.UpdateVideo(tblVideo, selectVideoById.id);
            //ViewBag.Keywords = string.Join("،", selectVideoById.TblVideoKeyword.Select(t => t.Name).ToList());
            //  ViewBag.Tags = string.Join(".", products.Product_Tags.Select(t => t.Tag).ToList());

            VideoViewViewModel result = new VideoViewViewModel()
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
                TutorName = selectVideoById.TblTuotorVideoRel.SingleOrDefault().TblTutor.Name,
                TutorMainImage = selectVideoById.TblTuotorVideoRel.SingleOrDefault().TblTutor.MainImage,
                TutorSpecialty = selectVideoById.TblTuotorVideoRel.SingleOrDefault().TblTutor.Specialty,
                Keywords = string.Join("،", selectVideoById.TblVideoKeyword.Select(t => t.Name).ToList()),
            };
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("user"))
                {

                    TblUserPass tblUserPass = _userPass.SelectUserPassByUsername(User.Identity.Name);
                    TblClient tblClient = _client.SelectClientByUserPassId(tblUserPass.id);
                    result.UserName = User.Identity.Name;
                    result.IsPremium = tblClient.IsPremium;
                    result.UserPassId = tblUserPass.id;
                }
            }
            return View(result);
        }
        public ActionResult CreateComment(int id)
        {
            try
            {
                return PartialView(new CommentViewModel()
                {
                    VideoId = id,
                });
            }
            catch
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateComment(CommentViewModel comment)
        {
            try
            {
                TblUserPass tblUserPass = _userPass.SelectUserPassByUsername(User.Identity.Name);
                TblClient tblClient = _client.SelectClientByUserPassId(tblUserPass.id);
                if (tblClient == null)
                {
                    return JavaScript("UIkit.notification('شما مجاز به ثبت پیام نیستید')");
                }
                TblComment tblComment = new TblComment();
                tblComment.Body = comment.Body;
                tblComment.ClientId = tblClient.id;
                tblComment.IsValid = false;
                tblComment.DateSubmited = DateTime.Now.ToString();

                bool x = _comment.AddComment(tblComment);
                TblVideoCommentRel tblVideoCommentRel = new TblVideoCommentRel()
                {
                    CommentId = tblComment.id,
                    VideoId = comment.VideoId,
                };
                bool y = _videoComment.AddVideoCommentRel(tblVideoCommentRel);

                comment.Raiting *= 20;
                TblVideo video = _video.SelectVideoById(comment.VideoId);
                int count = _videoComment.SelectVideoCommentRelByVideoId(comment.VideoId).ToList().Count;
                if (count == 0)
                {
                    video.Raiting = comment.Raiting;
                }
                else
                {
                    video.Raiting = Convert.ToInt32((video.Raiting * (count - 1) + comment.Raiting) / count);
                }
                TblVideo updateVideo = new TblVideo()
                {
                    id = video.id,
                    DateSubmited = video.DateSubmited,
                    Description = video.Description,
                    DescriptionDemo = video.DescriptionDemo,
                    IsHome = video.IsHome,
                    IsOnline = video.IsOnline,
                    MainImage = video.MainImage,
                    Raiting = video.Raiting,
                    ShareLink = video.ShareLink,
                    Title = video.Title,
                    VideoUrl = video.VideoUrl,
                    VidioDemoUrl = video.VidioDemoUrl,
                    ViewCount = video.ViewCount,
                };

                bool dd = _video.UpdateVideo(updateVideo, video.id);

                List<TblComment> List = new List<TblComment>();
                _videoComment.SelectVideoCommentRelByVideoId(comment.VideoId).ForEach(i => List.Add(_comment.SelectCommentById(i.CommentId)));
                return PartialView("ShowComments", List.Where(i => i.IsValid == true).OrderByDescending(i => i.DateSubmited));

            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }
        public ActionResult ShowComments(int id)
        {
            try
            {
                List<TblComment> List = new List<TblComment>();
                _videoComment.SelectVideoCommentRelByVideoId(id).ForEach(i => List.Add(_comment.SelectCommentById(i.CommentId)));
                return PartialView(List.Where(i => i.IsValid == true).OrderByDescending(i => i.DateSubmited));
            }
            catch
            {
                return HttpNotFound();
            }

        }
        public ActionResult VideoRecommendations(string Keywords, string Title)
        {
            List<TblVideo> list = new List<TblVideo>();
            foreach (var item in Keywords.Split('،'))
            {
                // list.AddRange(_videoKeywords.SelectAllVideoKeywords().Where(t => t.Name.Contains(item)).Select(t => t.TblVideo).ToList());
                list = _videoKeywords.SelectAllVideoKeywords().Where(t => t.Name.Contains(item)).Select(t => t.TblVideo).ToList();
                // list.AddRange(_video.SelectAllVideos().Where(i => i.Title.Contains(Keywords) || i.DescriptionDemo.Contains(Keywords) || i.Description.Contains(Keywords)).Distinct());
            }
            list = _video.SelectAllVideos().Where(i => i.Title.Contains(Title) || i.DescriptionDemo.Contains(Title) || i.Description.Contains(Title)).ToList();
            return PartialView(list.Distinct().Take(5));
        }
    }
}