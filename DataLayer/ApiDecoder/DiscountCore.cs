using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class DiscountCore
    {
        private HttpClient _httpClient;

        public DiscountCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/DiscountCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a discount to NFix.TblDiscount
        /// </summary>
        /// <param name="discount"></param>
        /// <returns></returns>
        public async Task<DtoTblDiscount> AddDiscount(TblDiscount discount)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DiscountCore/AddDiscount", discount);
            DtoTblDiscount ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDiscount>();
            return ans;
        }
        /// <summary>
        /// Deletes a discount from NFix.TblDiscount using its id
        /// </summary>
        /// <param name="discount"></param>
        /// <returns></returns>
        public async Task<bool> DeleteDiscount(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DiscountCore/DeleteDiscount?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a discount at NFix.TblDiscount
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateDiscount(TblDiscount discount, int logId)
        {
            List<object> discountAndLogId = new List<object>();
            discountAndLogId.Add(discount);
            discountAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/DiscountCore/UpdateDiscount", discountAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all discounts from NFix.TblDiscount
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblDiscount>> SelectAllDiscounts()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/DiscountCore/SelectAllDiscounts");
            List<DtoTblDiscount> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblDiscount>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblDiscount by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblDiscount> SelectDiscountById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DiscountCore/SelectDiscountById?id={id}", id);
            DtoTblDiscount ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDiscount>();
            return ans;
        }
        public async Task<DtoTblDiscount> SelectDiscountByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/DiscountCore/SelectDiscountByName?name={name}", name);
            DtoTblDiscount ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblDiscount>();
            return ans;
        }

    }
}