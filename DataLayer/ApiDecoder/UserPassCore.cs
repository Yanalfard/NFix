using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class UserPassCore
    {
        private HttpClient _httpClient;

        public UserPassCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/UserPassCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a userPass to NFix.TblUserPass
        /// </summary>
        /// <param name="userPass"></param>
        /// <returns></returns>
        public async Task<DtoTblUserPass> AddUserPass(TblUserPass userPass)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/UserPassCore/AddUserPass", userPass);
            DtoTblUserPass ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblUserPass>();
            return ans;
        }
        /// <summary>
        /// Deletes a userPass from NFix.TblUserPass using its id
        /// </summary>
        /// <param name="userPass"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserPass(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/UserPassCore/DeleteUserPass?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a userPass at NFix.TblUserPass
        /// </summary>
        /// <param name="userPass"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateUserPass(TblUserPass userPass, int logId)
        {
            List<object> userPassAndLogId = new List<object>();
            userPassAndLogId.Add(userPass);
            userPassAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/UserPassCore/UpdateUserPass", userPassAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all userPasss from NFix.TblUserPass
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblUserPass>> SelectAllUserPasss()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/UserPassCore/SelectAllUserPasss");
            List<DtoTblUserPass> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblUserPass>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblUserPass by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblUserPass> SelectUserPassById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/UserPassCore/SelectUserPassById?id={id}", id);
            DtoTblUserPass ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblUserPass>();
            return ans;
        }
        /// <summary>
        /// Selects doctors from NFix.TblUserPass by sectionId
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        public async Task<DtoTblUserPass> SelectUserPassByUsernameAndPassword(string username ,string password)
        {
            List<object> obj = new List<object>();
            obj.Add(username);
            obj.Add(password);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/UserPassCore/SelectUserPassByUsernameAndPassword", obj);
            DtoTblUserPass ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblUserPass>();
            return ans;
        }
        public async Task<DtoTblUserPass> SelectUserPassByUsername(string username)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/UserPassCore/SelectUserPassByUsername?username={username}", username);
            DtoTblUserPass ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblUserPass>();
            return ans;
        }
        public async Task<DtoTblUserPass> SelectUserPassByPassword(string password)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/UserPassCore/SelectUserPassByPassword?password={password}", password);
            DtoTblUserPass ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblUserPass>();
            return ans;
        }
        public async Task<List<DtoTblUserPass>> SelectUserPassByIsActive(bool isActive)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/UserPassCore/SelectUserPassByIsActive?isActive={isActive}", isActive);
            List<DtoTblUserPass> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblUserPass>>();
            return ans;
        }

    }
}