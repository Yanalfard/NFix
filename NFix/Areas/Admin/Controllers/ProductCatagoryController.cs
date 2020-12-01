using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class ProductCatagoryController : Controller
    {
        // GET: Admin/ProductCatagory
        private CatagoryService _catagory = new CatagoryService();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListGroups()
        {
            try
            {
                var product_Groups = _catagory.SelectAllCatagorys().Where(g => g.CatagoryId == null);
                return PartialView(product_Groups.ToList());
            }
            catch
            {
                return Redirect("/fallback.html");
            }
        }
        // GET: Admin/Product_Groups/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TblCatagory product_Groups = _catagory.SelectCatagoryById(id.Value);
                if (product_Groups == null)
                {
                    return HttpNotFound();
                }
                return View(product_Groups);
            }
            catch
            {
                return Redirect("/fallback.html");
            }

        }

        // GET: Admin/Product_Groups/Create
        public ActionResult Create(int? id)
        {
            try
            {
                return PartialView(new TblCatagory()
                {
                    CatagoryId = id
                });
            }
            catch
            {
                return Redirect("/fallback.html");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Create(TblCatagory product_Groups)
        {
            try
            {
                product_Groups.id = 0;
                _catagory.AddCatagory(product_Groups);
                return PartialView("ListGroups", _catagory.SelectAllCatagorys().Where(g => g.CatagoryId == null));
            }
            catch
            {
                return Redirect("/fallback.html");
            }
        }

        // GET: Admin/Product_Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TblCatagory product_Groups = _catagory.SelectCatagoryById(id.Value);
                if (product_Groups == null)
                {
                    return HttpNotFound();
                }

                return PartialView(product_Groups);
            }
            catch
            {
                return Redirect("/fallback.html");
            }

        }

        // POST: Admin/Product_Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblCatagory product_Groups)
        {
            try
            {
                _catagory.UpdateCatagory(product_Groups, product_Groups.id);
                return PartialView("ListGroups", _catagory.SelectAllCatagorys().Where(g => g.CatagoryId == null));
            }
            catch
            {
                return Redirect("/fallback.html");
            }

        }

        // GET: Admin/Product_Groups/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                try
                {
                    var group = _catagory.SelectCatagoryById(id);
                    TblCatagory DeleteCheck = _catagory.SelectCatagoryById(id);
                    if (DeleteCheck == null)
                    {
                        return Json(new { success = false, responseText = "خطا در حذف  اول جنس مربوطه رو حذف کنید" }, JsonRequestBehavior.AllowGet);
                    }
                    if (group.TblCatagory1.Any())
                    {
                        foreach (var subGroup in _catagory.SelectAllCatagorys().Where(g => g.CatagoryId == id))
                        {
                            TblCatagory DeleteCheck2 = _catagory.SelectCatagoryById(subGroup.id);
                            if (DeleteCheck2 != null)
                            {
                                return Json(new { success = false, responseText = "خطا در حذف  گروه لطفا دقت فرمایید" }, JsonRequestBehavior.AllowGet);
                            }
                            _catagory.DeleteCatagory(subGroup.id);
                        }
                    }
                    _catagory.DeleteCatagory(group.id);
                    return Json(new { success = true, responseText = "گروه حذف شد" }, JsonRequestBehavior.AllowGet);
                }
                catch
                {
                    return Json(new { success = false, responseText = "خطا در حذف  گروه لطفا دقت فرمایید" }, JsonRequestBehavior.AllowGet);

                }
            }
            catch
            {
                return Redirect("/fallback.html");
            }
        }


    }
}