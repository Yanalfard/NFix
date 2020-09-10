using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class ClientProductRelCore
    {
        private HttpClient _httpClient;

        public ClientProductRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ClientProductRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a clientProductRel to NFix.TblClientProductRel
        /// </summary>
        /// <param name="clientProductRel"></param>
        /// <returns></returns>
        public async Task<DtoTblClientProductRel> AddClientProductRel(TblClientProductRel clientProductRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ClientProductRelCore/AddClientProductRel", clientProductRel);
            DtoTblClientProductRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblClientProductRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a clientProductRel from NFix.TblClientProductRel using its id
        /// </summary>
        /// <param name="clientProductRel"></param>
        /// <returns></returns>
        public async Task<bool> DeleteClientProductRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientProductRelCore/DeleteClientProductRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a clientProductRel at NFix.TblClientProductRel
        /// </summary>
        /// <param name="clientProductRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateClientProductRel(TblClientProductRel clientProductRel, int logId)
        {
            List<object> clientProductRelAndLogId = new List<object>();
            clientProductRelAndLogId.Add(clientProductRel);
            clientProductRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ClientProductRelCore/UpdateClientProductRel", clientProductRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all clientProductRels from NFix.TblClientProductRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblClientProductRel>> SelectAllClientProductRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ClientProductRelCore/SelectAllClientProductRels");
            List<DtoTblClientProductRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClientProductRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblClientProductRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblClientProductRel> SelectClientProductRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientProductRelCore/SelectClientProductRelById?id={id}", id);
            DtoTblClientProductRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblClientProductRel>();
            return ans;
        }
        /// <summary>
        /// Select ClientProductRels from NFix.TblClientProductRel by clientId
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblClientProductRel>> SelectClientProductRelByClientId(int clientId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientProductRelCore/SelectClientProductRelByClientId?clientId={clientId}", clientId);
            List<DtoTblClientProductRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClientProductRel>>();
            return ans;
        }
        /// <summary>
        /// Select ClientProductRels from NFix.TblClientProductRel by productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblClientProductRel>> SelectClientProductRelByProductId(int productId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientProductRelCore/SelectClientProductRelByProductId?productId={productId}", productId);
            List<DtoTblClientProductRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClientProductRel>>();
            return ans;
        }
        /// <summary>
        /// Select ClientProductRels from NFix.TblClientProductRel by date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<List<DtoTblClientProductRel>> SelectClientProductRelByDate(int date)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientProductRelCore/SelectClientProductRelByDate?date={date}", date);
            List<DtoTblClientProductRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClientProductRel>>();
            return ans;
        }
        /// <summary>
        /// Select ClientProductRels from NFix.TblClientProductRel by count
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<DtoTblClientProductRel>> SelectClientProductRelByCount(int count)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientProductRelCore/SelectClientProductRelByCount?count={count}", count);
            List<DtoTblClientProductRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClientProductRel>>();
            return ans;
        }

    }
}