using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class BlogCommentRelCore
    {
        private HttpClient _httpClient;

        public BlogCommentRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/BlogCommentRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a blogCommentRel to NFix.TblBlogCommentRel
        /// </summary>
        /// <param name="blogCommentRel"></param>
        /// <returns></returns>
        public async Task<DtoTblBlogCommentRel> AddBlogCommentRel(TblBlogCommentRel blogCommentRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/BlogCommentRelCore/AddBlogCommentRel", blogCommentRel);
            DtoTblBlogCommentRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblBlogCommentRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a blogCommentRel from NFix.TblBlogCommentRel using its id
        /// </summary>
        /// <param name="blogCommentRel"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBlogCommentRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogCommentRelCore/DeleteBlogCommentRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a blogCommentRel at NFix.TblBlogCommentRel
        /// </summary>
        /// <param name="blogCommentRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateBlogCommentRel(TblBlogCommentRel blogCommentRel, int logId)
        {
            List<object> blogCommentRelAndLogId = new List<object>();
            blogCommentRelAndLogId.Add(blogCommentRel);
            blogCommentRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/BlogCommentRelCore/UpdateBlogCommentRel", blogCommentRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all blogCommentRels from NFix.TblBlogCommentRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblBlogCommentRel>> SelectAllBlogCommentRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/BlogCommentRelCore/SelectAllBlogCommentRels");
            List<DtoTblBlogCommentRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblBlogCommentRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblBlogCommentRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblBlogCommentRel> SelectBlogCommentRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogCommentRelCore/SelectBlogCommentRelById?id={id}", id);
            DtoTblBlogCommentRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblBlogCommentRel>();
            return ans;
        }
        /// <summary>
        /// Select BlogCommentRels from NFix.TblBlogCommentRel by blogId
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblBlogCommentRel>> SelectBlogCommentRelByBlogId(int blogId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogCommentRelCore/SelectBlogCommentRelByBlogId?blogId={blogId}", blogId);
            List<DtoTblBlogCommentRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblBlogCommentRel>>();
            return ans;
        }
        /// <summary>
        /// Select BlogCommentRels from NFix.TblBlogCommentRel by commentId
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblBlogCommentRel>> SelectBlogCommentRelByCommentId(int commentId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogCommentRelCore/SelectBlogCommentRelByCommentId?commentId={commentId}", commentId);
            List<DtoTblBlogCommentRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblBlogCommentRel>>();
            return ans;
        }

    }
}