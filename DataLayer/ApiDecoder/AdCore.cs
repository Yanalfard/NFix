using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class AdCore
    {
        private HttpClient _httpClient;

        public AdCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/AdCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a ad to NFix.TblAd
        /// </summary>
        /// <param name="ad"></param>
        /// <returns></returns>
        public async Task<DtoTblAd> AddAd(TblAd ad)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/AdCore/AddAd", ad);
            DtoTblAd ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblAd>();
            return ans;
        }
        /// <summary>
        /// Deletes a ad from NFix.TblAd using its id
        /// </summary>
        /// <param name="ad"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAd(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/AdCore/DeleteAd?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a ad at NFix.TblAd
        /// </summary>
        /// <param name="ad"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateAd(TblAd ad, int logId)
        {
            List<object> adAndLogId = new List<object>();
            adAndLogId.Add(ad);
            adAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/AdCore/UpdateAd", adAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all ads from NFix.TblAd
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblAd>> SelectAllAds()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/AdCore/SelectAllAds");
            List<DtoTblAd> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblAd>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblAd by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblAd> SelectAdById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/AdCore/SelectAdById?id={id}", id);
            DtoTblAd ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblAd>();
            return ans;
        }
        public async Task<DtoTblAd> SelectAdByImage(string image)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/AdCore/SelectAdByImage?image={image}", image);
            DtoTblAd ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblAd>();
            return ans;
        }

    }
}