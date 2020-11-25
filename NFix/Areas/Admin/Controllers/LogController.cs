using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class LogController : Controller
    {
        private ClientService _client = new ClientService();
        private LogService _log = new LogService();

        // GET: Admin/Log
        public ActionResult HistoryLog()
        {
            List<TblLog> clientLog = _log.SelectAllLogs().ToList();
            List<HistoryLogViewModel> viewModel = new List<HistoryLogViewModel>();
            foreach (var item in clientLog)
            {
                var client = _client.SelectClientById(Convert.ToInt32(item.ClientId));
                HistoryLogViewModel tbl = new HistoryLogViewModel();
                tbl.Date = item.Date;
                if (client != null)
                {
                    tbl.ClientTell = client.TellNo;
                }
                else
                {
                    tbl.ClientTell = "کاربر حذف شده است";
                }
                tbl.id = item.id;
                tbl.LogText = item.LogText;
                tbl.MoneyTransfered = item.MoneyTransfered;
                tbl.IsValid = item.IsValid;
                tbl.PriceId = item.PriceId;
                tbl.Discount = item.Discount;
                viewModel.Add(tbl);
            }
            return PartialView(viewModel.OrderByDescending(i => i.Date));
        }
    }
}