using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblLog : Metadata.MdLog
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public DtoTblLog(Metadata.MdLog log)
        {
            id = log.id;
            LogText = log.LogText;
            MoneyTransfered = log.MoneyTransfered;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblLog(Metadata.MdLog log, HttpStatusCode statusEffect, string errorStr)
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