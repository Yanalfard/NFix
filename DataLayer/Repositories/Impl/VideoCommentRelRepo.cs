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
    class VideoCommentRelRepo : HeartRepo, IVideoCommentRelRepo
    {
        private MainProvider _main;
        public VideoCommentRelRepo()
        {
            _main = new MainProvider();
        }
        public List<TblVideoCommentRel> SelectVideoCommentRelByCommentId(int commentId)
        {
            return _main.SelectVideoCommentRel(commentId, MainProvider.VideoCommentRel.CommentId);
        }

        public List<TblVideoCommentRel> SelectVideoCommentRelByVideoId(int videoId)
        {
            return _main.SelectVideoCommentRel(videoId, MainProvider.VideoCommentRel.VideoId);
        }
    }
}
