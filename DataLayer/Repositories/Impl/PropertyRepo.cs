using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class PropertyRepo : HeartRepo, IPropertyRepo
    {
        private MainProvider _main;
        public PropertyRepo()
        {
            _main = new MainProvider();
        }
        public TblProperty SelectPropertyByName(string name)
        {
            return _main.SelectPropertyByName(name);
        }

    }
}