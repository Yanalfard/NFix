using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Repositories.Impl;
using DataLayer.Repositories.Api;
using DataLayer.Services.Api;
using DataLayer.Services.Impl;
using DataLayer.Models.Dto;
using DataLayer.Utilities;
using DataLayer.Models.Regular;
using DataLayer.ViewModel;

namespace NFix.Controllers
{
    public class HomeBlogsController : Controller
    {
        private BlogService _blog;
        private ClientService _client = new ClientService();
        private UserPassService _userPass = new UserPassService();
        private CommentService _comment = new CommentService();
        private BlogCommentRelService _blogComment = new BlogCommentRelService();
        public HomeBlogsController()
        {
            _blog = new BlogService();
        }
        // GET: HomeBlogs
        [ChildActionOnly]
        public ActionResult BlogsPage()
        {
            var allBlog = _blog.SelectAllBlogs();
            return PartialView(allBlog.OrderByDescending(i=>i.id).Take(20));
        }
        [Route("AllBlogs")]
        public ActionResult AllBlogs()
        {
            var allBlog = _blog.SelectAllBlogs();
            return PartialView(allBlog.OrderByDescending(i => i.id));
        }
        [Route("BlogView/{id}/{Title}")]
        public ActionResult BlogView(int id, string Title)
        {
            ViewBag.Description = Title;
            TblBlog selectBlogById = _blog.SelectBlogById(id);
            return View(selectBlogById);
        }
        public ActionResult CreateComment(int id)
        {
            try
            {
                return PartialView(new CommentViewModel()
                {
                    BlogId = id,
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
                TblBlogCommentRel tblBlogCommentRel = new TblBlogCommentRel()
                {
                    CommentId = tblComment.id,
                    BlogId = comment.BlogId,
                };
                bool y = _blogComment.AddBlogCommentRel(tblBlogCommentRel);
                List<TblComment> List = new List<TblComment>();
                _blogComment.SelectBlogCommentRelByBlogId(comment.BlogId).ForEach(i => List.Add(_comment.SelectCommentById(i.CommentId)));
                return PartialView("ShowComments", List.Where(i => i.IsValid == true).OrderByDescending(i => i.DateSubmited));

            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
        public ActionResult ShowComments(int id)
        {
            try
            {
                List<TblComment> List = new List<TblComment>();
                _blogComment.SelectBlogCommentRelByBlogId(id).ForEach(i => List.Add(_comment.SelectCommentById(i.CommentId)));
                return PartialView(List.Where(i => i.IsValid == true).OrderByDescending(i => i.DateSubmited));
            }
            catch
            {
                return HttpNotFound();
            }

        }


        public ActionResult AddLikeBlog(int id)
        {
            TblBlog selectBlogById = _blog.SelectBlogById(id);
            selectBlogById.LikeCount += 1;
            TblBlog tblBlog = new TblBlog()
            {
                Body= selectBlogById.Body,
                Description= selectBlogById.Description,
                id= selectBlogById.id,
                LikeCount=selectBlogById.LikeCount,
                MainImage=selectBlogById.MainImage,
                Title=selectBlogById.Title
            };

            bool s = _blog.UpdateBlog(tblBlog, id);
            return PartialView("BlogView", _blog.SelectBlogById(id));

        }
    }
}