using DataLayer.Models.Regular;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Services.Impl
{
    public class OrderService
    {
        MainProvider _main = new MainProvider();
        public bool AddOrder(TblOrder order)
        {
            _main.Add<TblOrder>(order);
            return true;
        }
        public bool DeleteOrder(int id)
        {
            _main.Delete(EnumRepo.Tables.TblOrder, id);
            return true;
        }
        public bool UpdateOrder(TblOrder order, int logId)
        {
            _main.Update<TblOrder>(order, logId);
            return true;
        }
        public List<TblOrder> SelectAllOrders()
        {
           return _main.SelectAll(EnumRepo.Tables.TblOrder).Cast<TblOrder>().ToList();
        }
        public TblOrder SelectOrderById(int id)
        {
            return (TblOrder)_main.SelectById(EnumRepo.Tables.TblOrder, id);
        }


        public TblOrder SelectOrderByIsFinaly(bool isFinaly)
        {
            return _main.SelectOrderByIsFinaly(isFinaly);
        }

        public TblOrder SelectOrderByIsDate(DateTime date)
        {
            return _main.SelectOrderByIsDate(date);
        }
    }
}
