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
    [RoutePrefix("api/DiscountCore")]
    public class DiscountController : ApiController
    {
        [Route("AddDiscount")]
        [HttpPost]
        public IHttpActionResult AddDiscount(TblDiscount discount)
        {
            var task = Task.Run(() => new DiscountService().AddDiscount(discount));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteDiscount")]
        [HttpPost]
        public IHttpActionResult DeleteDiscount(int id)
        {
            var task = Task.Run(() => new DiscountService().DeleteDiscount(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateDiscount")]
        [HttpPost]
        public IHttpActionResult UpdateDiscount(List<object> discountLogId)
        {
            TblDiscount discount = JsonConvert.DeserializeObject<TblDiscount>(discountLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(discountLogId[1].ToString());
            var task = Task.Run(() => new DiscountService().UpdateDiscount(discount, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllDiscounts")]
        [HttpGet]
        public IHttpActionResult SelectAllDiscounts()
        {
            var task = Task.Run(() => new DiscountService().SelectAllDiscounts());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDiscount> dto = new List<DtoTblDiscount>();
                    foreach (TblDiscount obj in task.Result)
                        dto.Add(new DtoTblDiscount(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDiscountById")]
        [HttpPost]
        public IHttpActionResult SelectDiscountById(int id)
        {
            var task = Task.Run(() => new DiscountService().SelectDiscountById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDiscount(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDiscountByName")]
        [HttpPost]
        public IHttpActionResult SelectDiscountByName(string name)
        {
            var task = Task.Run(() => new DiscountService().SelectDiscountByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDiscount(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
