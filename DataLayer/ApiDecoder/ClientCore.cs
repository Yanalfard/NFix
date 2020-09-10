using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class ClientCore
    {
        private HttpClient _httpClient;

        public ClientCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ClientCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a client to NFix.TblClient
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<DtoTblClient> AddClient(TblClient client)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ClientCore/AddClient", client);
            DtoTblClient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblClient>();
            return ans;
        }
        /// <summary>
        /// Deletes a client from NFix.TblClient using its id
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<bool> DeleteClient(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/DeleteClient?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a client at NFix.TblClient
        /// </summary>
        /// <param name="client"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateClient(TblClient client, int logId)
        {
            List<object> clientAndLogId = new List<object>();
            clientAndLogId.Add(client);
            clientAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ClientCore/UpdateClient", clientAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all clients from NFix.TblClient
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblClient>> SelectAllClients()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ClientCore/SelectAllClients");
            List<DtoTblClient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClient>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblClient by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblClient> SelectClientById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/SelectClientById?id={id}", id);
            DtoTblClient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblClient>();
            return ans;
        }
        public async Task<DtoTblClient> SelectClientByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/SelectClientByName?name={name}", name);
            DtoTblClient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblClient>();
            return ans;
        }
        public async Task<List<DtoTblClient>> SelectClientByIdentificationNo(int identificationNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/SelectClientByIdentificationNo?identificationNo={identificationNo}", identificationNo);
            List<DtoTblClient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClient>>();
            return ans;
        }
        public async Task<DtoTblClient> SelectClientByTellNo(string tellNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/SelectClientByTellNo?tellNo={tellNo}", tellNo);
            DtoTblClient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblClient>();
            return ans;
        }
        public async Task<DtoTblClient> SelectClientByEmail(string email)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/SelectClientByEmail?email={email}", email);
            DtoTblClient ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblClient>();
            return ans;
        }
        public async Task<List<DtoTblClient>> SelectClientByUserPassId(int userPassId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/SelectClientByUserPassId?userPassId={userPassId}", userPassId);
            List<DtoTblClient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClient>>();
            return ans;
        }
        public async Task<List<DtoTblClient>> SelectClientByIsPremium(bool isPremium)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/SelectClientByIsPremium?isPremium={isPremium}", isPremium);
            List<DtoTblClient> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblClient>>();
            return ans;
        }
        public async Task<List<DtoTblProduct>> SelectProductByClientId(int clientId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ClientCore/SelectProductByClientId?clientId={clientId}", clientId);
            List<DtoTblProduct> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblProduct>>();
            return ans;
        }

    }
}