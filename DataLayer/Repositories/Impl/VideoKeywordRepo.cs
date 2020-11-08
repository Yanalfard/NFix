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
    public class VideoKeywordRepo : HeartRepo, IVideoKeywordRepo
    {
        private MainProvider _main;
        public VideoKeywordRepo()
        {
            _main = new MainProvider();
        }
        public TblVideoKeyword SelectVideoKeywordByVideoId(int videoId)
        {
            return _main.SelectVideoKeywordByVideoId(videoId);
        }
    }
}
