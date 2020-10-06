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
    [RoutePrefix("api/ClientCore")]
    public class ClientController : ApiController
    {
        [Route("AddClient")]
        [HttpPost]
        public IHttpActionResult AddClient(TblClient client)
        {
            var task = Task.Run(() => new ClientService().AddClient(client));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteClient")]
        [HttpPost]
        public IHttpActionResult DeleteClient(int id)
        {
            var task = Task.Run(() => new ClientService().DeleteClient(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateClient")]
        [HttpPost]
        public IHttpActionResult UpdateClient(List<object> clientLogId)
        {
            TblClient client = JsonConvert.DeserializeObject<TblClient>(clientLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(clientLogId[1].ToString());
            var task = Task.Run(() => new ClientService().UpdateClient(client, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllClients")]
        [HttpGet]
        public IHttpActionResult SelectAllClients()
        {
            var task = Task.Run(() => new ClientService().SelectAllClients());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblClient> dto = new List<DtoTblClient>();
                    foreach (TblClient obj in task.Result)
                        dto.Add(new DtoTblClient(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientById")]
        [HttpPost]
        public IHttpActionResult SelectClientById(int id)
        {
            var task = Task.Run(() => new ClientService().SelectClientById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblClient(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientByName")]
        [HttpPost]
        public IHttpActionResult SelectClientByName(string name)
        {
            var task = Task.Run(() => new ClientService().SelectClientByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblClient(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientByIdentificationNo")]
        [HttpPost]
        public IHttpActionResult SelectClientByIdentificationNo(string identificationNo)
        {
            var task = Task.Run(() => new ClientService().SelectClientByIdentificationNo(identificationNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id!= -1)
                    return Ok(new DtoTblClient(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientByTellNo")]
        [HttpPost]
        public IHttpActionResult SelectClientByTellNo(string tellNo)
        {
            var task = Task.Run(() => new ClientService().SelectClientByTellNo(tellNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblClient(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientByEmail")]
        [HttpPost]
        public IHttpActionResult SelectClientByEmail(string email)
        {
            var task = Task.Run(() => new ClientService().SelectClientByEmail(email));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblClient(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientByUserPassId")]
        [HttpPost]
        public IHttpActionResult SelectClientByUserPassId(int userPassId)
        {
            var task = Task.Run(() => new ClientService().SelectClientByUserPassId(userPassId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                {
                    return Ok(new DtoTblClient(task.Result));
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectClientByIsPremium")]
        [HttpPost]
        public IHttpActionResult SelectClientByIsPremium(bool isPremium)
        {
            var task = Task.Run(() => new ClientService().SelectClientByIsPremium(isPremium));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblClient> dto = new List<DtoTblClient>();
                    foreach (TblClient obj in task.Result)
                        dto.Add(new DtoTblClient(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductByClientId")]
        [HttpPost]
        public IHttpActionResult SelectProductByClientId(int clientId)
        {
            var task = Task.Run(() => new ClientService().SelectProductsByClientId(clientId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProduct> dto = new List<DtoTblProduct>();
                    foreach (TblProduct obj in task.Result)
                        dto.Add(new DtoTblProduct(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
