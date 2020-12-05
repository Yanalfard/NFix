using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class VideoCategoryController : Controller
    {
        private VideoCatagoryService _videoCatagory = new VideoCatagoryService();
        private VideoService _video = new VideoService();
        NFixEntities db = new NFixEntities();
        // GET: Admin/VideoCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListGroups()
        {
            try
            {
                var video_Groups = _videoCatagory.SelectAllVideoCatagorys();
                return PartialView(video_Groups.ToList());
            }
            catch
            {
                return Redirect("/fallback.html");
            }
        }

        // GET: Admin/Product_Groups/Create
        public ActionResult Create()
        {
            try
            {
                return PartialView();

            }
            catch
            {
                return Redirect("/fallback.html");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TblVideoCatagory video_Groups, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null && Image.IsImage())
                {
                    video_Groups.Image = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                    Image.SaveAs(Server.MapPath("/Resources/VideoCatagory/" + video_Groups.Image));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Resources/VideoCatagory/" + video_Groups.Image),
                        Server.MapPath("/Resources/VideoCatagory/Thumb/" + video_Groups.Image));
                }
                bool x = _videoCatagory.AddVideoCatagory(video_Groups);
                return RedirectToAction("Index");
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
                TblVideoCatagory video_Groups = _videoCatagory.SelectVideoCatagoryById(id.Value);
                if (video_Groups == null)
                {
                    return HttpNotFound();
                }

                return PartialView(video_Groups);
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
        public ActionResult Edit(TblVideoCatagory video_Groups, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null && Image.IsImage())
                {
                    string fullPathLogo = Request.MapPath("/Resources/VideoCatagory/" + video_Groups.Image);
                    string fullPathLogo2 = Request.MapPath("/Resources/VideoCatagory/Thumb/" + video_Groups.Image);
                    if (System.IO.File.Exists(fullPathLogo))
                    {
                        System.IO.File.Delete(fullPathLogo);
                    }
                    if (System.IO.File.Exists(fullPathLogo2))
                    {
                        System.IO.File.Delete(fullPathLogo2);
                    }
                    video_Groups.Image = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                    Image.SaveAs(Server.MapPath("/Resources/VideoCatagory/" + video_Groups.Image));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Resources/VideoCatagory/" + video_Groups.Image),
                        Server.MapPath("/Resources/VideoCatagory/Thumb/" + video_Groups.Image));

                }
                _videoCatagory.UpdateVideoCatagory(video_Groups, video_Groups.id);
                return RedirectToAction("Index");
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
                    TblVideo DeleteCheck = _video.SelectAllVideos().Where(i => i.CatagoryId == id).SingleOrDefault();
                    if (DeleteCheck != null)
                    {
                        return Json(new { success = false, responseText = "خطا در حذف  اول ویدیو مربوطه رو حذف کنید" }, JsonRequestBehavior.AllowGet);
                    }
                    TblVideoCatagory DeleteCheckCatagory = _videoCatagory.SelectVideoCatagoryById(id);
                    if (DeleteCheckCatagory == null)
                    {
                        return Json(new { success = false, responseText = "فایلی یافت نشد" }, JsonRequestBehavior.AllowGet);
                    }
                    string fullPathLogo = Request.MapPath("/Resources/VideoCatagory/" + DeleteCheckCatagory.Image);
                    if (System.IO.File.Exists(fullPathLogo))
                    {
                        System.IO.File.Delete(fullPathLogo);
                    }
                    string fullPathLogo2 = Request.MapPath("/Resources/VideoCatagory/Thumb/" + DeleteCheckCatagory.Image);
                    if (System.IO.File.Exists(fullPathLogo2))
                    {
                        System.IO.File.Delete(fullPathLogo2);
                    }
                    _videoCatagory.DeleteVideoCatagory(id);
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