using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class ProductCore
    {
        private HttpClient _httpClient;

        public ProductCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ProductCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a product to NFix.TblProduct
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<DtoTblProduct> AddProduct(TblProduct product)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProductCore/AddProduct", product);
            DtoTblProduct ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProduct>();
            return ans;
        }
        /// <summary>
        /// Deletes a product from NFix.TblProduct using its id
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProduct(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCore/DeleteProduct?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a product at NFix.TblProduct
        /// </summary>
        /// <param name="product"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateProduct(TblProduct product, int logId)
        {
            List<object> productAndLogId = new List<object>();
            productAndLogId.Add(product);
            productAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ProductCore/UpdateProduct", productAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all products from NFix.TblProduct
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblProduct>> SelectAllProducts()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ProductCore/SelectAllProducts");
            List<DtoTblProduct> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProduct>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblProduct by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblProduct> SelectProductById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCore/SelectProductById?id={id}", id);
            DtoTblProduct ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProduct>();
            return ans;
        }
        public async Task<DtoTblProduct> SelectProductByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCore/SelectProductByName?name={name}", name);
            DtoTblProduct ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProduct>();
            return ans;
        }
        public async Task<List<DtoTblProduct>> SelectProductByCatagoryId(int catagoryId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCore/SelectProductByCatagoryId?catagoryId={catagoryId}", catagoryId);
            List<DtoTblProduct> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProduct>>();
            return ans;
        }
        public async Task<List<DtoTblProduct>> SelectProductByIsSuggested(bool isSuggested)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCore/SelectProductByIsSuggested?isSuggested={isSuggested}", isSuggested);
            List<DtoTblProduct> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProduct>>();
            return ans;
        }
        public async Task<List<DtoTblComment>> SelectCommentByProductId(int productId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCore/SelectCommentByProductId?productId={productId}", productId);
            List<DtoTblComment> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblComment>>();
            return ans;
        }
        public async Task<List<DtoTblImage>> SelectImageByProductId(int productId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCore/SelectImageByProductId?productId={productId}", productId);
            List<DtoTblImage> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblImage>>();
            return ans;
        }
        public async Task<List<DtoTblKeyword>> SelectKeywordByProductId(int productId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCore/SelectKeywordByProductId?productId={productId}", productId);
            List<DtoTblKeyword> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblKeyword>>();
            return ans;
        }
        public async Task<List<DtoTblProperty>> SelectPropertyByProductId(int productId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ProductCore/SelectPropertyByProductId?productId={productId}", productId);
            List<DtoTblProperty> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProperty>>();
            return ans;
        }

    }
}