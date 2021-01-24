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

        public ActionResult CreateLive(TblLive live, HttpPostedFileBase MainImage)
        {
            if (ModelState.IsValid)
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

            return View("LiveTable");
        }
    }
}