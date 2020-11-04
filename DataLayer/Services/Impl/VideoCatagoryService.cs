using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services.Impl
{
    public class VideoCatagoryService : IVideoCategoryService
    {
        public bool AddVideoCatagory(TblVideoCatagory ad)
        {
            return new VideoCategoryRepo().Add(ad);
        }
        public bool DeleteVideoCatagory(int id)
        {
            return new VideoCategoryRepo().Delete<TblVideoCatagory>(id);
        }
        public bool UpdateVideoCatagory(TblVideoCatagory ad, int logId)
        {
            return new VideoCategoryRepo().Update(ad, logId);
        }
        public List<TblVideoCatagory> SelectAllVideoCatagorys()
        {
            List<TblVideoCatagory> allVideos = new MainProvider().SelectAll(EnumRepo.Tables.TblVideoCatagory).Cast<TblVideoCatagory>().ToList();
            return allVideos;
        }
        public TblVideoCatagory SelectVideoCatagoryById(int id)
        {
            return new VideoCategoryRepo().SelectById<TblVideoCatagory>(id);
        }
        public TblVideoCatagory SelectVideoCatagoryByName(string name)
        {
            return new VideoCategoryRepo().SelectVideoCatagoryByName(name);
        }
    }
}
