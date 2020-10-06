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
    [RoutePrefix("api/ProductImageRelCore")]
    public class ProductImageRelController : ApiController
    {
        [Route("AddProductImageRel")]
        [HttpPost]
        public IHttpActionResult AddProductImageRel(TblProductImageRel productImageRel)
        {
            var task = Task.Run(() => new ProductImageRelService().AddProductImageRel(productImageRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteProductImageRel")]
        [HttpPost]
        public IHttpActionResult DeleteProductImageRel(int id)
        {
            var task = Task.Run(() => new ProductImageRelService().DeleteProductImageRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateProductImageRel")]
        [HttpPost]
        public IHttpActionResult UpdateProductImageRel(List<object> productImageRelLogId)
        {
            TblProductImageRel productImageRel = JsonConvert.DeserializeObject<TblProductImageRel>(productImageRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(productImageRelLogId[1].ToString());
            var task = Task.Run(() => new ProductImageRelService().UpdateProductImageRel(productImageRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllProductImageRels")]
        [HttpGet]
        public IHttpActionResult SelectAllProductImageRels()
        {
            var task = Task.Run(() => new ProductImageRelService().SelectAllProductImageRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductImageRel> dto = new List<DtoTblProductImageRel>();
                    foreach (TblProductImageRel obj in task.Result)
                        dto.Add(new DtoTblProductImageRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductImageRelById")]
        [HttpPost]
        public IHttpActionResult SelectProductImageRelById(int id)
        {
            var task = Task.Run(() => new ProductImageRelService().SelectProductImageRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProductImageRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductImageRelByProductId")]
        [HttpPost]
        public IHttpActionResult SelectProductImageRelByProductId(int ductId)
        {
            var task = Task.Run(() => new ProductImageRelService().SelectProductImageRelByProductId(ductId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductImageRel> dto = new List<DtoTblProductImageRel>();
                    foreach (TblProductImageRel obj in task.Result)
                        dto.Add(new DtoTblProductImageRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductImageRelByImageId")]
        [HttpPost]
        public IHttpActionResult SelectProductImageRelByImageId(int geId)
        {
            var task = Task.Run(() => new ProductImageRelService().SelectProductImageRelByImageId(geId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductImageRel> dto = new List<DtoTblProductImageRel>();
                    foreach (TblProductImageRel obj in task.Result)
                        dto.Add(new DtoTblProductImageRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
