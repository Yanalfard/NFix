using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IAdRepo
    {
        TblAd SelectAdByImage(string image);

    }
}