using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class ProductCommentRelCore
    {
        private HttpClient _httpClient;

        public ProductCommentRelCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ProductCommentRelCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a productCommentRel to NFix.TblProductCommentRel
        /// </summary>
        /// <param name="productCommentRel"></param>
        /// <returns></returns>
        public async Task<DtoTblProductCommentRel> AddProductCommentRel(TblProductCommentRel productCommentRel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProductCommentRelCore/AddProductCommentRel", productCommentRel);
            DtoTblProductCommentRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProductCommentRel>();
            return ans;
        }
        /// <summary>
        /// Deletes a productCommentRel from NFix.TblProductCommentRel using its id
        /// </summary>
        /// <param name="productCommentRel"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProductCommentRel(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCommentRelCore/DeleteProductCommentRel?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a productCommentRel at NFix.TblProductCommentRel
        /// </summary>
        /// <param name="productCommentRel"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateProductCommentRel(TblProductCommentRel productCommentRel, int logId)
        {
            List<object> productCommentRelAndLogId = new List<object>();
            productCommentRelAndLogId.Add(productCommentRel);
            productCommentRelAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProductCommentRelCore/UpdateProductCommentRel", productCommentRelAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all productCommentRels from NFix.TblProductCommentRel
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblProductCommentRel>> SelectAllProductCommentRels()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ProductCommentRelCore/SelectAllProductCommentRels");
            List<DtoTblProductCommentRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductCommentRel>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblProductCommentRel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblProductCommentRel> SelectProductCommentRelById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCommentRelCore/SelectProductCommentRelById?id={id}", id);
            DtoTblProductCommentRel ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProductCommentRel>();
            return ans;
        }
        /// <summary>
        /// Select ProductCommentRels from NFix.TblProductCommentRel by productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblProductCommentRel>> SelectProductCommentRelByProductId(int productId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCommentRelCore/SelectProductCommentRelByProductId?productId={productId}", productId);
            List<DtoTblProductCommentRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductCommentRel>>();
            return ans;
        }
        /// <summary>
        /// Select ProductCommentRels from NFix.TblProductCommentRel by commentId
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public async Task<List<DtoTblProductCommentRel>> SelectProductCommentRelByCommentId(int commentId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCommentRelCore/SelectProductCommentRelByCommentId?commentId={commentId}", commentId);
            List<DtoTblProductCommentRel> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProductCommentRel>>();
            return ans;
        }

    }
}