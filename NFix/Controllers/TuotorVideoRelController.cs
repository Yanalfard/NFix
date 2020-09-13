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
    [RoutePrefix("api/TuotorVideoRelCore")]
    public class TuotorVideoRelController : ApiController
    {
        [Route("AddTuotorVideoRel")]
        [HttpPost]
        public IHttpActionResult AddTuotorVideoRel(TblTuotorVideoRel tuotorVideoRel)
        {
            var task = Task.Run(() => new TuotorVideoRelService().AddTuotorVideoRel(tuotorVideoRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblTuotorVideoRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteTuotorVideoRel")]
        [HttpPost]
        public IHttpActionResult DeleteTuotorVideoRel(int id)
        {
            var task = Task.Run(() => new TuotorVideoRelService().DeleteTuotorVideoRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateTuotorVideoRel")]
        [HttpPost]
        public IHttpActionResult UpdateTuotorVideoRel(List<object> tuotorVideoRelLogId)
        {
            TblTuotorVideoRel tuotorVideoRel = JsonConvert.DeserializeObject<TblTuotorVideoRel>(tuotorVideoRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(tuotorVideoRelLogId[1].ToString());
            var task = Task.Run(() => new TuotorVideoRelService().UpdateTuotorVideoRel(tuotorVideoRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllTuotorVideoRels")]
        [HttpGet]
        public IHttpActionResult SelectAllTuotorVideoRels()
        {
            var task = Task.Run(() => new TuotorVideoRelService().SelectAllTuotorVideoRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblTuotorVideoRel> dto = new List<DtoTblTuotorVideoRel>();
                    foreach (TblTuotorVideoRel obj in task.Result)
                        dto.Add(new DtoTblTuotorVideoRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTuotorVideoRelById")]
        [HttpPost]
        public IHttpActionResult SelectTuotorVideoRelById(int id)
        {
            var task = Task.Run(() => new TuotorVideoRelService().SelectTuotorVideoRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblTuotorVideoRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTuotorVideoRelByToutorId")]
        [HttpPost]
        public IHttpActionResult SelectTuotorVideoRelByToutorId(int torId)
        {
            var task = Task.Run(() => new TuotorVideoRelService().SelectTuotorVideoRelByToutorId(torId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblTuotorVideoRel> dto = new List<DtoTblTuotorVideoRel>();
                    foreach (TblTuotorVideoRel obj in task.Result)
                        dto.Add(new DtoTblTuotorVideoRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTuotorVideoRelByVideoId")]
        [HttpPost]
        public IHttpActionResult SelectTuotorVideoRelByVideoId(int eoId)
        {
            var task = Task.Run(() => new TuotorVideoRelService().SelectTuotorVideoRelByVideoId(eoId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblTuotorVideoRel> dto = new List<DtoTblTuotorVideoRel>();
                    foreach (TblTuotorVideoRel obj in task.Result)
                        dto.Add(new DtoTblTuotorVideoRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
