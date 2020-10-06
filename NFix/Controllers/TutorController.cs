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
    [RoutePrefix("api/TutorCore")]
    public class TutorController : ApiController
    {
        [Route("AddTutor")]
        [HttpPost]
        public IHttpActionResult AddTutor(TblTutor tutor)
        {
            var task = Task.Run(() => new TutorService().AddTutor(tutor));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteTutor")]
        [HttpPost]
        public IHttpActionResult DeleteTutor(int id)
        {
            var task = Task.Run(() => new TutorService().DeleteTutor(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateTutor")]
        [HttpPost]
        public IHttpActionResult UpdateTutor(List<object> tutorLogId)
        {
            TblTutor tutor = JsonConvert.DeserializeObject<TblTutor>(tutorLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(tutorLogId[1].ToString());
            var task = Task.Run(() => new TutorService().UpdateTutor(tutor, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllTutors")]
        [HttpGet]
        public IHttpActionResult SelectAllTutors()
        {
            var task = Task.Run(() => new TutorService().SelectAllTutors());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblTutor> dto = new List<DtoTblTutor>();
                    foreach (TblTutor obj in task.Result)
                        dto.Add(new DtoTblTutor(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTutorById")]
        [HttpPost]
        public IHttpActionResult SelectTutorById(int id)
        {
            var task = Task.Run(() => new TutorService().SelectTutorById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblTutor(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTutorByName")]
        [HttpPost]
        public IHttpActionResult SelectTutorByName(string name)
        {
            var task = Task.Run(() => new TutorService().SelectTutorByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblTutor(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTutorByIdentificationNo")]
        [HttpPost]
        public IHttpActionResult SelectTutorByIdentificationNo(string identificationNo)
        {
            var task = Task.Run(() => new TutorService().SelectTutorByIdentificationNo(identificationNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblTutor(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTutorByTellNo")]
        [HttpPost]
        public IHttpActionResult SelectTutorByTellNo(string tellNo)
        {
            var task = Task.Run(() => new TutorService().SelectTutorByTellNo(tellNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblTutor(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectTutorByUserPassId")]
        [HttpPost]
        public IHttpActionResult SelectTutorByUserPassId(int userPassId)
        {
            var task = Task.Run(() => new TutorService().SelectTutorByUserPassId(userPassId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblTutor(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
