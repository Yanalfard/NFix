using DataLayer;
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
            if (MainImage != null)
            {
                blog.MainImage = Guid.NewGuid().ToString() + Path.GetExtension(MainImage.FileName);
                MainImage.SaveAs(Server.MapPath("/Resources/Blogs/" + blog.MainImage));
            }
            blog.LikeCount = 0;

            _blog.AddBlog(new TblBlog()
            {
                Body = blog.Body,
                Description=blog.Description,
                LikeCount=blog.LikeCount,
                MainImage=blog.MainImage,
                Title=blog.Title,
                
            });
            return View(blog);
        }
        public ActionResult BlogComments()
        {
            return View();
        }

        public ActionResult BlogKeyWords()
        {
            return View();
        }

        #endregion

    }
}