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
    [RoutePrefix("api/PropertyCore")]
    public class PropertyController : ApiController
    {
        [Route("AddProperty")]
        [HttpPost]
        public IHttpActionResult AddProperty(TblProperty property)
        {
            var task = Task.Run(() => new PropertyService().AddProperty(property));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProperty(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteProperty")]
        [HttpPost]
        public IHttpActionResult DeleteProperty(int id)
        {
            var task = Task.Run(() => new PropertyService().DeleteProperty(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateProperty")]
        [HttpPost]
        public IHttpActionResult UpdateProperty(List<object> propertyLogId)
        {
            TblProperty property = JsonConvert.DeserializeObject<TblProperty>(propertyLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(propertyLogId[1].ToString());
            var task = Task.Run(() => new PropertyService().UpdateProperty(property, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllPropertys")]
        [HttpGet]
        public IHttpActionResult SelectAllPropertys()
        {
            var task = Task.Run(() => new PropertyService().SelectAllPropertys());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProperty> dto = new List<DtoTblProperty>();
                    foreach (TblProperty obj in task.Result)
                        dto.Add(new DtoTblProperty(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyById")]
        [HttpPost]
        public IHttpActionResult SelectPropertyById(int id)
        {
            var task = Task.Run(() => new PropertyService().SelectPropertyById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProperty(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyByName")]
        [HttpPost]
        public IHttpActionResult SelectPropertyByName(string name)
        {
            var task = Task.Run(() => new PropertyService().SelectPropertyByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProperty(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
