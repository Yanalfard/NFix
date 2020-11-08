using DataLayer.Models.Regular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Api
{
    interface IVideoKeywordRepo
    {
        TblVideoKeyword SelectVideoKeywordByVideoId(int videoId);
    }
}
