using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NFix.Areas.Admin.Controllers
{
    public class TutorController : Controller
    {
        private UserPassService _userPass = new UserPassService();
        private TutorService _tutor = new TutorService();
        // GET: Admin/Tutor
        #region Tutor

        public ActionResult TutorTable()
        {
            return View(_tutor.SelectAllTutors());
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
                tutor.Username = tutor.Username.Trim().ToLower().Replace(" ", "");
                tutor.TellNo = tutor.TellNo.Trim().ToLower().Replace(" ", "");
                if (_userPass.SelectAllUserPasss().Any(u => u.Username == tutor.Username.ToLower()))
                {
                    ModelState.AddModelError("UserName", "نام کاربری تکراریست");
                }
                else if (_tutor.SelectAllTutors().Any(u => u.IdentificationNo == tutor.IdentificationNo))
                {
                    ModelState.AddModelError("IdentificationNo", "کد ملی وارد شده تکراری است");
                }
                else if (_tutor.SelectAllTutors().Any(u => u.TellNo == tutor.TellNo))
                {
                    ModelState.AddModelError("TellNo", "تلفن  وارد شده تکراری است");
                }
                else
                {

                    TblUserPass userPass = new TblUserPass()
                    {
                        Username = tutor.Username,
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(tutor.Password, "SHA256"),
                        Auth = Guid.NewGuid().ToString(),
                        IsActive = tutor.IsActive,
                        RoleId = 2,
                    };
                    bool addUser = _userPass.AddUserPass(userPass);
                    if (addUser)
                    {
                        if (Image != null)
                        {
                            tutor.MainImage = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                            Image.SaveAs(Server.MapPath("/Resources/Tutor/" + tutor.MainImage));
                        }
                        TblTutor tblTutor = new TblTutor()
                        {
                            Description = tutor.Description,
                            IdentificationNo = tutor.IdentificationNo,
                            MainImage = tutor.MainImage,
                            Name = tutor.Name,
                            TellNo = tutor.TellNo,
                            UserPassId = userPass.id,
                            Specialty= tutor.Specialty,
                        };
                        _tutor.AddTutor(tblTutor);
                        return RedirectToAction("TutorTable");
                    }

                }

            }
            return View(tutor);
        }



        public ActionResult TutorEdit(int id)
        {
            var tutor = _tutor.SelectTutorById(id);
            TutorViewModel tutorViewModel = new TutorViewModel()
            {
                id = tutor.id,
                Description = tutor.Description,
                IdentificationNo = tutor.IdentificationNo,
                Name = tutor.Name,
                TellNo = tutor.TellNo,
                MainImage = tutor.MainImage,
                Username = tutor.TblUserPass.Username,
                UserPassId = tutor.UserPassId,
                Password = tutor.TblUserPass.Password,
                IsActive=tutor.TblUserPass.IsActive,
            };
            return View(tutorViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TutorEdit(TutorViewModel tutor, HttpPostedFileBase Image)
        {
            tutor.Username = tutor.Username.Trim().ToLower().Replace(" ", "");
            tutor.TellNo = tutor.TellNo.Trim().ToLower().Replace(" ", "");
            if (_userPass.SelectAllUserPasss().Where(i => i.id != tutor.UserPassId).Any(u => u.Username == tutor.Username.ToLower()))
            {
                ModelState.AddModelError("UserName", "نام کاربری وارد شده تکراری است");
                return View(tutor);
            }
            else if (_tutor.SelectAllTutors().Where(i => i.id != tutor.id).Any(u => u.IdentificationNo == tutor.IdentificationNo))
            {
                ModelState.AddModelError("IdentificationNo", "ایمیل وارد شده تکراری است");
            }
            else if (_tutor.SelectAllTutors().Where(i => i.id != tutor.id).Any(u => u.TellNo == tutor.TellNo))
            {
                ModelState.AddModelError("TellNo", "تلفن  وارد شده تکراری است");
            }
            else
            {
                var selectimage = _tutor.SelectTutorById(tutor.id);
                if (Image != null)
                {
                    string fullPathLogo = Request.MapPath("/Resources/Tutor/" + selectimage.MainImage);
                    if (System.IO.File.Exists(fullPathLogo))
                    {
                        System.IO.File.Delete(fullPathLogo);
                    }
                    tutor.MainImage = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                    Image.SaveAs(Server.MapPath("/Resources/Tutor/" + tutor.MainImage));
                }
                TblTutor tblTutor = new TblTutor()
                {
                    id = tutor.id,
                    Description = tutor.Description,
                    IdentificationNo = tutor.IdentificationNo,
                    MainImage = tutor.MainImage,
                    Name = tutor.Name,
                    TellNo = tutor.TellNo,
                    UserPassId = tutor.UserPassId,
                    Specialty=tutor.Specialty
                };
                bool X= _tutor.UpdateTutor(tblTutor, tutor.id);
                TblUserPass userPass = new TblUserPass()
                {
                    id = tutor.UserPassId,
                    Username = tutor.Username,
                    Auth = Guid.NewGuid().ToString(),
                    IsActive = tutor.IsActive,
                    RoleId = 2,
                    Password= selectimage.TblUserPass.Password
                };
                bool y= _userPass.UpdateUserPass(userPass, tutor.UserPassId);
                return RedirectToAction("TutorTable");
            }

            return View(tutor);
        }

        public ActionResult deleteTutor(int id)
        {
            var getBlogId = _tutor.SelectTutorById(id);
            string fullPathLogo = Request.MapPath("/Resources/Tutor/" + getBlogId.MainImage);
            if (System.IO.File.Exists(fullPathLogo))
            {
                System.IO.File.Delete(fullPathLogo);
            }
            _tutor.DeleteTutor(id);
            _userPass.DeleteUserPass(getBlogId.UserPassId);
            return JavaScript("");
        }



        public ActionResult EditPass(int id, string name)
        {
            ViewBag.UserID = id;
            ViewBag.UserName = name;
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPass(int UserID, string UserName, ChangePasswordUserTutorViewModel changePass)
        {
            if (ModelState.IsValid)
            {
                TblTutor selectTutor = _tutor.SelectTutorById(UserID);
                TblUserPass selectUser = _userPass.SelectUserPassById(selectTutor.UserPassId);
                TblUserPass tblUser = new TblUserPass()
                {
                    id = selectUser.id,
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(changePass.Password, "SHA256"),
                    Auth = selectUser.Auth,
                    IsActive = selectUser.IsActive,
                    RoleId = selectUser.RoleId,
                    Username = selectUser.Username,

                };
                bool x = _userPass.UpdateUserPass(tblUser, selectUser.id);
                return JavaScript("UIkit.modal(document.getElementById('ModalChangePassword')).hide();doneEdit();");

            }
            ViewBag.UserID = UserID;
            ViewBag.UserName = UserName;
            return PartialView("EditPass", changePass);
        }

        #endregion

    }
}