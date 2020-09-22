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
    [RoutePrefix("api/ProductPropertyRelCore")]
    public class ProductPropertyRelController : ApiController
    {
        [Route("AddProductPropertyRel")]
        [HttpPost]
        public IHttpActionResult AddProductPropertyRel(TblProductPropertyRel productPropertyRel)
        {
            var task = Task.Run(() => new ProductPropertyRelService().AddProductPropertyRel(productPropertyRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProductPropertyRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [HttpPost]
        public IHttpActionResult DeleteProductPropertyRel(int id)
        {
            var task = Task.Run(() => new ProductPropertyRelService().DeleteProductPropertyRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [HttpPost]
        public IHttpActionResult UpdateProductPropertyRel(List<object> productPropertyRelLogId)
        {
            TblProductPropertyRel productPropertyRel = JsonConvert.DeserializeObject<TblProductPropertyRel>(productPropertyRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(productPropertyRelLogId[1].ToString());
            var task = Task.Run(() => new ProductPropertyRelService().UpdateProductPropertyRel(productPropertyRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [HttpGet]
        public IHttpActionResult SelectAllProductPropertyRels()
        {
            var task = Task.Run(() => new ProductPropertyRelService().SelectAllProductPropertyRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductPropertyRel> dto = new List<DtoTblProductPropertyRel>();
                    foreach (TblProductPropertyRel obj in task.Result)
                        dto.Add(new DtoTblProductPropertyRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [HttpPost]
        public IHttpActionResult SelectProductPropertyRelById(int id)
        {
            var task = Task.Run(() => new ProductPropertyRelService().SelectProductPropertyRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProductPropertyRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [HttpPost]
        public IHttpActionResult SelectProductPropertyRelByProductId(int ductId)
        {
            var task = Task.Run(() => new ProductPropertyRelService().SelectProductPropertyRelByProductId(ductId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductPropertyRel> dto = new List<DtoTblProductPropertyRel>();
                    foreach (TblProductPropertyRel obj in task.Result)
                        dto.Add(new DtoTblProductPropertyRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

        [HttpPost]
        public IHttpActionResult SelectProductPropertyRelByPropertyId(int pertyId)
        {
            var task = Task.Run(() => new ProductPropertyRelService().SelectProductPropertyRelByPropertyId(pertyId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductPropertyRel> dto = new List<DtoTblProductPropertyRel>();
                    foreach (TblProductPropertyRel obj in task.Result)
                        dto.Add(new DtoTblProductPropertyRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}