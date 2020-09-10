using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblLog : TblLog
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public DtoTblLog(TblLog log)
        {
            id = log.id;
            LogText = log.LogText;
            MoneyTransfered = log.MoneyTransfered;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblLog(TblLog log, HttpStatusCode statusEffect, string errorStr)
        {
            id = log.id;
            LogText = log.LogText;
            MoneyTransfered = log.MoneyTransfered;

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblLog()
        {
        }
    }
}