using DataLayer.Models.Regular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Api
{
    public interface IVideoCommentRelRepo
    {
        List<TblVideoCommentRel> SelectVideoCommentRelByVideoId(int videoId);
        List<TblVideoCommentRel> SelectVideoCommentRelByCommentId(int commentId);
    }
}
