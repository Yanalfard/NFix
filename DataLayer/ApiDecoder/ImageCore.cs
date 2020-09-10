using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Models.Dto;
using DataLayer.Models.Regular;

namespace DataLayer.ApiDecoder
{
    public class ImageCore
    {
        private HttpClient _httpClient;

        public ImageCore()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("api/ImageCore"));
            _httpClient.BaseAddress = new Uri(Config.Url);

        }
        /// <summary>
        /// Adds a image to NFix.TblImage
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public async Task<DtoTblImage> AddImage(TblImage image)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ImageCore/AddImage", image);
            DtoTblImage ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblImage>();
            return ans;
        }
        /// <summary>
        /// Deletes a image from NFix.TblImage using its id
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public async Task<bool> DeleteImage(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ImageCore/DeleteImage?id={id}", id);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Updates a image at NFix.TblImage
        /// </summary>
        /// <param name="image"></param>
        /// <param name="logId">Old doctors id</param>
        /// <returns></returns>
        public async Task<bool> UpdateImage(TblImage image, int logId)
        {
            List<object> imageAndLogId = new List<object>();
            imageAndLogId.Add(image);
            imageAndLogId.Add(logId);
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ImageCore/UpdateImage", imageAndLogId);
            bool ans = await httpResponseMessage.Content.ReadAsAsync<bool>();
            return ans;
        }
        /// <summary>
        /// Selects all images from NFix.TblImage
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTblImage>> SelectAllImages()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/ImageCore/SelectAllImages");
            List<DtoTblImage> ans = await httpResponseMessage.Content.ReadAsAsync<List<DtoTblImage>>();
            return ans;
        }
        /// <summary>
        /// Selects a doctor from NFix.TblImage by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoTblImage> SelectImageById(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ImageCore/SelectImageById?id={id}", id);
            DtoTblImage ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblImage>();
            return ans;
        }
        public async Task<DtoTblImage> SelectImageByImage(string image)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"api/ImageCore/SelectImageByImage?image={image}", image);
            DtoTblImage ans = await httpResponseMessage.Content.ReadAsAsync<DtoTblImage>();
            return ans;
        }

    }
}