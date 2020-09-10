using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class CatagoryCore
    {
        private HttpClient _httpClient;

        public CatagoryCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/CatagoryCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a catagory to NFix.TblCatagory
        /// </summary>
        /// <param name="catagory"></param>
        /// <returns></returns>
        public async Task<DtoTblCatagory> AddCatagory(TblCatagory catagory)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/CatagoryCore/AddCatagory", catagory);
            DtoTblCatagory ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblCatagory>();
            return ans;
        }
        /// <summary>
        /// Deletes a catagory from NFix.TblCatagory using its id
        /// </summary>
        /// <param name="catagory"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCatagory(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CatagoryCore/DeleteCatagory?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a catagory at NFix.TblCatagory
        /// </summary>
        /// <param name="catagory"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateCatagory(TblCatagory catagory, int logId)
        {
            List<object> catagoryAndLogId = new List<object>();
            catagoryAndLogId.Add(catagory);
            catagoryAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/CatagoryCore/UpdateCatagory", catagoryAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all catagorys from NFix.TblCatagory
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblCatagory>> SelectAllCatagorys()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/CatagoryCore/SelectAllCatagorys");
            List<DtoTblCatagory> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblCatagory>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblCatagory by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblCatagory> SelectCatagoryById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CatagoryCore/SelectCatagoryById?id={id}", id);
            DtoTblCatagory ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblCatagory>();
            return ans;
        }
        public async Task<DtoTblCatagory> SelectCatagoryByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CatagoryCore/SelectCatagoryByName?name={name}", name);
            DtoTblCatagory ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblCatagory>();
            return ans;
        }
        public async Task<List<DtoTblCatagory>> SelectCatagoryByCatagoryId(int catagoryId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/CatagoryCore/SelectCatagoryByCatagoryId?catagoryId={catagoryId}", catagoryId);
            List<DtoTblCatagory> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblCatagory>>();
            return ans;
        }

    }
}