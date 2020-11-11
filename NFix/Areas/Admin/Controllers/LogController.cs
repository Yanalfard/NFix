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
                viewModel.Add(new HistoryLogViewModel()
                {
                    Date=item.Date,
                    ClientTell=_client.SelectClientById(Convert.ToInt32(item.ClientId)).TellNo,
                    id=item.id,
                    LogText=item.LogText,
                    MoneyTransfered=item.MoneyTransfered
                });
            }
            return PartialView(viewModel.OrderByDescending(i => i.Date));
        }
    }
}