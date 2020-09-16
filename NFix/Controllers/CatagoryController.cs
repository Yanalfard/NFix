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
    [RoutePrefix("api/CatagoryCore")]
    public class CatagoryController : ApiController
    {
        [Route("AddCatagory")]
        [HttpPost]
        public IHttpActionResult AddCatagory(TblCatagory catagory)
        {
            var task = Task.Run(() => new CatagoryService().AddCatagory(catagory));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblCatagory(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteCatagory")]
        [HttpPost]
        public IHttpActionResult DeleteCatagory(int id)
        {
            var task = Task.Run(() => new CatagoryService().DeleteCatagory(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateCatagory")]
        [HttpPost]
        public IHttpActionResult UpdateCatagory(List<object> catagoryLogId)
        {
            TblCatagory catagory = JsonConvert.DeserializeObject<TblCatagory>(catagoryLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(catagoryLogId[1].ToString());
            var task = Task.Run(() => new CatagoryService().UpdateCatagory(catagory, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllCatagorys")]
        [HttpGet]
        public IHttpActionResult SelectAllCatagorys()
        {
            var task = Task.Run(() => new CatagoryService().SelectAllCatagorys());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblCatagory> dto = new List<DtoTblCatagory>();
                    foreach (TblCatagory obj in task.Result)
                        dto.Add(new DtoTblCatagory(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectCatagoryById")]
        [HttpPost]
        public IHttpActionResult SelectCatagoryById(int id)
        {
            var task = Task.Run(() => new CatagoryService().SelectCatagoryById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblCatagory(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectCatagoryByName")]
        [HttpPost]
        public IHttpActionResult SelectCatagoryByName(string name)
        {
            var task = Task.Run(() => new CatagoryService().SelectCatagoryByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblCatagory(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectCatagoryByCatagoryId")]
        [HttpPost]
        public IHttpActionResult SelectCatagoryByCatagoryId(int catagoryId)
        {
            var task = Task.Run(() => new CatagoryService().SelectCatagoryByCatagoryId(catagoryId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblCatagory> dto = new List<DtoTblCatagory>();
                    foreach (TblCatagory obj in task.Result)
                        dto.Add(new DtoTblCatagory(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
