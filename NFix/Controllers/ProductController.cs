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
    [RoutePrefix("api/ProductCore")]
    public class ProductController : ApiController
    {
        [Route("AddProduct")]
        [HttpPost]
        public IHttpActionResult AddProduct(TblProduct product)
        {
            var task = Task.Run(() => new ProductService().AddProduct(product));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProduct(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteProduct")]
        [HttpPost]
        public IHttpActionResult DeleteProduct(int id)
        {
            var task = Task.Run(() => new ProductService().DeleteProduct(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateProduct")]
        [HttpPost]
        public IHttpActionResult UpdateProduct(List<object> productLogId)
        {
            TblProduct product = JsonConvert.DeserializeObject<TblProduct>(productLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(productLogId[1].ToString());
            var task = Task.Run(() => new ProductService().UpdateProduct(product, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllProducts")]
        [HttpGet]
        public IHttpActionResult SelectAllProducts()
        {
            var task = Task.Run(() => new ProductService().SelectAllProducts());
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
        [Route("SelectProductById")]
        [HttpPost]
        public IHttpActionResult SelectProductById(int id)
        {
            var task = Task.Run(() => new ProductService().SelectProductById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProduct(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductByName")]
        [HttpPost]
        public IHttpActionResult SelectProductByName(string name)
        {
            var task = Task.Run(() => new ProductService().SelectProductByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblProduct(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectProductByCatagoryId")]
        [HttpPost]
        public IHttpActionResult SelectProductByCatagoryId(int catagoryId)
        {
            var task = Task.Run(() => new ProductService().SelectProductByCatagoryId(catagoryId));
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
        [Route("SelectProductByIsSuggested")]
        [HttpPost]
        public IHttpActionResult SelectProductByIsSuggested(bool isSuggested)
        {
            var task = Task.Run(() => new ProductService().SelectProductByIsSuggested(isSuggested));
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
        [Route("SelectCommentByProductId")]
        [HttpPost]
        public IHttpActionResult SelectCommentByProductId(int productId)
        {
            var task = Task.Run(() => new ProductService().SelectCommentsByProductId(productId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblComment> dto = new List<DtoTblComment>();
                    foreach (TblComment obj in task.Result)
                        dto.Add(new DtoTblComment(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectImageByProductId")]
        [HttpPost]
        public IHttpActionResult SelectImageByProductId(int productId)
        {
            var task = Task.Run(() => new ProductService().SelectImagesByProductId(productId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblImage> dto = new List<DtoTblImage>();
                    foreach (TblImage obj in task.Result)
                        dto.Add(new DtoTblImage(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectKeywordByProductId")]
        [HttpPost]
        public IHttpActionResult SelectKeywordByProductId(int productId)
        {
            var task = Task.Run(() => new ProductService().SelectKeywordsByProductId(productId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblKeyword> dto = new List<DtoTblKeyword>();
                    foreach (TblKeyword obj in task.Result)
                        dto.Add(new DtoTblKeyword(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyByProductId")]
        [HttpPost]
        public IHttpActionResult SelectPropertyByProductId(int productId)
        {
            var task = Task.Run(() => new ProductService().SelectPropertysByProductId(productId));
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

    }
}
