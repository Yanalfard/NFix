using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class LogRepo : HeartRepo, ILogRepo
    {
        private MainProvider _main;
        public LogRepo()
        {
            _main = new MainProvider();
        }

    }
}