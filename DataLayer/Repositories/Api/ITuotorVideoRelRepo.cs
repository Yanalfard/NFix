using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface ITuotorVideoRelRepo
    {
        List<TblTuotorVideoRel> SelectTuotorVideoRelByToutorId(int toutorId);
        List<TblTuotorVideoRel> SelectTuotorVideoRelByVideoId(int videoId);

    }
}