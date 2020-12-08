using DataLayer.Models.Dto;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeTutorsController : Controller
    {
        private TutorService _tutor = new TutorService();

        // GET: HomeTutors
        public ActionResult TutorsPage()
        {
            var allTutors = _tutor.SelectAllTutors();
            //List<DtoTblTutor> result = MethodRepo.ConvertToDto<TblTutor, DtoTblTutor>(allTutors);
            return PartialView(allTutors);
        }
        [Route("TutorName/{id}/{name}")]
        public ActionResult TutorView(int id, string name)
        {
            ViewBag.Name = name;
            TblTutor selectTutorById = _tutor.SelectTutorById(id);
            DtoTblTutor result = new DtoTblTutor()
            {
                id = selectTutorById.id,
                Name = selectTutorById.Name,
                IdentificationNo = selectTutorById.IdentificationNo,
                TellNo = selectTutorById.TellNo,
                MainImage = selectTutorById.MainImage,
                Description = selectTutorById.Description,
                UserPassId = selectTutorById.UserPassId,

            };
            return View(selectTutorById);
        }
    }
}