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
    [RoutePrefix("api/VideoCore")]
    public class VideoController : ApiController
    {
        [Route("AddVideo")]
        [HttpPost]
        public IHttpActionResult AddVideo(TblVideo video)
        {
            var task = Task.Run(() => new VideoService().AddVideo(video));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblVideo(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteVideo")]
        [HttpPost]
        public IHttpActionResult DeleteVideo(int id)
        {
            var task = Task.Run(() => new VideoService().DeleteVideo(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateVideo")]
        [HttpPost]
        public IHttpActionResult UpdateVideo(List<object> videoLogId)
        {
            TblVideo video = JsonConvert.DeserializeObject<TblVideo>(videoLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(videoLogId[1].ToString());
            var task = Task.Run(() => new VideoService().UpdateVideo(video, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllVideos")]
        [HttpGet]
        public IHttpActionResult SelectAllVideos()
        {
            var task = Task.Run(() => new VideoService().SelectAllVideos());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblVideo> dto = new List<DtoTblVideo>();
                    foreach (TblVideo obj in task.Result)
                        dto.Add(new DtoTblVideo(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectVideoById")]
        [HttpPost]
        public IHttpActionResult SelectVideoById(int id)
        {
            var task = Task.Run(() => new VideoService().SelectVideoById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblVideo(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectVideoByTitle")]
        [HttpPost]
        public IHttpActionResult SelectVideoByTitle(string title)
        {
            var task = Task.Run(() => new VideoService().SelectVideoByTitle(title));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblVideo(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectVideoByIsOnline")]
        [HttpPost]
        public IHttpActionResult SelectVideoByIsOnline(bool isOnline)
        {
            var task = Task.Run(() => new VideoService().SelectVideoByIsOnline(isOnline));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblVideo> dto = new List<DtoTblVideo>();
                    foreach (TblVideo obj in task.Result)
                        dto.Add(new DtoTblVideo(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectVideoByIsHome")]
        [HttpPost]
        public IHttpActionResult SelectVideoByIsHome(bool isHome)
        {
            var task = Task.Run(() => new VideoService().SelectVideoByIsHome(isHome));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblVideo> dto = new List<DtoTblVideo>();
                    foreach (TblVideo obj in task.Result)
                        dto.Add(new DtoTblVideo(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
