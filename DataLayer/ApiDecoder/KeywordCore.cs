using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class KeywordCore
    {
        private HttpClient _httpClient;

        public KeywordCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/KeywordCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a keyword to NFix.TblKeyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<DtoTblKeyword> AddKeyword(TblKeyword keyword)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/KeywordCore/AddKeyword", keyword);
            DtoTblKeyword ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblKeyword>();
            return ans;
        }
        /// <summary>
        /// Deletes a keyword from NFix.TblKeyword using its id
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<bool> DeleteKeyword(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/KeywordCore/DeleteKeyword?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a keyword at NFix.TblKeyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateKeyword(TblKeyword keyword, int logId)
        {
            List<object> keywordAndLogId = new List<object>();
            keywordAndLogId.Add(keyword);
            keywordAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/KeywordCore/UpdateKeyword", keywordAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all keywords from NFix.TblKeyword
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblKeyword>> SelectAllKeywords()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/KeywordCore/SelectAllKeywords");
            List<DtoTblKeyword> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblKeyword>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblKeyword by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblKeyword> SelectKeywordById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/KeywordCore/SelectKeywordById?id={id}", id);
            DtoTblKeyword ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblKeyword>();
            return ans;
        }
        public async Task<DtoTblKeyword> SelectKeywordByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/KeywordCore/SelectKeywordByName?name={name}", name);
            DtoTblKeyword ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblKeyword>();
            return ans;
        }

    }
}