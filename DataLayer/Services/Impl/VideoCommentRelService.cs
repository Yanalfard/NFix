using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services.Impl
{
    public class VideoCommentRelService
    {
        public bool AddVideoCommentRel(TblVideoCommentRel VideoCommentRel)
        {
            return new VideoCommentRelRepo().Add(VideoCommentRel);
        }
        public bool DeleteVideoCommentRel(int id)
        {
            return new VideoCommentRelRepo().Delete<TblVideoCommentRel>(id);
        }
        public bool UpdateVideoCommentRel(TblVideoCommentRel VideoCommentRel, int logId)
        {
            return new VideoCommentRelRepo().Update(VideoCommentRel, logId);
        }
        public List<TblVideoCommentRel> SelectAllVideoCommentRels()
        {
            return new VideoCommentRelRepo().SelectAll<TblVideoCommentRel>().Cast<TblVideoCommentRel>().ToList();
        }
        public TblVideoCommentRel SelectVideoCommentRelById(int id)
        {
            return new VideoCommentRelRepo().SelectById<TblVideoCommentRel>(id);
        }
        public List<TblVideoCommentRel> SelectVideoCommentRelByVideoId(int videoId)
        {
            return new VideoCommentRelRepo().SelectVideoCommentRelByVideoId(videoId);
        }
        public List<TblVideoCommentRel> SelectVideoCommentRelByCommentId(int commentId)
        {
            return new VideoCommentRelRepo().SelectVideoCommentRelByCommentId(commentId);
        }
    }
}
