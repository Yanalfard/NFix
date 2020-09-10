using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface ICatagoryRepo
    {
        TblCatagory SelectCatagoryByName(string name);
        List<TblCatagory> SelectCatagoryByCatagoryId(int catagoryId);

    }
}