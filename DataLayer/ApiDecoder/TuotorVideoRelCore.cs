using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class TuotorVideoRelCore
    {
        private HttpClient _httpClient;

        public TuotorVideoRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/TuotorVideoRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a tuotorVideoRel to NFix.TblTuotorVideoRel
        /// </summary>
        /// <param name="tuotorVideoRel"></param>
        /// <returns></returns>
        public async Task<DtoTblTuotorVideoRel> AddTuotorVideoRel(TblTuotorVideoRel tuotorVideoRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/TuotorVideoRelCore/AddTuotorVideoRel", tuotorVideoRel);
            DtoTblTuotorVideoRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblTuotorVideoRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a tuotorVideoRel from NFix.TblTuotorVideoRel using its id
        /// </summary>
        /// <param name="tuotorVideoRel"></param>
        /// <returns></returns>
        public async Task<bool> DeleteTuotorVideoRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/TuotorVideoRelCore/DeleteTuotorVideoRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a tuotorVideoRel at NFix.TblTuotorVideoRel
        /// </summary>
        /// <param name="tuotorVideoRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateTuotorVideoRel(TblTuotorVideoRel tuotorVideoRel, int logId)
        {
            List<object> tuotorVideoRelAndLogId = new List<object>();
            tuotorVideoRelAndLogId.Add(tuotorVideoRel);
            tuotorVideoRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/TuotorVideoRelCore/UpdateTuotorVideoRel", tuotorVideoRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all tuotorVideoRels from NFix.TblTuotorVideoRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblTuotorVideoRel>> SelectAllTuotorVideoRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/TuotorVideoRelCore/SelectAllTuotorVideoRels");
            List<DtoTblTuotorVideoRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblTuotorVideoRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblTuotorVideoRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblTuotorVideoRel> SelectTuotorVideoRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/TuotorVideoRelCore/SelectTuotorVideoRelById?id={id}", id);
            DtoTblTuotorVideoRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblTuotorVideoRel>();
            return ans;
        }
        /// <summary>
        /// Select TuotorVideoRels from NFix.TblTuotorVideoRel by toutorId
        /// </summary>
        /// <param name="toutorId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblTuotorVideoRel>> SelectTuotorVideoRelByToutorId(int toutorId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/TuotorVideoRelCore/SelectTuotorVideoRelByToutorId?toutorId={toutorId}", toutorId);
            List<DtoTblTuotorVideoRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblTuotorVideoRel>>();
            return ans;
        }
        /// <summary>
        /// Select TuotorVideoRels from NFix.TblTuotorVideoRel by videoId
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblTuotorVideoRel>> SelectTuotorVideoRelByVideoId(int videoId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/TuotorVideoRelCore/SelectTuotorVideoRelByVideoId?videoId={videoId}", videoId);
            List<DtoTblTuotorVideoRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblTuotorVideoRel>>();
            return ans;
        }

    }
}