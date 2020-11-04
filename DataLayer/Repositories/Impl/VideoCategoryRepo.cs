using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Impl
{
    public class VideoCategoryRepo : HeartRepo, IVideoCategoryRepo
    {
        private MainProvider _main;
        public VideoCategoryRepo()
        {
            _main = new MainProvider();
        }

        public TblVideoCatagory SelectVideoCatagoryByName(string name)
        {
            return _main.SelectVideoCatagoryByName(name);
        }
    }
}
