using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class VideoCommentRelCore
    {
        private HttpClient _httpClient;

        public VideoCommentRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/VideoCommentRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a VideoCommentRel to NFix.TblVideoCommentRel
        /// </summary>
        /// <param name="VideoCommentRel"></param>
        /// <returns></returns>
        public async Task<DtoTblVideoCommentRel> AddVideoCommentRel(TblVideoCommentRel VideoCommentRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/VideoCommentRelCore/AddVideoCommentRel", VideoCommentRel);
            DtoTblVideoCommentRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblVideoCommentRel>();
            return ans;
        }

        /// <summary>
        /// Deletes a VideoCommentRel from NFix.TblVideoCommentRel using its id
        /// </summary>
        /// <param name="VideoCommentRel"></param>
        /// <returns></returns>
        public async Task<bool> DeleteVideoCommentRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/VideoCommentRelCore/DeleteVideoCommentRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }

        /// <summary>
        /// Updates a VideoCommentRel at NFix.TblVideoCommentRel
        /// </summary>
        /// <param name="VideoCommentRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateVideoCommentRel(TblVideoCommentRel VideoCommentRel, int logId)
        {
            List<object> VideoCommentRelAndLogId = new List<object>();
            VideoCommentRelAndLogId.Add(VideoCommentRel);
            VideoCommentRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/VideoCommentRelCore/UpdateVideoCommentRel", VideoCommentRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }

        /// <summary>
        /// Selects all VideoCommentRels from NFix.TblVideoCommentRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblVideoCommentRel>> SelectAllVideoCommentRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/VideoCommentRelCore/SelectAllVideoCommentRels");
            List<DtoTblVideoCommentRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblVideoCommentRel>>();
            return ans;
        }

        /// <summary>
        /// Selects a doctor from NFix.TblVideoCommentRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblVideoCommentRel> SelectVideoCommentRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/VideoCommentRelCore/SelectVideoCommentRelById?id={id}", id);
            DtoTblVideoCommentRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblVideoCommentRel>();
            return ans;
        }

        /// <summary>
        /// Select VideoCommentRels from NFix.TblVideoCommentRel by blogId
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblVideoCommentRel>> SelectVideoCommentRelByBlogId(int blogId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/VideoCommentRelCore/SelectVideoCommentRelByBlogId?blogId={blogId}", blogId);
            List<DtoTblVideoCommentRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblVideoCommentRel>>();
            return ans;
        }

        /// <summary>
        /// Select VideoCommentRels from NFix.TblVideoCommentRel by commentId
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblVideoCommentRel>> SelectVideoCommentRelByCommentId(int commentId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/VideoCommentRelCore/SelectVideoCommentRelByCommentId?commentId={commentId}", commentId);
            List<DtoTblVideoCommentRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblVideoCommentRel>>();
            return ans;
        }


    }
}