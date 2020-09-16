using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class ProductPropertyRelCore
    {
        private HttpClient _httpClient;

        public ProductPropertyRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ProductPropertyRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a productPropertyRel to NFix.TblProductPropertyRel
        /// </summary>
        /// <param name="productPropertyRel"></param>
        /// <returns></returns>
        public async Task<DtoTblProductPropertyRel> AddProductPropertyRel(TblProductPropertyRel productPropertyRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProductPropertyRelCore/AddProductPropertyRel", productPropertyRel);
            DtoTblProductPropertyRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProductPropertyRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a productPropertyRel from NFix.TblProductPropertyRel using its id
        /// </summary>
        /// <param name="productPropertyRel"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProductPropertyRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductPropertyRelCore/DeleteProductPropertyRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a productPropertyRel at NFix.TblProductPropertyRel
        /// </summary>
        /// <param name="productPropertyRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateProductPropertyRel(TblProductPropertyRel productPropertyRel, int logId)
        {
            List<object> productPropertyRelAndLogId = new List<object>();
            productPropertyRelAndLogId.Add(productPropertyRel);
            productPropertyRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProductPropertyRelCore/UpdateProductPropertyRel", productPropertyRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all productPropertyRels from NFix.TblProductPropertyRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblProductPropertyRel>> SelectAllProductPropertyRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ProductPropertyRelCore/SelectAllProductPropertyRels");
            List<DtoTblProductPropertyRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductPropertyRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblProductPropertyRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblProductPropertyRel> SelectProductPropertyRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductPropertyRelCore/SelectProductPropertyRelById?id={id}", id);
            DtoTblProductPropertyRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProductPropertyRel>();
            return ans;
        }
        /// <summary>
        /// Select ProductPropertyRels from NFix.TblProductPropertyRel by productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblProductPropertyRel>> SelectProductPropertyRelByProductId(int productId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductPropertyRelCore/SelectProductPropertyRelByProductId?productId={productId}", productId);
            List<DtoTblProductPropertyRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductPropertyRel>>();
            return ans;
        }
        /// <summary>
        /// Select ProductPropertyRels from NFix.TblProductPropertyRel by propertyId
        /// </summary>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblProductPropertyRel>> SelectProductPropertyRelByPropertyId(int propertyId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductPropertyRelCore/SelectProductPropertyRelByPropertyId?propertyId={propertyId}", propertyId);
            List<DtoTblProductPropertyRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductPropertyRel>>();
            return ans;
        }

    }
}