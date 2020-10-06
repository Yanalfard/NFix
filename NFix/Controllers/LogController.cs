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
    [RoutePrefix("api/LogCore")]
    public class LogController : ApiController
    {
        [Route("AddLog")]
        [HttpPost]
        public IHttpActionResult AddLog(TblLog log)
        {
            var task = Task.Run(() => new LogService().AddLog(log));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteLog")]
        [HttpPost]
        public IHttpActionResult DeleteLog(int id)
        {
            var task = Task.Run(() => new LogService().DeleteLog(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateLog")]
        [HttpPost]
        public IHttpActionResult UpdateLog(List<object> logLogId)
        {
            TblLog log = JsonConvert.DeserializeObject<TblLog>(logLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(logLogId[1].ToString());
            var task = Task.Run(() => new LogService().UpdateLog(log, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllLogs")]
        [HttpGet]
        public IHttpActionResult SelectAllLogs()
        {
            var task = Task.Run(() => new LogService().SelectAllLogs());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblLog> dto = new List<DtoTblLog>();
                    foreach (TblLog obj in task.Result)
                        dto.Add(new DtoTblLog(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectLogById")]
        [HttpPost]
        public IHttpActionResult SelectLogById(int id)
        {
            var task = Task.Run(() => new LogService().SelectLogById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblLog(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
