using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class BlogKeywordRelCore
    {
        private HttpClient _httpClient;

        public BlogKeywordRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/BlogKeywordRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a blogKeywordRel to NFix.TblBlogKeywordRel
        /// </summary>
        /// <param name="blogKeywordRel"></param>
        /// <returns></returns>
        public async Task<DtoTblBlogKeywordRel> AddBlogKeywordRel(TblBlogKeywordRel blogKeywordRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/BlogKeywordRelCore/AddBlogKeywordRel", blogKeywordRel);
            DtoTblBlogKeywordRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblBlogKeywordRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a blogKeywordRel from NFix.TblBlogKeywordRel using its id
        /// </summary>
        /// <param name="blogKeywordRel"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBlogKeywordRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogKeywordRelCore/DeleteBlogKeywordRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a blogKeywordRel at NFix.TblBlogKeywordRel
        /// </summary>
        /// <param name="blogKeywordRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateBlogKeywordRel(TblBlogKeywordRel blogKeywordRel, int logId)
        {
            List<object> blogKeywordRelAndLogId = new List<object>();
            blogKeywordRelAndLogId.Add(blogKeywordRel);
            blogKeywordRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/BlogKeywordRelCore/UpdateBlogKeywordRel", blogKeywordRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all blogKeywordRels from NFix.TblBlogKeywordRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblBlogKeywordRel>> SelectAllBlogKeywordRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/BlogKeywordRelCore/SelectAllBlogKeywordRels");
            List<DtoTblBlogKeywordRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblBlogKeywordRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblBlogKeywordRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblBlogKeywordRel> SelectBlogKeywordRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogKeywordRelCore/SelectBlogKeywordRelById?id={id}", id);
            DtoTblBlogKeywordRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblBlogKeywordRel>();
            return ans;
        }
        /// <summary>
        /// Select BlogKeywordRels from NFix.TblBlogKeywordRel by blogId
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblBlogKeywordRel>> SelectBlogKeywordRelByBlogId(int blogId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogKeywordRelCore/SelectBlogKeywordRelByBlogId?blogId={blogId}", blogId);
            List<DtoTblBlogKeywordRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblBlogKeywordRel>>();
            return ans;
        }
        /// <summary>
        /// Select BlogKeywordRels from NFix.TblBlogKeywordRel by keywordId
        /// </summary>
        /// <param name="keywordId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblBlogKeywordRel>> SelectBlogKeywordRelByKeywordId(int keywordId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogKeywordRelCore/SelectBlogKeywordRelByKeywordId?keywordId={keywordId}", keywordId);
            List<DtoTblBlogKeywordRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblBlogKeywordRel>>();
            return ans;
        }

    }
}