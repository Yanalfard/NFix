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
    [RoutePrefix("api/ImageCore")]
    public class ImageController : ApiController
    {
        [Route("AddImage")]
        [HttpPost]
        public IHttpActionResult AddImage(TblImage image)
        {
            var task = Task.Run(() => new ImageService().AddImage(image));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblImage(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteImage")]
        [HttpPost]
        public IHttpActionResult DeleteImage(int id)
        {
            var task = Task.Run(() => new ImageService().DeleteImage(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateImage")]
        [HttpPost]
        public IHttpActionResult UpdateImage(List<object> imageLogId)
        {
            TblImage image = JsonConvert.DeserializeObject<TblImage>(imageLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(imageLogId[1].ToString());
            var task = Task.Run(() => new ImageService().UpdateImage(image, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllImages")]
        [HttpGet]
        public IHttpActionResult SelectAllImages()
        {
            var task = Task.Run(() => new ImageService().SelectAllImages());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblImage> dto = new List<DtoTblImage>();
                    foreach (TblImage obj in task.Result)
                        dto.Add(new DtoTblImage(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectImageById")]
        [HttpPost]
        public IHttpActionResult SelectImageById(int id)
        {
            var task = Task.Run(() => new ImageService().SelectImageById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblImage(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectImageByImage")]
        [HttpPost]
        public IHttpActionResult SelectImageByImage(string image)
        {
            var task = Task.Run(() => new ImageService().SelectImageByImage(image));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblImage(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
