using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class LogService : ILogService
    {
        public TblLog AddLog(TblLog log)
        {
            return new LogRepo().Add(log);
        }
        public bool DeleteLog(int id)
        {
            return new LogRepo().Delete<TblLog>(id);
        }
        public bool UpdateLog(TblLog log, int logId)
        {
            return new LogRepo().Update(log, logId);
        }
        public List<TblLog> SelectAllLogs()
        {
            return new LogRepo().SelectAll<TblLog>().Cast<TblLog>().ToList();
        }
        public TblLog SelectLogById(int id)
        {
            return new LogRepo().SelectById<TblLog>(id);
        }

    }
}