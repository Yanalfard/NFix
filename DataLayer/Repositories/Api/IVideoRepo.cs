using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface IVideoRepo
    {
        TblVideo SelectVideoByTitle(string title);
        List<TblVideo> SelectVideoByIsOnline(bool isOnline);
        List<TblVideo> SelectVideoByIsHome(bool isHome);

    }
}