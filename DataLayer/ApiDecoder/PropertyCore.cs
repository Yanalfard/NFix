using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class PropertyCore
    {
        private HttpClient _httpClient;

        public PropertyCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/PropertyCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a property to NFix.TblProperty
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<DtoTblProperty> AddProperty(TblProperty property)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PropertyCore/AddProperty", property);
            DtoTblProperty ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProperty>();
            return ans;
        }
        /// <summary>
        /// Deletes a property from NFix.TblProperty using its id
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProperty(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/DeleteProperty?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a property at NFix.TblProperty
        /// </summary>
        /// <param name="property"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateProperty(TblProperty property, int logId)
        {
            List<object> propertyAndLogId = new List<object>();
            propertyAndLogId.Add(property);
            propertyAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/PropertyCore/UpdateProperty", propertyAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all propertys from NFix.TblProperty
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblProperty>> SelectAllPropertys()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/PropertyCore/SelectAllPropertys");
            List<DtoTblProperty> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProperty>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblProperty by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblProperty> SelectPropertyById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/SelectPropertyById?id={id}", id);
            DtoTblProperty ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProperty>();
            return ans;
        }
        public async Task<DtoTblProperty> SelectPropertyByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/PropertyCore/SelectPropertyByName?name={name}", name);
            DtoTblProperty ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblProperty>();
            return ans;
        }

    }
}