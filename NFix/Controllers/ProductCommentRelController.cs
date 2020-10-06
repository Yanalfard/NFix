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
    [RoutePrefix("api/ProductCommentRelCore")]
    public class ProductCommentRelController : ApiController
    {
        [Route("AddProductCommentRel")]
        [HttpPost]
        public IHttpActionResult AddProductCommentRel(TblProductCommentRel productCommentRel)
        {
            var task = Task.Run(() => new ProductCommentRelService().AddProductCommentRel(productCommentRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteProductCommentRel")]
        [HttpPost]
        public IHttpActionResult DeleteProductCommentRel(int id)
        {
            var task = Task.Run(() => new ProductCommentRelService().DeleteProductCommentRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateProductCommentRel")]
        [HttpPost]
        public IHttpActionResult UpdateProductCommentRel(List<object> productCommentRelLogId)
        {
            TblProductCommentRel productCommentRel = JsonConvert.DeserializeObject<TblProductCommentRel>(productCommentRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(productCommentRelLogId[1].ToString());
            var task = Task.Run(() => new ProductCommentRelService().UpdateProductCommentRel(productCommentRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllProductCommentRels")]
        [HttpGet]
        public IHttpActionResult SelectAllProductCommentRels()
        {
            var task = Task.Run(() => new ProductCommentRelService().SelectAllProductCommentRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductCommentRel> dto = new List<DtoTblProductCommentRel>();
                    foreach (TblProductCommentRel obj in task.Result)
                        dto.Add(new DtoTblProductCommentRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductCommentRelById")]
        [HttpPost]
        public IHttpActionResult SelectProductCommentRelById(int id)
        {
            var task = Task.Run(() => new ProductCommentRelService().SelectProductCommentRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProductCommentRel(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductCommentRelByProductId")]
        [HttpPost]
        public IHttpActionResult SelectProductCommentRelByProductId(int ductId)
        {
            var task = Task.Run(() => new ProductCommentRelService().SelectProductCommentRelByProductId(ductId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductCommentRel> dto = new List<DtoTblProductCommentRel>();
                    foreach (TblProductCommentRel obj in task.Result)
                        dto.Add(new DtoTblProductCommentRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductCommentRelByCommentId")]
        [HttpPost]
        public IHttpActionResult SelectProductCommentRelByCommentId(int mentId)
        {
            var task = Task.Run(() => new ProductCommentRelService().SelectProductCommentRelByCommentId(mentId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblProductCommentRel> dto = new List<DtoTblProductCommentRel>();
                    foreach (TblProductCommentRel obj in task.Result)
                        dto.Add(new DtoTblProductCommentRel(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
