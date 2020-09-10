using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IKeywordRepo
    {
        TblKeyword SelectKeywordByName(string name);

    }
}