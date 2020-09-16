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
    [RoutePrefix("api/BlogCommentRelCore")]
    public class BlogCommentRelController : ApiController
    {
        [Route("AddBlogCommentRel")]
        [HttpPost]
        public IHttpActionResult AddBlogCommentRel(TblBlogCommentRel blogCommentRel)
        {
            var task = Task.Run(() => new BlogCommentRelService().AddBlogCommentRel(blogCommentRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblBlogCommentRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteBlogCommentRel")]
        [HttpPost]
        public IHttpActionResult DeleteBlogCommentRel(int id)
        {
            var task = Task.Run(() => new BlogCommentRelService().DeleteBlogCommentRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateBlogCommentRel")]
        [HttpPost]
        public IHttpActionResult UpdateBlogCommentRel(List<object> blogCommentRelLogId)
        {
            TblBlogCommentRel blogCommentRel = JsonConvert.DeserializeObject<TblBlogCommentRel>(blogCommentRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(blogCommentRelLogId[1].ToString());
            var task = Task.Run(() => new BlogCommentRelService().UpdateBlogCommentRel(blogCommentRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllBlogCommentRels")]
        [HttpGet]
        public IHttpActionResult SelectAllBlogCommentRels()
        {
            var task = Task.Run(() => new BlogCommentRelService().SelectAllBlogCommentRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblBlogCommentRel> dto = new List<DtoTblBlogCommentRel>();
                    foreach (TblBlogCommentRel obj in task.Result)
                        dto.Add(new DtoTblBlogCommentRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectBlogCommentRelById")]
        [HttpPost]
        public IHttpActionResult SelectBlogCommentRelById(int id)
        {
            var task = Task.Run(() => new BlogCommentRelService().SelectBlogCommentRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblBlogCommentRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectBlogCommentRelByBlogId")]
        [HttpPost]
        public IHttpActionResult SelectBlogCommentRelByBlogId(int gId)
        {
            var task = Task.Run(() => new BlogCommentRelService().SelectBlogCommentRelByBlogId(gId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblBlogCommentRel> dto = new List<DtoTblBlogCommentRel>();
                    foreach (TblBlogCommentRel obj in task.Result)
                        dto.Add(new DtoTblBlogCommentRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectBlogCommentRelByCommentId")]
        [HttpPost]
        public IHttpActionResult SelectBlogCommentRelByCommentId(int mentId)
        {
            var task = Task.Run(() => new BlogCommentRelService().SelectBlogCommentRelByCommentId(mentId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblBlogCommentRel> dto = new List<DtoTblBlogCommentRel>();
                    foreach (TblBlogCommentRel obj in task.Result)
                        dto.Add(new DtoTblBlogCommentRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
