using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.ViewModel;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NFix.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        private ProductService _products = new ProductService();
        private ClientService _client = new ClientService();
        private UserPassService _userPass = new UserPassService();
        private OrderService _order = new OrderService();
        private ClientProductRelService _clientProductRel = new ClientProductRelService();
        private LogService _log = new LogService();
        // GET: User/Profile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Info()
        {
            TblUserPass SelectUser = _userPass.SelectUserPassByUsername(User.Identity.Name);
            TblClient selectClientByUserName = _client.SelectClientByUserPassId(SelectUser.id);
            if (selectClientByUserName == null)
            {
                return HttpNotFound();
            }
            TblClientViewModal client = new TblClientViewModal();
            client.id = selectClientByUserName.id;
            client.Name = selectClientByUserName.Name;
            client.Username = SelectUser.Username;
            client.IdentificationNo = selectClientByUserName.IdentificationNo;
            client.TellNo = selectClientByUserName.TellNo;
            client.Email = selectClientByUserName.Email;
            client.Address = selectClientByUserName.Address;
            client.PostalCode = selectClientByUserName.PostalCode;
            client.UserPassId = selectClientByUserName.UserPassId;
            client.Status = selectClientByUserName.Status;
            client.IsPremium = selectClientByUserName.IsPremium;
            client.PremiumTill = selectClientByUserName.PremiumTill;
            client.InviteCode = selectClientByUserName.InviteCode;
            //if (DateTime.Parse(selectClientByUserName.PremiumTill) > DateTime.Now)
            //{
            //    client.DaysTillFinished = ((DateTime.Parse(selectClientByUserName.PremiumTill) - DateTime.Now).Days);
            //    if (client.DaysTillFinished <= 365 && client.DaysTillFinished > 183)
            //    {
            //        client.TotalDays = 365;
            //        client.TotalMonth = 12;
            //    }
            //    else if (client.DaysTillFinished <= 183 && client.DaysTillFinished > 91)
            //    {
            //        client.TotalDays = 183;
            //        client.TotalMonth = 6;
            //    }
            //    else if (client.DaysTillFinished <= 91 && client.DaysTillFinished > 30)
            //    {
            //        client.TotalDays = 91;
            //        client.TotalMonth = 3;
            //    }
            //    else if (client.DaysTillFinished <= 30)
            //    {
            //        client.TotalDays = 1;
            //    }
            //}
            //client.Percentage = (client.TotalDays != 0) ? (Math.Floor(((double)client.DaysTillFinished / client.TotalDays) * 100)) : 0;
            return PartialView(client);
        }
        public ActionResult EditInfo()
        {
            TblUserPass SelectUser = _userPass.SelectUserPassByUsername(User.Identity.Name);
            TblClient selectClientByUserName = _client.SelectClientByUserPassId(SelectUser.id);
            if (selectClientByUserName == null)
            {
                return HttpNotFound();
            }
            return PartialView(selectClientByUserName);
        }
        [HttpPost]
        public ActionResult EditInfo(TblClient client)
        {

            var selectClient = _client.SelectClientById(client.id);
            client.Email = client.Email.Trim().ToLower().Replace(" ", "");
            client.IdentificationNo = client.IdentificationNo.Trim().ToLower().Replace(" ", "");
            client.TellNo = client.TellNo.Trim().ToLower().Replace(" ", "");
            if (_client.SelectAllClients().Any(i => i.id != client.id && i.TellNo == client.TellNo))
            {
                ModelState.AddModelError("TellNo", "شماره تلفن تکراریست");
                return PartialView("EditInfo", client);
            }
            if (_client.SelectAllClients().Any(i => i.id != client.id && i.IdentificationNo == client.IdentificationNo))
            {
                ModelState.AddModelError("IdentificationNo", "کد ملی تکراریست");
                return PartialView("EditInfo", client);
            }
            if (_client.SelectAllClients().Any(i => i.id != client.id && i.Email == client.Email))
            {
                ModelState.AddModelError("Email", " ایمیل تکراریست");
                return PartialView("EditInfo", client);
            }
            bool T = _client.UpdateClient(client, client.id);
            return JavaScript("location.reload(true)");
        }
        public ActionResult ShopCart()
        {
            return PartialView();
        }
        public ActionResult HistoryLog()
        {
            TblClient selectClientByUserName = _client.SelectClientByUserPassId(_userPass.SelectUserPassByUsername(User.Identity.Name).id);
            List<TblLog> clientLog = _log.SelectAllLogs().Where(i => i.ClientId == selectClientByUserName.id).ToList();
            return PartialView(clientLog.OrderByDescending(i => i.Date));
        }
        public ActionResult History()
        {
            TblClient selectClientByUserName = _client.SelectClientByUserPassId(_userPass.SelectUserPassByUsername(User.Identity.Name).id);
            List<TblClientProductRel> found = _clientProductRel.SelectClientProductRelByClientId(selectClientByUserName.id);
            List<TblOrder> foundOrders = new List<TblOrder>();
            List<TblOrder> allOrders = _order.SelectAllOrders();
            foreach (TblClientProductRel i in found)
                foreach (TblOrder j in allOrders)
                    if (i.OrderId == j.id)
                        foundOrders.Add(j);
            foundOrders = foundOrders.DistinctBy(i => i.id).ToList();
            // return PartialView(_order.SelectAllOrders().OrderByDescending(i => i.Date).ToList());
            return PartialView(foundOrders.OrderByDescending(i => i.Date));
        }
        public ActionResult EditPass()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPass(ChangePasswordViewModel changePass)
        {
            if (ModelState.IsValid)
            {
                string hassPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(changePass.OldPassword, "SHA256");
                TblUserPass selectUser = _userPass.SelectUserPassByUsername(User.Identity.Name);
                TblClient selectTutor = _client.SelectClientById(selectUser.id);
                TblUserPass chechUser = _userPass.SelectUserPassByUsernameAndPassword(selectUser.Username, hassPassword);
                if (chechUser != null)
                {
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
                else
                {
                    ModelState.AddModelError("OldPassword", "رمز قدیمی اشتباه می باشد");
                }
            }
            return PartialView("EditPass", changePass);
        }


        public ActionResult FactorView(int id)
        {
            TblOrder order = _order.SelectOrderById(id);
            ViewBag.FactId = id;
            ViewBag.Date = order.Date.ToShamsi();

            List<ShowOrderViewModel> list = new List<ShowOrderViewModel>();
            List<TblClientProductRel> listShop = _clientProductRel.SelectAllClientProductRels().Where(i => i.OrderId == id).ToList();
            foreach (var item in listShop)
            {
                var product = _products.SelectAllProducts().Where(p => p.id == item.ProductId).Select(p => new
                {
                    p.TblProductImageRel.SingleOrDefault().TblImage.Image,
                    p.Name,
                    p.Price,
                    p.TblCatagory,
                    p.Discount,
                }).Single();
                list.Add(new ShowOrderViewModel()
                {
                    Count = item.Count,
                    ProductID = item.ProductId,
                    Price = product.Price,
                    ImageName = product.Image,
                    Title = product.Name,
                    Sum = product.Discount == 0 ? item.Count * product.Price : (product.Price - (long)(Math.Floor((double)product.Price * product.Discount / 100))) * item.Count,
                    CategoryName = product.TblCatagory.Name,
                    Discount = product.Discount
                });
            }

            return View(list);
        }

    }
}