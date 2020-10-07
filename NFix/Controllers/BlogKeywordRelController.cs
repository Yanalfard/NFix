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
    [RoutePrefix("api/BlogKeywordRelCore")]
    public class BlogKeywordRelController : ApiController
    {
        [Route("AddBlogKeywordRel")]
        [HttpPost]
        public IHttpActionResult AddBlogKeywordRel(TblBlogKeywordRel blogKeywordRel)
        {
            var task = Task.Run(() => new BlogKeywordRelService().AddBlogKeywordRel(blogKeywordRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteBlogKeywordRel")]
        [HttpPost]
        public IHttpActionResult DeleteBlogKeywordRel(int id)
        {
            var task = Task.Run(() => new BlogKeywordRelService().DeleteBlogKeywordRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateBlogKeywordRel")]
        [HttpPost]
        public IHttpActionResult UpdateBlogKeywordRel(List<object> blogKeywordRelLogId)
        {
            TblBlogKeywordRel blogKeywordRel = JsonConvert.DeserializeObject<TblBlogKeywordRel>(blogKeywordRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(blogKeywordRelLogId[1].ToString());
            var task = Task.Run(() => new BlogKeywordRelService().UpdateBlogKeywordRel(blogKeywordRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllBlogKeywordRels")]
        [HttpGet]
        public IHttpActionResult SelectAllBlogKeywordRels()
        {
            var task = Task.Run(() => new BlogKeywordRelService().SelectAllBlogKeywordRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblBlogKeywordRel> dto = new List<DtoTblBlogKeywordRel>();
                    foreach (TblBlogKeywordRel obj in task.Result)
                        dto.Add(new DtoTblBlogKeywordRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectBlogKeywordRelById")]
        [HttpPost]
        public IHttpActionResult SelectBlogKeywordRelById(int id)
        {
            var task = Task.Run(() => new BlogKeywordRelService().SelectBlogKeywordRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblBlogKeywordRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectBlogKeywordRelByBlogId")]
        [HttpPost]
        public IHttpActionResult SelectBlogKeywordRelByBlogId(int gId)
        {
            var task = Task.Run(() => new BlogKeywordRelService().SelectBlogKeywordRelByBlogId(gId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblBlogKeywordRel> dto = new List<DtoTblBlogKeywordRel>();
                    foreach (TblBlogKeywordRel obj in task.Result)
                        dto.Add(new DtoTblBlogKeywordRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectBlogKeywordRelByKeywordId")]
        [HttpPost]
        public IHttpActionResult SelectBlogKeywordRelByKeywordId(int wordId)
        {
            var task = Task.Run(() => new BlogKeywordRelService().SelectBlogKeywordRelByKeywordId(wordId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblBlogKeywordRel> dto = new List<DtoTblBlogKeywordRel>();
                    foreach (TblBlogKeywordRel obj in task.Result)
                        dto.Add(new DtoTblBlogKeywordRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
