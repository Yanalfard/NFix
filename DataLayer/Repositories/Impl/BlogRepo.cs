using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class BlogRepo : HeartRepo, IBlogRepo
    {
        private MainProvider _main;
        public BlogRepo()
        {
            _main = new MainProvider();
        }

    }
}