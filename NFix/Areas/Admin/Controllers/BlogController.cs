﻿using DataLayer;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private BlogService _blog = new BlogService();
        private KeywordService _keyword = new KeywordService();
        private BlogKeywordRelService _blogKeyword = new BlogKeywordRelService();
        private ClientService _client = new ClientService();
        private CommentService _comment = new CommentService();
        private BlogCommentRelService _blogComment = new BlogCommentRelService();

        // GET: Admin/Blog
        #region Blog

        public ActionResult BlogTable()
        {
            return View(_blog.SelectAllBlogs());
        }

        public ActionResult BlogAdder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BlogAdder(BlogViewModel blog, HttpPostedFileBase MainImage)
        {
            if (blog.Body == "" || blog.Body == null)
            {
                ModelState.AddModelError("Body", "لطفا متن را وارد کنید");
                return View(blog);
            }
            if (MainImage != null)
            {
                blog.MainImage = Guid.NewGuid().ToString() + Path.GetExtension(MainImage.FileName);
                MainImage.SaveAs(Server.MapPath("/Resources/Blogs/" + blog.MainImage));
                ImageResizer img = new ImageResizer();
                img.Resize(Server.MapPath("/Resources/Blogs/" + blog.MainImage),
                    Server.MapPath("/Resources/Blogs/Thumb/" + blog.MainImage));
            }
            blog.LikeCount = 0;

            TblBlog addBlog = new TblBlog()
            {
                Body = blog.Body,
                Description = blog.Description,
                LikeCount = blog.LikeCount,
                MainImage = blog.MainImage,
                Title = blog.Title,
            };


            _blog.AddBlog(addBlog);
            string tags = blog.Keywords;
            if (!string.IsNullOrEmpty(tags))
            {
                if (tags[tags.Length - 1] == '،')
                {
                    tags = tags.Remove(tags.Length - 1);
                }
                List<TblKeyword> idKeywords = new List<TblKeyword>();
                string[] tag = tags.Split('،');
                foreach (string t in tag)
                {
                    TblKeyword addKeywords = new TblKeyword()
                    {
                        Name = t.Trim(),
                    };
                    _keyword.AddKeyword(addKeywords);
                    idKeywords.Add(addKeywords);

                }
                foreach (var item in idKeywords)
                {
                    _blogKeyword.AddBlogKeywordRel(new TblBlogKeywordRel()
                    {
                        KeywordId = item.id,
                        BlogId = addBlog.id,

                    });
                }
            }
            return RedirectToAction("BlogTable");
        }
        public ActionResult BlogEdit(int id)
        {
            TblBlog selectBlog = _blog.SelectBlogById(id);
            List<TblKeyword> selectBlogKeywords = new List<TblKeyword>();
            foreach (TblBlogKeywordRel j in _blogKeyword.SelectBlogKeywordRelByBlogId(id).ToList())
            {
                selectBlogKeywords.Add(_keyword.SelectKeywordById(j.KeywordId));
            }
            string AllKeys = "";
            foreach (var item in selectBlogKeywords)
            {
                AllKeys += item.Name + "،";
            }
            if (AllKeys != "")
            {
                AllKeys = AllKeys.Remove(AllKeys.Length - 1);
            }
            BlogViewModel blogView = new BlogViewModel()
            {
                id = selectBlog.id,
                Body = selectBlog.Body,
                Description = selectBlog.Description,
                Keywords = AllKeys,
                LikeCount = selectBlog.LikeCount,
                MainImage = selectBlog.MainImage,
                Title = selectBlog.Title
            };
            return View(blogView);
        }
        [HttpPost]
        public ActionResult BlogEdit(BlogViewModel blog, HttpPostedFileBase MainImage)
        {
            if (blog.Body == "" || blog.Body == null)
            {
                ModelState.AddModelError("Body", "لطفا متن را وارد کنید");
                return View(blog);
            }
            if (MainImage != null)
            {
                if (blog.MainImage != null)
                {
                    string fullPathLogo = Request.MapPath("/Resources/Blogs/" + blog.MainImage);
                    string fullPathLogo2 = Request.MapPath("/Resources/Blogs/" + blog.MainImage);
                    if (System.IO.File.Exists(fullPathLogo))
                    {
                        System.IO.File.Delete(fullPathLogo);
                    }
                    if (System.IO.File.Exists(fullPathLogo2))
                    {
                        System.IO.File.Delete(fullPathLogo2);
                    }
                }
                blog.MainImage = Guid.NewGuid().ToString() + Path.GetExtension(MainImage.FileName);
                MainImage.SaveAs(Server.MapPath("/Resources/Blogs/" + blog.MainImage));
                ImageResizer img = new ImageResizer();
                img.Resize(Server.MapPath("/Resources/Blogs/" + blog.MainImage),
                    Server.MapPath("/Resources/Blogs/Thumb/" + blog.MainImage));
            }

            TblBlog updateBlog = new TblBlog()
            {
                id = blog.id,
                Body = blog.Body,
                Description = blog.Description,
                LikeCount = blog.LikeCount,
                MainImage = blog.MainImage,
                Title = blog.Title,
            };


            bool va = _blog.UpdateBlog(updateBlog, blog.id);

            _blogKeyword.SelectBlogKeywordRelByBlogId(blog.id).ToList().ForEach(t => _keyword.DeleteKeyword(t.KeywordId));
            string tags = blog.Keywords;
            if (!string.IsNullOrEmpty(tags))
            {
                if (tags[tags.Length - 1] == '،')
                {
                    tags = tags.Remove(tags.Length - 1);
                }
                List<TblKeyword> idKeywords = new List<TblKeyword>();
                string[] tag = tags.Split('،');
                foreach (string t in tag)
                {
                    TblKeyword addKeywords = new TblKeyword()
                    {
                        Name = t.Trim(),
                    };
                    _keyword.AddKeyword(addKeywords);
                    idKeywords.Add(addKeywords);

                }
                foreach (var item in idKeywords)
                {
                    _blogKeyword.AddBlogKeywordRel(new TblBlogKeywordRel()
                    {
                        KeywordId = item.id,
                        BlogId = blog.id,

                    });
                }
            }
            return RedirectToAction("BlogTable");
        }
        public ActionResult BlogComments(int? id)
        {
            List<TblComment> allComments = new List<TblComment>();
            if (id == null)
            {
                _blogComment.SelectAllBlogCommentRels().ForEach(i => allComments.Add(_comment.SelectCommentById(i.CommentId)));
            }
            else
            {
                _blogComment.SelectBlogCommentRelByBlogId(id.Value).ForEach(i => allComments.Add(_comment.SelectCommentById(i.CommentId)));
            }
            return View(allComments);
        }

        public ActionResult ViewClientInfo(int id)
        {
            var c = _client.SelectClientById(id);
            return PartialView(_client.SelectClientById(id));
        }


        public ActionResult DeleteBlog(int id)
        {
            var getBlogId = _blog.SelectBlogById(id);
            _blog.DeleteBlog(id);
            string fullPathLogo = Request.MapPath("/Resources/Blogs/" + getBlogId.MainImage);
            if (System.IO.File.Exists(fullPathLogo))
            {
                System.IO.File.Delete(fullPathLogo);
            }
            string fullPathLogo2 = Request.MapPath("/Resources/Blogs/Thumb/" + getBlogId.MainImage);
            if (System.IO.File.Exists(fullPathLogo2))
            {
                System.IO.File.Delete(fullPathLogo2);
            }
            return JavaScript("");
        }
        #endregion

        public ActionResult ShowHideComments(int id, int blogId)
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
            return RedirectToAction("BlogComments/" + blogId);
        }


        public ActionResult DeleteComment(int id)
        {
            _comment.DeleteComment(id);
            return JavaScript("");
        }
    }
}