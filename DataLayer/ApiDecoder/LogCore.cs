using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class LogCore
    {
        private HttpClient _httpClient;

        public LogCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/LogCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a log to NFix.TblLog
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public async Task<DtoTblLog> AddLog(TblLog log)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/LogCore/AddLog", log);
            DtoTblLog ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblLog>();
            return ans;
        }
        /// <summary>
        /// Deletes a log from NFix.TblLog using its id
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public async Task<bool> DeleteLog(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/LogCore/DeleteLog?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a log at NFix.TblLog
        /// </summary>
        /// <param name="log"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateLog(TblLog log, int logId)
        {
            List<object> logAndLogId = new List<object>();
            logAndLogId.Add(log);
            logAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/LogCore/UpdateLog", logAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all logs from NFix.TblLog
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblLog>> SelectAllLogs()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/LogCore/SelectAllLogs");
            List<DtoTblLog> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblLog>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblLog by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblLog> SelectLogById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/LogCore/SelectLogById?id={id}", id);
            DtoTblLog ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblLog>();
            return ans;
        }

    }
}