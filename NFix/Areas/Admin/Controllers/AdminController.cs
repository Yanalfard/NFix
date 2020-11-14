using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NFix.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private UserPassService _userPass = new UserPassService();
        // GET: Admin/Admin
        public List<AdminViewModel> ListAdmin()
        {
            List<TblUserPass> selectUSer = _userPass.SelectAllUserPasss().Where(i => i.RoleId == 3).ToList();
            List<AdminViewModel> admin = new List<AdminViewModel>();
            foreach (var item in selectUSer)
            {
                admin.Add(new AdminViewModel()
                {
                    id = item.id,
                    Auth = item.Auth,
                    IsActive = item.IsActive,
                    RoleId = item.RoleId,
                    UserName = item.Username,
                    OldPassword = item.Password
                });
            }
            return admin;
        }
        public ActionResult Index()
        {
            return View(ListAdmin());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdminViewModel admin)
        {
            admin.UserName = admin.UserName.Trim().ToLower().Replace(" ", "");
            if (_userPass.SelectAllUserPasss().Any(u => u.Username == admin.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری تکراریست");
            }
            else
            {
                TblUserPass addUserPass = new TblUserPass()
                {
                    IsActive = admin.IsActive,
                    Auth = Guid.NewGuid().ToString(),
                    Username = admin.UserName,
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(admin.Password, "SHA256"),
                    RoleId = 3
                };
                bool add = _userPass.AddUserPass(addUserPass);
                return View("Index", ListAdmin());
            }
            return View(admin);
        }


        public ActionResult Edit(int id)
        {
            var client = _userPass.SelectUserPassById(id);
            AdminViewModel userViewModel = new AdminViewModel()
            {
                id = client.id,
                Password = client.Password,
                UserName = client.Username,
                IsActive = client.IsActive,
                Auth = client.Auth,
                RoleId = client.RoleId,

            };
            return View(userViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdminViewModel admin)
        {
            admin.UserName = admin.UserName.Trim().ToLower().Replace(" ", "");
            if (_userPass.SelectAllUserPasss().Where(i => i.id != admin.id).Any(u => u.Username == admin.UserName.ToLower()))
            {
                ModelState.AddModelError("UserName", "نام کاربری تکراریست");
            }
            else
            {
                var selectUser = _userPass.SelectUserPassById(admin.id);
                TblUserPass addUserPass = new TblUserPass()
                {
                    id = selectUser.id,
                    IsActive = admin.IsActive,
                    Auth = Guid.NewGuid().ToString(),
                    Username = admin.UserName,
                    Password = selectUser.Password,
                    RoleId = admin.RoleId,
                };
                bool add = _userPass.UpdateUserPass(addUserPass, admin.id);
                if (add)
                {
                    return View("Index", ListAdmin());
                };
            };
            return View(admin);
        }


        public ActionResult DeleteAdmin(int id)
        {
            var client = _userPass.SelectUserPassById(id);
            bool c = _userPass.DeleteUserPass(client.id);
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
                TblUserPass selectUser = _userPass.SelectUserPassById(UserID);
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

    }
}