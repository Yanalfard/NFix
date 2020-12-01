using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class DiscountController : Controller
    {
        private DiscountService _discount = new DiscountService();
        // GET: Admin/Discount
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddDiscount()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Index(TblDiscount dis)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_discount.SelectAllDiscounts().Any(u => u.Name == dis.Name))
                    {
                        _discount.AddDiscount(dis);
                        ModelState.Clear();
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("Name", "نام  تکراری است");
                        return View(dis);

                    }
                }
                return View(dis);
            }
            catch
            {
                return Redirect("/fallback.html");
            }

        }
        public ActionResult Delete(int id)
        {
            try
            {
                _discount.DeleteDiscount(id);
                return View("Index");
            }
            catch
            {
                return Redirect("/fallback.html");
            }

        }
        public ActionResult AllDiscount()
        {
            try
            {
                return PartialView(_discount.SelectAllDiscounts());
            }
            catch
            {
                return Redirect("/fallback.html");
            }

        }
    }
}