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
    [RoutePrefix("api/KeywordCore")]
    public class KeywordController : ApiController
    {
        [Route("AddKeyword")]
        [HttpPost]
        public IHttpActionResult AddKeyword(TblKeyword keyword)
        {
            var task = Task.Run(() => new KeywordService().AddKeyword(keyword));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblKeyword(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteKeyword")]
        [HttpPost]
        public IHttpActionResult DeleteKeyword(int id)
        {
            var task = Task.Run(() => new KeywordService().DeleteKeyword(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateKeyword")]
        [HttpPost]
        public IHttpActionResult UpdateKeyword(List<object> keywordLogId)
        {
            TblKeyword keyword = JsonConvert.DeserializeObject<TblKeyword>(keywordLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(keywordLogId[1].ToString());
            var task = Task.Run(() => new KeywordService().UpdateKeyword(keyword, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllKeywords")]
        [HttpGet]
        public IHttpActionResult SelectAllKeywords()
        {
            var task = Task.Run(() => new KeywordService().SelectAllKeywords());
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
        [Route("SelectKeywordById")]
        [HttpPost]
        public IHttpActionResult SelectKeywordById(int id)
        {
            var task = Task.Run(() => new KeywordService().SelectKeywordById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblKeyword(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectKeywordByName")]
        [HttpPost]
        public IHttpActionResult SelectKeywordByName(string name)
        {
            var task = Task.Run(() => new KeywordService().SelectKeywordByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblKeyword(task.Result));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
