using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class ProductImageRelCore
    {
        private HttpClient _httpClient;

        public ProductImageRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ProductImageRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a productImageRel to NFix.TblProductImageRel
        /// </summary>
        /// <param name="productImageRel"></param>
        /// <returns></returns>
        public async Task<DtoTblProductImageRel> AddProductImageRel(TblProductImageRel productImageRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProductImageRelCore/AddProductImageRel", productImageRel);
            DtoTblProductImageRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProductImageRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a productImageRel from NFix.TblProductImageRel using its id
        /// </summary>
        /// <param name="productImageRel"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProductImageRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductImageRelCore/DeleteProductImageRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a productImageRel at NFix.TblProductImageRel
        /// </summary>
        /// <param name="productImageRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateProductImageRel(TblProductImageRel productImageRel, int logId)
        {
            List<object> productImageRelAndLogId = new List<object>();
            productImageRelAndLogId.Add(productImageRel);
            productImageRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProductImageRelCore/UpdateProductImageRel", productImageRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all productImageRels from NFix.TblProductImageRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblProductImageRel>> SelectAllProductImageRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ProductImageRelCore/SelectAllProductImageRels");
            List<DtoTblProductImageRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductImageRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblProductImageRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblProductImageRel> SelectProductImageRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductImageRelCore/SelectProductImageRelById?id={id}", id);
            DtoTblProductImageRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProductImageRel>();
            return ans;
        }
        /// <summary>
        /// Select ProductImageRels from NFix.TblProductImageRel by productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblProductImageRel>> SelectProductImageRelByProductId(int productId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductImageRelCore/SelectProductImageRelByProductId?productId={productId}", productId);
            List<DtoTblProductImageRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductImageRel>>();
            return ans;
        }
        /// <summary>
        /// Select ProductImageRels from NFix.TblProductImageRel by imageId
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblProductImageRel>> SelectProductImageRelByImageId(int imageId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductImageRelCore/SelectProductImageRelByImageId?imageId={imageId}", imageId);
            List<DtoTblProductImageRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductImageRel>>();
            return ans;
        }

    }
}