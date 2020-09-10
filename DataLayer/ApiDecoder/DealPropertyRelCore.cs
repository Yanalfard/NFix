using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class DealPropertyRelCore
    {
        private HttpClient _httpClient;

        public DealPropertyRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/DealPropertyRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a dealPropertyRel to NFix.TblDealPropertyRel
        /// </summary>
        /// <param name="dealPropertyRel"></param>
        /// <returns></returns>
        public async Task<DtoTblDealPropertyRel> AddDealPropertyRel(TblDealPropertyRel dealPropertyRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DealPropertyRelCore/AddDealPropertyRel", dealPropertyRel);
            DtoTblDealPropertyRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDealPropertyRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a dealPropertyRel from NFix.TblDealPropertyRel using its id
        /// </summary>
        /// <param name="dealPropertyRel"></param>
        /// <returns></returns>
        public async Task<bool> DeleteDealPropertyRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealPropertyRelCore/DeleteDealPropertyRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a dealPropertyRel at NFix.TblDealPropertyRel
        /// </summary>
        /// <param name="dealPropertyRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateDealPropertyRel(TblDealPropertyRel dealPropertyRel, int logId)
        {
            List<object> dealPropertyRelAndLogId = new List<object>();
            dealPropertyRelAndLogId.Add(dealPropertyRel);
            dealPropertyRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DealPropertyRelCore/UpdateDealPropertyRel", dealPropertyRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all dealPropertyRels from NFix.TblDealPropertyRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblDealPropertyRel>> SelectAllDealPropertyRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/DealPropertyRelCore/SelectAllDealPropertyRels");
            List<DtoTblDealPropertyRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDealPropertyRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblDealPropertyRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblDealPropertyRel> SelectDealPropertyRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealPropertyRelCore/SelectDealPropertyRelById?id={id}", id);
            DtoTblDealPropertyRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDealPropertyRel>();
            return ans;
        }
        /// <summary>
        /// Select DealPropertyRels from NFix.TblDealPropertyRel by dealId
        /// </summary>
        /// <param name="dealId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblDealPropertyRel>> SelectDealPropertyRelByDealId(int dealId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealPropertyRelCore/SelectDealPropertyRelByDealId?dealId={dealId}", dealId);
            List<DtoTblDealPropertyRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDealPropertyRel>>();
            return ans;
        }
        /// <summary>
        /// Select DealPropertyRels from NFix.TblDealPropertyRel by propertyId
        /// </summary>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblDealPropertyRel>> SelectDealPropertyRelByPropertyId(int propertyId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealPropertyRelCore/SelectDealPropertyRelByPropertyId?propertyId={propertyId}", propertyId);
            List<DtoTblDealPropertyRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDealPropertyRel>>();
            return ans;
        }

    }
}