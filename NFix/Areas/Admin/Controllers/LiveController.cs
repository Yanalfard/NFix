using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models.Regular;
using DataLayer.Services.Api;
using DataLayer.Services.Impl;
using DataLayer.ViewModel;

namespace NFix.Areas.Admin.Controllers
{
    public class LiveController : Controller
    {
        private LiveService _live = new LiveService();
        public ActionResult LiveTable()
        {
            List<LiveShowCaseViewModel> allLives = new List<LiveShowCaseViewModel>();
            _live.SelectAllLives().ForEach(i => allLives.Add(new LiveShowCaseViewModel(i)));
            return View(allLives);
        }

        public ActionResult LiveAdder()
        {
            List<TblTutor> tutors = new TutorService().SelectAllTutors();
            return View(tutors);
        }
        [HttpPost]
        public ActionResult LiveAdder(TblLive live, HttpPostedFileBase MainImage)
        {

            if (User.Identity.IsAuthenticated)
            {
                if (MainImage != null && MainImage.IsImage())
                {
                    live.MainImage = Guid.NewGuid() + Path.GetExtension(MainImage.FileName);
                    MainImage.SaveAs(Server.MapPath("/Resources/Live/Image/" + live.MainImage));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Resources/Live/Image/" + live.MainImage),
                        Server.MapPath("/Resources/Live/Image/Thumb/" + live.MainImage));
                }
                new LiveService().AddLive(live);
            }
            return RedirectToAction("LiveTable");

        }

        public ActionResult LiveDelete(int id)
        {
            if (_live.DeleteLive(id))
                return Redirect("/Admin/Live/LiveTable");
            return JavaScript("alert('ERROR')");
        }
        public ActionResult LiveEdit(int id)
        {
            List<TblTutor> allTutors = new TutorService().SelectAllTutors();
            TblLive live = new LiveService().SelectLiveById(id);
            List<TblTutor> resultTutors = new List<TblTutor> { live.TblTutor };
            foreach (TblTutor i in allTutors)
                if (i.id != live.ToutorId)
                    resultTutors.Add(i);
            ViewBag.Tutors = resultTutors;
            return View(live);
        }

        public ActionResult SubmitLiveEdit(TblLive liveToEdit, HttpPostedFileBase MainImage)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (MainImage != null && MainImage.IsImage())
                    {
                        liveToEdit.MainImage = Guid.NewGuid() + Path.GetExtension(MainImage.FileName);
                        MainImage.SaveAs(Server.MapPath("/Resources/Live/Image/" + liveToEdit.MainImage));
                        ImageResizer img = new ImageResizer();
                        img.Resize(Server.MapPath("/Resources/Live/Image/" + liveToEdit.MainImage),
                            Server.MapPath("/Resources/Live/Image/Thumb/" + liveToEdit.MainImage));
                    }

                    _live.UpdateLive(liveToEdit, liveToEdit.id);
                    return RedirectToAction("LiveTable");

                }
                return JavaScript("alert('error')");

            }
            return JavaScript("alert('error')");
        }
    }
}