using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using DataLayer.Models.Regular;
using DataLayer.ViewModel;

namespace NFix
{
    public static class PersianCalender
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }

        public static LiveShowCaseViewModel ToShowCaseLive(this TblLive value)
        {
            return new LiveShowCaseViewModel();
        }
    }
}