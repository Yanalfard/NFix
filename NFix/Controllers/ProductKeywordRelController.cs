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
    [RoutePrefix("api/ProductKeywordRelCore")]
    public class ProductKeywordRelController : ApiController
    {
        [Route("AddProductKeywordRel")]
        [HttpPost]
        public IHttpActionResult AddProductKeywordRel(TblProductKeywordRel productKeywordRel)
        {
            var task = Task.Run(() => new ProductKeywordRelService().AddProductKeywordRel(productKeywordRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteProductKeywordRel")]
        [HttpPost]
        public IHttpActionResult DeleteProductKeywordRel(int id)
        {
            var task = Task.Run(() => new ProductKeywordRelService().DeleteProductKeywordRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateProductKeywordRel")]
        [HttpPost]
        public IHttpActionResult UpdateProductKeywordRel(List<object> productKeywordRelLogId)
        {
            TblProductKeywordRel productKeywordRel = JsonConvert.DeserializeObject<TblProductKeywordRel>(productKeywordRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(productKeywordRelLogId[1].ToString());
            var task = Task.Run(() => new ProductKeywordRelService().UpdateProductKeywordRel(productKeywordRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllProductKeywordRels")]
        [HttpGet]
        public IHttpActionResult SelectAllProductKeywordRels()
        {
            var task = Task.Run(() => new ProductKeywordRelService().SelectAllProductKeywordRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductKeywordRel> dto = new List<DtoTblProductKeywordRel>();
                    foreach (TblProductKeywordRel obj in task.Result)
                        dto.Add(new DtoTblProductKeywordRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductKeywordRelById")]
        [HttpPost]
        public IHttpActionResult SelectProductKeywordRelById(int id)
        {
            var task = Task.Run(() => new ProductKeywordRelService().SelectProductKeywordRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProductKeywordRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductKeywordRelByProductId")]
        [HttpPost]
        public IHttpActionResult SelectProductKeywordRelByProductId(int ductId)
        {
            var task = Task.Run(() => new ProductKeywordRelService().SelectProductKeywordRelByProductId(ductId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductKeywordRel> dto = new List<DtoTblProductKeywordRel>();
                    foreach (TblProductKeywordRel obj in task.Result)
                        dto.Add(new DtoTblProductKeywordRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductKeywordRelByKeywordId")]
        [HttpPost]
        public IHttpActionResult SelectProductKeywordRelByKeywordId(int wordId)
        {
            var task = Task.Run(() => new ProductKeywordRelService().SelectProductKeywordRelByKeywordId(wordId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductKeywordRel> dto = new List<DtoTblProductKeywordRel>();
                    foreach (TblProductKeywordRel obj in task.Result)
                        dto.Add(new DtoTblProductKeywordRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
