using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using Newtonsoft.Json;

namespace NFix.Controllers
{
    [RoutePrefix("api/BlogCore")]
    public class BlogController : ApiController
    {
        [Route("AddBlog")]
        [HttpPost]
        public IHttpActionResult AddBlog(TblBlog blog)
        {
            var task = Task.Run(() => new BlogService().AddBlog(blog));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteBlog")]
        [HttpPost]
        public IHttpActionResult DeleteBlog(int id)
        {
            var task = Task.Run(() => new BlogService().DeleteBlog(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateBlog")]
        [HttpPost]
        public IHttpActionResult UpdateBlog(List<object> blogLogId)
        {
            TblBlog blog = JsonConvert.DeserializeObject<TblBlog>(blogLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(blogLogId[1].ToString());
            var task = Task.Run(() => new BlogService().UpdateBlog(blog, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllBlogs")]
        [HttpGet]
        public IHttpActionResult SelectAllBlogs()
        {
            var task = Task.Run(() => new BlogService().SelectAllBlogs());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblBlog> dto = new List<DtoTblBlog>();
                    foreach (TblBlog obj in task.Result)
                        dto.Add(new DtoTblBlog(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectBlogById")]
        [HttpPost]
        public IHttpActionResult SelectBlogById(int id)
        {
            var task = Task.Run(() => new BlogService().SelectBlogById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblBlog(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectCommentByBlogId")]
        [HttpPost]
        public IHttpActionResult SelectCommentByBlogId(int blogId)
        {
            var task = Task.Run(() => new BlogService().SelectCommentsByBlogId(blogId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblComment> dto = new List<DtoTblComment>();
                    foreach (TblComment obj in task.Result)
                        dto.Add(new DtoTblComment(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectKeywordByBlogId")]
        [HttpPost]
        public IHttpActionResult SelectKeywordByBlogId(int blogId)
        {
            var task = Task.Run(() => new BlogService().SelectKeywordsByBlogId(blogId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblKeyword> dto = new List<DtoTblKeyword>();
                    foreach (TblKeyword obj in task.Result)
                        dto.Add(new DtoTblKeyword(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
