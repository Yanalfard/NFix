using DataLayer.Models.Regular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Api
{
    public interface IVideoCategoryRepo
    {
        TblVideoCatagory SelectVideoCatagoryByName(string name);
    }
}
