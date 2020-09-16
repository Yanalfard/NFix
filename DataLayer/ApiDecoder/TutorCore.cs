using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class TutorCore
    {
        private HttpClient _httpClient;

        public TutorCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/TutorCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a tutor to NFix.TblTutor
        /// </summary>
        /// <param name="tutor"></param>
        /// <returns></returns>
        public async Task<DtoTblTutor> AddTutor(TblTutor tutor)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/TutorCore/AddTutor", tutor);
            DtoTblTutor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblTutor>();
            return ans;
        }
        /// <summary>
        /// Deletes a tutor from NFix.TblTutor using its id
        /// </summary>
        /// <param name="tutor"></param>
        /// <returns></returns>
        public async Task<bool> DeleteTutor(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/TutorCore/DeleteTutor?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a tutor at NFix.TblTutor
        /// </summary>
        /// <param name="tutor"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateTutor(TblTutor tutor, int logId)
        {
            List<object> tutorAndLogId = new List<object>();
            tutorAndLogId.Add(tutor);
            tutorAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/TutorCore/UpdateTutor", tutorAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all tutors from NFix.TblTutor
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblTutor>> SelectAllTutors()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/TutorCore/SelectAllTutors");
            List<DtoTblTutor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblTutor>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblTutor by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblTutor> SelectTutorById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/TutorCore/SelectTutorById?id={id}", id);
            DtoTblTutor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblTutor>();
            return ans;
        }
        public async Task<DtoTblTutor> SelectTutorByName(string name)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/TutorCore/SelectTutorByName?name={name}", name);
            DtoTblTutor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblTutor>();
            return ans;
        }
        public async Task<List<DtoTblTutor>> SelectTutorByIdentificationNo(int identificationNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/TutorCore/SelectTutorByIdentificationNo?identificationNo={identificationNo}", identificationNo);
            List<DtoTblTutor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblTutor>>();
            return ans;
        }
        public async Task<DtoTblTutor> SelectTutorByTellNo(string tellNo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/TutorCore/SelectTutorByTellNo?tellNo={tellNo}", tellNo);
            DtoTblTutor ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblTutor>();
            return ans;
        }
        public async Task<List<DtoTblTutor>> SelectTutorByUserPassId(int userPassId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/TutorCore/SelectTutorByUserPassId?userPassId={userPassId}", userPassId);
            List<DtoTblTutor> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblTutor>>();
            return ans;
        }

    }
}