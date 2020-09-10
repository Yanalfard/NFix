using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class ProductKeywordRelCore
    {
        private HttpClient _httpClient;

        public ProductKeywordRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ProductKeywordRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a productKeywordRel to NFix.TblProductKeywordRel
        /// </summary>
        /// <param name="productKeywordRel"></param>
        /// <returns></returns>
        public async Task<DtoTblProductKeywordRel> AddProductKeywordRel(TblProductKeywordRel productKeywordRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProductKeywordRelCore/AddProductKeywordRel", productKeywordRel);
            DtoTblProductKeywordRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProductKeywordRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a productKeywordRel from NFix.TblProductKeywordRel using its id
        /// </summary>
        /// <param name="productKeywordRel"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProductKeywordRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductKeywordRelCore/DeleteProductKeywordRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a productKeywordRel at NFix.TblProductKeywordRel
        /// </summary>
        /// <param name="productKeywordRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateProductKeywordRel(TblProductKeywordRel productKeywordRel, int logId)
        {
            List<object> productKeywordRelAndLogId = new List<object>();
            productKeywordRelAndLogId.Add(productKeywordRel);
            productKeywordRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProductKeywordRelCore/UpdateProductKeywordRel", productKeywordRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all productKeywordRels from NFix.TblProductKeywordRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblProductKeywordRel>> SelectAllProductKeywordRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ProductKeywordRelCore/SelectAllProductKeywordRels");
            List<DtoTblProductKeywordRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductKeywordRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblProductKeywordRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblProductKeywordRel> SelectProductKeywordRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductKeywordRelCore/SelectProductKeywordRelById?id={id}", id);
            DtoTblProductKeywordRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProductKeywordRel>();
            return ans;
        }
        /// <summary>
        /// Select ProductKeywordRels from NFix.TblProductKeywordRel by productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblProductKeywordRel>> SelectProductKeywordRelByProductId(int productId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductKeywordRelCore/SelectProductKeywordRelByProductId?productId={productId}", productId);
            List<DtoTblProductKeywordRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductKeywordRel>>();
            return ans;
        }
        /// <summary>
        /// Select ProductKeywordRels from NFix.TblProductKeywordRel by keywordId
        /// </summary>
        /// <param name="keywordId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblProductKeywordRel>> SelectProductKeywordRelByKeywordId(int keywordId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductKeywordRelCore/SelectProductKeywordRelByKeywordId?keywordId={keywordId}", keywordId);
            List<DtoTblProductKeywordRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductKeywordRel>>();
            return ans;
        }

    }
}