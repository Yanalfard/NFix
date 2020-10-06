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
    [RoutePrefix("api/DealCore")]
    public class DealController : ApiController
    {
        [Route("AddDeal")]
        [HttpPost]
        public IHttpActionResult AddDeal(TblDeal deal)
        {
            var task = Task.Run(() => new DealService().AddDeal(deal));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteDeal")]
        [HttpPost]
        public IHttpActionResult DeleteDeal(int id)
        {
            var task = Task.Run(() => new DealService().DeleteDeal(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateDeal")]
        [HttpPost]
        public IHttpActionResult UpdateDeal(List<object> dealLogId)
        {
            TblDeal deal = JsonConvert.DeserializeObject<TblDeal>(dealLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(dealLogId[1].ToString());
            var task = Task.Run(() => new DealService().UpdateDeal(deal, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllDeals")]
        [HttpGet]
        public IHttpActionResult SelectAllDeals()
        {
            var task = Task.Run(() => new DealService().SelectAllDeals());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDeal> dto = new List<DtoTblDeal>();
                    foreach (TblDeal obj in task.Result)
                        dto.Add(new DtoTblDeal(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDealById")]
        [HttpPost]
        public IHttpActionResult SelectDealById(int id)
        {
            var task = Task.Run(() => new DealService().SelectDealById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDeal(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDealByName")]
        [HttpPost]
        public IHttpActionResult SelectDealByName(string name)
        {
            var task = Task.Run(() => new DealService().SelectDealByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblDeal(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectDealByIsValid")]
        [HttpPost]
        public IHttpActionResult SelectDealByIsValid(bool isValid)
        {
            var task = Task.Run(() => new DealService().SelectDealByIsValid(isValid));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblDeal> dto = new List<DtoTblDeal>();
                    foreach (TblDeal obj in task.Result)
                        dto.Add(new DtoTblDeal(obj));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPropertyByDealId")]
        [HttpPost]
        public IHttpActionResult SelectPropertyByDealId(int dealId)
        {
            var task = Task.Run(() => new DealService().SelectPropertysByDealId(dealId));
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
