using System.Collections;

namespace DataLayer.Repositories.Api
{
    public interface IHeartRepo
    {
        T Add<T>(T table);
        bool Update<T>(T table, int logId);
        bool Delete<T>(int id);
        IEnumerable SelectAll<T>();
        T SelectById<T>(int id);
    }
}
