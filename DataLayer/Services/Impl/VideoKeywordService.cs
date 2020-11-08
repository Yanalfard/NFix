using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.Services.Impl
{
    public class VideoKeywordService : IVideoKeywordService
    {
        public bool AddVideoKeyword(TblVideoKeyword videoKeyword)
        {
            return new VideoKeywordRepo().Add(videoKeyword);
        }
        public bool DeleteVideoKeyword(int id)
        {
            return new VideoKeywordRepo().Delete<TblVideoKeyword>(id);
        }
        public bool UpdateVideoKeyword(TblVideoKeyword videoKeyword, int logId)
        {
            return new VideoKeywordRepo().Update(videoKeyword, logId);
        }
        public List<TblVideoKeyword> SelectAllVideoKeywords()
        {
            return new VideoKeywordRepo().SelectAll<TblVideoKeyword>().Cast<TblVideoKeyword>().ToList();
        }
        public TblVideoKeyword SelectVideoKeywordById(int id)
        {
            return new VideoKeywordRepo().SelectById<TblVideoKeyword>(id);
        }
        public TblVideoKeyword SelectVideoKeywordByVideoId(int videoId)
        {
            return new VideoKeywordRepo().SelectVideoKeywordByVideoId(videoId);
        }
    }
}
