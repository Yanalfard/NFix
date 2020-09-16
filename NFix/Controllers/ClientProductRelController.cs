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
    [RoutePrefix("api/ClientProductRelCore")]
    public class ClientProductRelController : ApiController
    {
        [Route("AddClientProductRel")]
        [HttpPost]
        public IHttpActionResult AddClientProductRel(TblClientProductRel clientProductRel)
        {
            var task = Task.Run(() => new ClientProductRelService().AddClientProductRel(clientProductRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblClientProductRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteClientProductRel")]
        [HttpPost]
        public IHttpActionResult DeleteClientProductRel(int id)
        {
            var task = Task.Run(() => new ClientProductRelService().DeleteClientProductRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateClientProductRel")]
        [HttpPost]
        public IHttpActionResult UpdateClientProductRel(List<object> clientProductRelLogId)
        {
            TblClientProductRel clientProductRel = JsonConvert.DeserializeObject<TblClientProductRel>(clientProductRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(clientProductRelLogId[1].ToString());
            var task = Task.Run(() => new ClientProductRelService().UpdateClientProductRel(clientProductRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllClientProductRels")]
        [HttpGet]
        public IHttpActionResult SelectAllClientProductRels()
        {
            var task = Task.Run(() => new ClientProductRelService().SelectAllClientProductRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblClientProductRel> dto = new List<DtoTblClientProductRel>();
                    foreach (TblClientProductRel obj in task.Result)
                        dto.Add(new DtoTblClientProductRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientProductRelById")]
        [HttpPost]
        public IHttpActionResult SelectClientProductRelById(int id)
        {
            var task = Task.Run(() => new ClientProductRelService().SelectClientProductRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblClientProductRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientProductRelByClientId")]
        [HttpPost]
        public IHttpActionResult SelectClientProductRelByClientId(int entId)
        {
            var task = Task.Run(() => new ClientProductRelService().SelectClientProductRelByClientId(entId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblClientProductRel> dto = new List<DtoTblClientProductRel>();
                    foreach (TblClientProductRel obj in task.Result)
                        dto.Add(new DtoTblClientProductRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientProductRelByProductId")]
        [HttpPost]
        public IHttpActionResult SelectClientProductRelByProductId(int ductId)
        {
            var task = Task.Run(() => new ClientProductRelService().SelectClientProductRelByProductId(ductId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblClientProductRel> dto = new List<DtoTblClientProductRel>();
                    foreach (TblClientProductRel obj in task.Result)
                        dto.Add(new DtoTblClientProductRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientProductRelByDate")]
        [HttpPost]
        public IHttpActionResult SelectClientProductRelByDate(int e)
        {
            var task = Task.Run(() => new ClientProductRelService().SelectClientProductRelByDate(e));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblClientProductRel> dto = new List<DtoTblClientProductRel>();
                    foreach (TblClientProductRel obj in task.Result)
                        dto.Add(new DtoTblClientProductRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientProductRelByCount")]
        [HttpPost]
        public IHttpActionResult SelectClientProductRelByCount(int nt)
        {
            var task = Task.Run(() => new ClientProductRelService().SelectClientProductRelByCount(nt));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblClientProductRel> dto = new List<DtoTblClientProductRel>();
                    foreach (TblClientProductRel obj in task.Result)
                        dto.Add(new DtoTblClientProductRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
