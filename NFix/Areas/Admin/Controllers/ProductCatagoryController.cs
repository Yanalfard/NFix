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
                return RedirectToAction("/ErrorPage/NotFound");
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
                return RedirectToAction("/ErrorPage/NotFound");
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
                return RedirectToAction("/ErrorPage/NotFound");
            }

        }

        // POST: Admin/Product_Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle,ParentID")] TblCatagory product_Groups)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _catagory.AddCatagory(product_Groups);
                    return PartialView("ListGroups", _catagory.SelectAllCatagorys().Where(g => g.CatagoryId == null));
                }
                ViewBag.ParentID = new SelectList(_catagory.SelectAllCatagorys(), "GroupID", "GroupTitle", product_Groups.CatagoryId);
                return View(product_Groups);
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
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
                return RedirectToAction("/ErrorPage/NotFound");
            }

        }

        // POST: Admin/Product_Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle,ParentID")] TblCatagory product_Groups)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _catagory.UpdateCatagory(product_Groups,product_Groups.id);
                    return PartialView("ListGroups", _catagory.SelectAllCatagorys().Where(g => g.CatagoryId == null));
                }
                ViewBag.ParentID = new SelectList(_catagory.SelectAllCatagorys(), "GroupID", "GroupTitle", product_Groups.CatagoryId);
                return View(product_Groups);
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }

        }

        //// GET: Admin/Product_Groups/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        try
        //        {
        //            var group = _catagory.SelectCatagoryById(id);
        //            bool DeleteCheck = _productGroups.GetProductGroupsBySelectGroup(id);
        //            if (DeleteCheck)
        //            {
        //                return Json(new { success = false, responseText = "خطا در حذف  اول جنس مربوطه رو حذف کنید" }, JsonRequestBehavior.AllowGet);
        //            }
        //            if (group.Product_Groups1.Any())
        //            {
        //                foreach (var subGroup in _productGroups.GetAllProductGroups().Where(g => g.ParentID == id))
        //                {
        //                    bool DeleteCheck2 = _productGroups.GetProductGroupsBySelectGroup(subGroup.GroupID);
        //                    if (DeleteCheck2)
        //                    {
        //                        return Json(new { success = false, responseText = "خطا در حذف  گروه لطفا دقت فرمایید" }, JsonRequestBehavior.AllowGet);
        //                    }
        //                    _productGroups.DeleteProductGroups(subGroup);
        //                }
        //            }
        //            _productGroups.DeleteProductGroups(group);
        //            return Json(new { success = true, responseText = "گروه حذف شد" }, JsonRequestBehavior.AllowGet);
        //        }
        //        catch
        //        {
        //            return Json(new { success = false, responseText = "خطا در حذف  گروه لطفا دقت فرمایید" }, JsonRequestBehavior.AllowGet);

        //        }
        //    }
        //    catch
        //    {
        //        return RedirectToAction("/ErrorPage/NotFound");
        //    }
        //}
        //// POST: Admin/Product_Groups/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        try
        //        {
        //            bool deleteChech = _productGroups.GetProductGroupsByParentId(id);
        //            if (deleteChech)
        //            {
        //                Product_Groups product_Groups = _productGroups.GetProductGroupsById(id);
        //                _productGroups.DeleteProductGroups(product_Groups);
        //                return Json(new { success = false, responseText = "خطا در حذف  گروه لطفا دقت فرمایید" }, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                return Json(new { success = true, responseText = "گروه حذف شد" }, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        catch
        //        {
        //            return Json(new { success = false, responseText = "خطا در حذف  گروهلطفا دقت فرمایید" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch
        //    {
        //        return RedirectToAction("/ErrorPage/NotFound");
        //    }


        //}

    }
}