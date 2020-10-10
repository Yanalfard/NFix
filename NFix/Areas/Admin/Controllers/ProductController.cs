using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        #region Product

        public ActionResult ProductTable()
        {
            return View();
        }

        public ActionResult ProductAdder()
        {
            return View();
        }

        public ActionResult OrderTable()
        {
            return View();
        }


        #endregion

    }
}