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
    [RoutePrefix("api/DealPropertyRelCore")]
    public class DealPropertyRelController : ApiController
    {
        [Route("AddDealPropertyRel")]
        [HttpPost]
        public IHttpActionResult AddDealPropertyRel(TblDealPropertyRel dealPropertyRel)
        {
            var task = Task.Run(() => new DealPropertyRelService().AddDealPropertyRel(dealPropertyRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("DeleteDealPropertyRel")]
        [HttpPost]
        public IHttpActionResult DeleteDealPropertyRel(int id)
        {
            var task = Task.Run(() => new DealPropertyRelService().DeleteDealPropertyRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("UpdateDealPropertyRel")]
        [HttpPost]
        public IHttpActionResult UpdateDealPropertyRel(List<object> dealPropertyRelLogId)
        {
            TblDealPropertyRel dealPropertyRel = JsonConvert.DeserializeObject<TblDealPropertyRel>(dealPropertyRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(dealPropertyRelLogId[1].ToString());
            var task = Task.Run(() => new DealPropertyRelService().UpdateDealPropertyRel(dealPropertyRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("SelectAllDealPropertyRels")]
        [HttpGet]
        public IHttpActionResult SelectAllDealPropertyRels()
        {
            var task = Task.Run(() => new DealPropertyRelService().SelectAllDealPropertyRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDealPropertyRel> dto = new List<DtoTblDealPropertyRel>();
                    foreach (TblDealPropertyRel obj in task.Result)
                        dto.Add(new DtoTblDealPropertyRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("SelectDealPropertyRelById")]
        [HttpPost]
        public IHttpActionResult SelectDealPropertyRelById(int id)
        {
            var task = Task.Run(() => new DealPropertyRelService().SelectDealPropertyRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDealPropertyRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("SelectDealPropertyRelByDealId")]
        [HttpPost]
        public IHttpActionResult SelectDealPropertyRelByDealId(int lId)
        {
            var task = Task.Run(() => new DealPropertyRelService().SelectDealPropertyRelByDealId(lId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDealPropertyRel> dto = new List<DtoTblDealPropertyRel>();
                    foreach (TblDealPropertyRel obj in task.Result)
                        dto.Add(new DtoTblDealPropertyRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [Route("SelectDealPropertyRelByPropertyId")]
        [HttpPost]
        public IHttpActionResult SelectDealPropertyRelByPropertyId(int pertyId)
        {
            var task = Task.Run(() => new DealPropertyRelService().SelectDealPropertyRelByPropertyId(pertyId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDealPropertyRel> dto = new List<DtoTblDealPropertyRel>();
                    foreach (TblDealPropertyRel obj in task.Result)
                        dto.Add(new DtoTblDealPropertyRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }


    }
}
