using System;
using System.Collections;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class HeartRepo : IHeartRepo
    {
        private MainProvider _main;
        public HeartRepo()
        {
            _main = new MainProvider();
        }

        public virtual bool Add<T>(T table)
        {
            return Convert.ToBoolean(_main.Add(table));
        }

        public virtual bool Update<T>(T table, int logId)
        {
            return _main.Update(table, logId);
        }

        public virtual bool Delete<T>(int id)
        {
            Enum.TryParse(typeof(T).ToString().Split('.')[3], false, out EnumRepo.Tables table);
            return _main.Delete(table, id);
        }

        public virtual IEnumerable SelectAll<T>()
        {
            Enum.TryParse(typeof(T).ToString().Split('.')[3], false, out EnumRepo.Tables table);
            return _main.SelectAll(table);
        }

        public virtual T SelectById<T>(int id)
        {
            Enum.TryParse(typeof(T).ToString().Split('.')[3], false, out EnumRepo.Tables table);
            return (T)_main.SelectById(table, id);
        }
    }
}