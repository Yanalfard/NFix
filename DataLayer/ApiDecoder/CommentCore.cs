using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class CommentCore
    {
        private HttpClient _httpClient;

        public CommentCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/CommentCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a comment to NFix.TblComment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task<DtoTblComment> AddComment(TblComment comment)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/CommentCore/AddComment", comment);
            DtoTblComment ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblComment>();
            return ans;
        }
        /// <summary>
        /// Deletes a comment from NFix.TblComment using its id
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task<bool> DeleteComment(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CommentCore/DeleteComment?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a comment at NFix.TblComment
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateComment(TblComment comment, int logId)
        {
            List<object> commentAndLogId = new List<object>();
            commentAndLogId.Add(comment);
            commentAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/CommentCore/UpdateComment", commentAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all comments from NFix.TblComment
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblComment>> SelectAllComments()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/CommentCore/SelectAllComments");
            List<DtoTblComment> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblComment>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblComment by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblComment> SelectCommentById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CommentCore/SelectCommentById?id={id}", id);
            DtoTblComment ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblComment>();
            return ans;
        }
        public async Task<List<DtoTblComment>> SelectCommentByClientId(int clientId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CommentCore/SelectCommentByClientId?clientId={clientId}", clientId);
            List<DtoTblComment> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblComment>>();
            return ans;
        }
        public async Task<List<DtoTblComment>> SelectCommentByIsValid(bool isValid)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CommentCore/SelectCommentByIsValid?isValid={isValid}", isValid);
            List<DtoTblComment> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblComment>>();
            return ans;
        }

    }
}