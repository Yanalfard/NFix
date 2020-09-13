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
    [RoutePrefix("api/CommentCore")]
    public class CommentController : ApiController
    {
        [Route("AddComment")]
        [HttpPost]
        public IHttpActionResult AddComment(TblComment comment)
        {
            var task = Task.Run(() => new CommentService().AddComment(comment));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblComment(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteComment")]
        [HttpPost]
        public IHttpActionResult DeleteComment(int id)
        {
            var task = Task.Run(() => new CommentService().DeleteComment(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateComment")]
        [HttpPost]
        public IHttpActionResult UpdateComment(List<object> commentLogId)
        {
            TblComment comment = JsonConvert.DeserializeObject<TblComment>(commentLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(commentLogId[1].ToString());
            var task = Task.Run(() => new CommentService().UpdateComment(comment, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllComments")]
        [HttpGet]
        public IHttpActionResult SelectAllComments()
        {
            var task = Task.Run(() => new CommentService().SelectAllComments());
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
        [Route("SelectCommentById")]
        [HttpPost]
        public IHttpActionResult SelectCommentById(int id)
        {
            var task = Task.Run(() => new CommentService().SelectCommentById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblComment(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectCommentByClientId")]
        [HttpPost]
        public IHttpActionResult SelectCommentByClientId(int clientId)
        {
            var task = Task.Run(() => new CommentService().SelectCommentByClientId(clientId));
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
        [Route("SelectCommentByIsValid")]
        [HttpPost]
        public IHttpActionResult SelectCommentByIsValid(bool isValid)
        {
            var task = Task.Run(() => new CommentService().SelectCommentByIsValid(isValid));
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

    }
}
