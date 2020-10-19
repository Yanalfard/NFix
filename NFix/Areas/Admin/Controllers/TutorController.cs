using DataLayer.Models.Regular;
using DataLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class TutorController : Controller
    {
        // GET: Admin/Tutor
        #region Tutor

        public ActionResult TutorTable()
        {
            return View();
        }
        public ActionResult TutorAdder()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TutorAdder(TutorViewModel tutor, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {

                if (Image != null)
                {
                    tutor.MainImage = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                    Image.SaveAs(Server.MapPath("/Resources/Tutor/" + tutor.MainImage));
                }
                TblTutor tblTutor = new TblTutor()
                {
                    Description = tutor.Description,
                    IdentificationNo = tutor.IdentificationNo,
                    MainImage = tutor.MainImage,
                    Name = tutor.Name,
                    TellNo = tutor.TellNo,
                };
                return View();
            }
            return View();

        }

        #endregion

    }
}