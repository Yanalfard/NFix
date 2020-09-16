using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IPropertyRepo
    {
        TblProperty SelectPropertyByName(string name);

    }
}