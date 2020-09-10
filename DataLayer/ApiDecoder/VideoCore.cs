using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class VideoCore
    {
        private HttpClient _httpClient;

        public VideoCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/VideoCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a video to NFix.TblVideo
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public async Task<DtoTblVideo> AddVideo(TblVideo video)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/VideoCore/AddVideo", video);
            DtoTblVideo ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblVideo>();
            return ans;
        }
        /// <summary>
        /// Deletes a video from NFix.TblVideo using its id
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public async Task<bool> DeleteVideo(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/VideoCore/DeleteVideo?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a video at NFix.TblVideo
        /// </summary>
        /// <param name="video"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateVideo(TblVideo video, int logId)
        {
            List<object> videoAndLogId = new List<object>();
            videoAndLogId.Add(video);
            videoAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/VideoCore/UpdateVideo", videoAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all videos from NFix.TblVideo
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblVideo>> SelectAllVideos()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/VideoCore/SelectAllVideos");
            List<DtoTblVideo> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblVideo>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblVideo by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblVideo> SelectVideoById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/VideoCore/SelectVideoById?id={id}", id);
            DtoTblVideo ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblVideo>();
            return ans;
        }
        public async Task<DtoTblVideo> SelectVideoByTitle(string title)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/VideoCore/SelectVideoByTitle?title={title}", title);
            DtoTblVideo ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblVideo>();
            return ans;
        }
        public async Task<List<DtoTblVideo>> SelectVideoByIsOnline(bool isOnline)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/VideoCore/SelectVideoByIsOnline?isOnline={isOnline}", isOnline);
            List<DtoTblVideo> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblVideo>>();
            return ans;
        }
        public async Task<List<DtoTblVideo>> SelectVideoByIsHome(bool isHome)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/VideoCore/SelectVideoByIsHome?isHome={isHome}", isHome);
            List<DtoTblVideo> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblVideo>>();
            return ans;
        }

    }
}