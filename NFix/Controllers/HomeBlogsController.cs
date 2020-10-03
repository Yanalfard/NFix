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

namespace NFix.Controllers
{
    public class HomeBlogsController : Controller
    {
        private BlogService _blog;
        public HomeBlogsController()
        {
            _blog = new BlogService();
        }
        // GET: HomeBlogs
        [ChildActionOnly]
        public ActionResult BlogsPage()
        {
            var allBlog = _blog.SelectAllBlogs();
            List<DtoTblBlog> result = MethodRepo.ConvertToDto<TblBlog, DtoTblBlog>(allBlog);
            return PartialView(result);
        }

        public ActionResult BlogView(int id)
        {
            TblBlog selectBlogById = _blog.SelectBlogById(id);
            DtoTblBlog result = new DtoTblBlog
            {
                id = selectBlogById.id,
                Body = selectBlogById.Body,
                MainImage = selectBlogById.MainImage,
                LikeCount = selectBlogById.LikeCount
            };
            return View(result);
        }
    }
}