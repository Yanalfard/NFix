using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class KeywordRepo : HeartRepo, IKeywordRepo
    {
        private MainProvider _main;
        public KeywordRepo()
        {
            _main = new MainProvider();
        }
        public TblKeyword SelectKeywordByName(string name)
        {
            return _main.SelectKeywordByName(name);
        }

    }
}