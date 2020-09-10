using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class ImageService : IImageService
    {
        public TblImage AddImage(TblImage image)
        {
            return new ImageRepo().Add(image);
        }
        public bool DeleteImage(int id)
        {
            return new ImageRepo().Delete<TblImage>(id);
        }
        public bool UpdateImage(TblImage image, int logId)
        {
            return new ImageRepo().Update(image, logId);
        }
        public List<TblImage> SelectAllImages()
        {
            return new ImageRepo().SelectAll<TblImage>().Cast<TblImage>().ToList();
        }
        public TblImage SelectImageById(int id)
        {
            return new ImageRepo().SelectById<TblImage>(id);
        }
        public TblImage SelectImageByImage(string image)
        {
            return new ImageRepo().SelectImageByImage(image);
        }

    }
}