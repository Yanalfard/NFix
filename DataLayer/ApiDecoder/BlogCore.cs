using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class BlogCore
    {
        private HttpClient _httpClient;

        public BlogCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/BlogCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a blog to NFix.TblBlog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public async Task<DtoTblBlog> AddBlog(TblBlog blog)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/BlogCore/AddBlog", blog);
            DtoTblBlog ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblBlog>();
            return ans;
        }
        /// <summary>
        /// Deletes a blog from NFix.TblBlog using its id
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBlog(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogCore/DeleteBlog?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a blog at NFix.TblBlog
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateBlog(TblBlog blog, int logId)
        {
            List<object> blogAndLogId = new List<object>();
            blogAndLogId.Add(blog);
            blogAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/BlogCore/UpdateBlog", blogAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all blogs from NFix.TblBlog
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblBlog>> SelectAllBlogs()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/BlogCore/SelectAllBlogs");
            List<DtoTblBlog> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblBlog>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblBlog by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblBlog> SelectBlogById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogCore/SelectBlogById?id={id}", id);
            DtoTblBlog ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblBlog>();
            return ans;
        }
        public async Task<List<DtoTblComment>> SelectCommentByBlogId(int blogId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogCore/SelectCommentByBlogId?blogId={blogId}", blogId);
            List<DtoTblComment> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblComment>>();
            return ans;
        }
        public async Task<List<DtoTblKeyword>> SelectKeywordByBlogId(int blogId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/BlogCore/SelectKeywordByBlogId?blogId={blogId}", blogId);
            List<DtoTblKeyword> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblKeyword>>();
            return ans;
        }

    }
}