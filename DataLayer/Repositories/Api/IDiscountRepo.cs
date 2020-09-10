using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IDiscountRepo
    {
        TblDiscount SelectDiscountByName(string name);

    }
}