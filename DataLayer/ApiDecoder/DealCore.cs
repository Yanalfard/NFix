using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class DealCore
    {
        private HttpClient _httpClient;

        public DealCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/DealCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a deal to NFix.TblDeal
        /// </summary>
        /// <param name="deal"></param>
        /// <returns></returns>
        public async Task<DtoTblDeal> AddDeal(TblDeal deal)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DealCore/AddDeal", deal);
            DtoTblDeal ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDeal>();
            return ans;
        }
        /// <summary>
        /// Deletes a deal from NFix.TblDeal using its id
        /// </summary>
        /// <param name="deal"></param>
        /// <returns></returns>
        public async Task<bool> DeleteDeal(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealCore/DeleteDeal?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a deal at NFix.TblDeal
        /// </summary>
        /// <param name="deal"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateDeal(TblDeal deal, int logId)
        {
            List<object> dealAndLogId = new List<object>();
            dealAndLogId.Add(deal);
            dealAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DealCore/UpdateDeal", dealAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all deals from NFix.TblDeal
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblDeal>> SelectAllDeals()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/DealCore/SelectAllDeals");
            List<DtoTblDeal> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDeal>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblDeal by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblDeal> SelectDealById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealCore/SelectDealById?id={id}", id);
            DtoTblDeal ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDeal>();
            return ans;
        }
        public async Task<DtoTblDeal> SelectDealByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealCore/SelectDealByName?name={name}", name);
            DtoTblDeal ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDeal>();
            return ans;
        }
        public async Task<List<DtoTblDeal>> SelectDealByIsValid(bool isValid)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealCore/SelectDealByIsValid?isValid={isValid}", isValid);
            List<DtoTblDeal> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDeal>>();
            return ans;
        }
        public async Task<List<DtoTblProperty>> SelectPropertyByDealId(int dealId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DealCore/SelectPropertyByDealId?dealId={dealId}", dealId);
            List<DtoTblProperty> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProperty>>();
            return ans;
        }

    }
}