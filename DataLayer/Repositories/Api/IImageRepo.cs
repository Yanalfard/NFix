using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IImageRepo
    {
        TblImage SelectImageByImage(string image);

    }
}