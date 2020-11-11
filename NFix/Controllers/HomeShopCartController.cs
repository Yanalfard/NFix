using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeShopCartController : Controller
    {
        private ProductService _products = new ProductService();
        private ClientProductRelService _clientProductRel = new ClientProductRelService();
        private UserPassService _users = new UserPassService();
        private ClientService _client = new ClientService();
        private OrderService _order = new OrderService();
        private LogService _log = new LogService();
        //private Orde _orders;
        public HomeShopCartController()
        {
        }
        // GET: ShopCart
        public ActionResult ShowCart()
        {
            try
            {
                List<ShopCartItemViewModel> list = new List<ShopCartItemViewModel>();
                if (Session["ShopCart"] != null)
                {
                    List<ShopCartItem> listShop = (List<ShopCartItem>)Session["ShopCart"];

                    foreach (var item in listShop)
                    {
                        var product = _products.SelectAllProducts().Where(p => p.id == item.ProductID).Select(p => new
                        {
                            p.TblProductImageRel.SingleOrDefault().TblImage.Image,
                            p.Name
                        }).Single();
                        list.Add(new ShopCartItemViewModel()
                        {
                            Count = item.Count,
                            ProductID = item.ProductID,
                            Title = product.Name,
                            ImageName = product.Image

                        });
                    }
                }
                return PartialView(list);
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }
        [Route("ShopCart")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Plans()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Plans(int id)
        {

            try
            {
                int SumPrice = 0;
                if (id == 1)
                {
                    SumPrice = 300000;
                }
                else if (id == 2)
                {
                    SumPrice = 1620000;
                }
                else if (id == 3)
                {
                    SumPrice = 2960000;
                }

                TblUserPass userId = _users.SelectUserPassByUsername(User.Identity.Name);
                int clientId = _client.SelectClientByUserPassId(userId.id).id;
                TblLog log = new TblLog()
                {
                    LogText = "ارسال به زرین پال",
                    Date = DateTime.Now,
                    MoneyTransfered = SumPrice,
                    ClientId = clientId,
                };
                _log.AddLog(log);

                System.Net.ServicePointManager.Expect100Continue = false;
                ZarinPalTest.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPalTest.PaymentGatewayImplementationServicePortTypeClient();
                string Authority;

                int Status = zp.PaymentRequest("5f648351-94a0-4b6d-ab96-3eef0d58a8b5", SumPrice, "NFIX ", "info@newkharid.com", "09339634557", ConfigurationManager.AppSettings["MyDomain"] + "/HomeShopCart/PlansVerify/" + log.id, out Authority);
                if (Status == 100)
                {
                    //Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);

                    ////test
                    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + Authority);
                }
                else
                {
                    ViewBag.Error = "Error : " + Status;
                    return RedirectToAction("Verify");

                }
                //TODO : Online Payment
                return null;
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }
        public ActionResult PlansVerify(int id)
        {
            try
            {
                TblLog order = _log.SelectLogById(id);
                if (Request.QueryString["Status"] != "" && Request.QueryString["Status"] != null && Request.QueryString["Authority"] != "" && Request.QueryString["Authority"] != null)
                {
                    if (Request.QueryString["Status"].ToString().Equals("OK"))
                    {
                        int Amount = (int)order.MoneyTransfered;
                        long RefID;
                        System.Net.ServicePointManager.Expect100Continue = false;
                        ZarinPalTest.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPalTest.PaymentGatewayImplementationServicePortTypeClient();

                        int Status = zp.PaymentVerification("a282a431-19d8-43ee-ae50-e3d056519667", Request.QueryString["Authority"].ToString(), Amount, out RefID);
                        if (Status == 100)
                        {
                            TblClient clientId = _client.SelectClientById(Convert.ToInt32(order.ClientId));
                            order.LogText = $" کاربر مورد نظز با مبلغ{order.MoneyTransfered} اشتراک خرید";
                            ViewBag.IsSuccess = true;
                            ViewBag.RefId = RefID;

                            TblClient tblClient = new TblClient();
                            tblClient.id = clientId.id;
                            tblClient.Name = clientId.Name;
                            tblClient.IdentificationNo = clientId.IdentificationNo;
                            tblClient.TellNo = clientId.TellNo;
                            tblClient.Email = clientId.Email;
                            tblClient.Address = clientId.Address;
                            tblClient.PostalCode = clientId.PostalCode;
                            tblClient.UserPassId = clientId.UserPassId;
                            tblClient.Status = clientId.Status;
                            tblClient.IsPremium = clientId.IsPremium;
                            tblClient.PremiumTill = clientId.PremiumTill;
                            tblClient.InviteCode = clientId.InviteCode;
                            tblClient.IsPremium = true;
                            if (DateTime.Parse(clientId.PremiumTill) > DateTime.Now)
                            {
                                DateTime date = DateTime.Parse(clientId.PremiumTill);
                                if (order.MoneyTransfered == 300000)
                                {
                                    DateTime nextMonth = date.AddDays(1).AddMonths(1).AddDays(-1);
                                    tblClient.PremiumTill = nextMonth.ToString();
                                }
                                else if (order.MoneyTransfered == 1620000)
                                {
                                    DateTime nextMonth = date.AddDays(1).AddMonths(6).AddDays(-1);
                                    tblClient.PremiumTill = nextMonth.ToString();
                                }
                                else if (order.MoneyTransfered == 2960000)
                                {
                                    DateTime nextMonth = date.AddDays(1).AddMonths(12).AddDays(-1);
                                    tblClient.PremiumTill = nextMonth.ToString();
                                }
                            }
                            else
                            {
                                DateTime date = DateTime.Now;
                                if (order.MoneyTransfered == 300000)
                                {
                                    DateTime nextMonth = date.AddDays(1).AddMonths(1).AddDays(-1);
                                    tblClient.PremiumTill = nextMonth.ToString();
                                }
                                else if (order.MoneyTransfered == 1620000)
                                {
                                    DateTime nextMonth = date.AddDays(1).AddMonths(6).AddDays(-1);
                                    tblClient.PremiumTill = nextMonth.ToString();
                                }
                                else if (order.MoneyTransfered == 2960000)
                                {
                                    DateTime nextMonth = date.AddDays(1).AddMonths(12).AddDays(-1);
                                    tblClient.PremiumTill = nextMonth.ToString();
                                }
                            }
                            _client.UpdateClient(tblClient, clientId.id);
                            _log.UpdateLog(order, order.id);
                            return Redirect("/User/Profile/Index/" + id + "?BlogFactor=" + RefID);
                        }
                        else
                        {
                            order.MoneyTransfered = 0;
                            order.LogText = $" ناموفق{order.MoneyTransfered} اشتراک خرید";
                            ViewBag.Status = Status;
                            bool x= _log.UpdateLog(order, order.id);
                        }
                    }
                    else
                    {
                        order.MoneyTransfered = 0;
                        order.LogText = $" ناموفق{order.MoneyTransfered} اشتراک خرید";
                        bool x = _log.UpdateLog(order, order.id);
                        Response.Write("Error! Authority: " + Request.QueryString["Authority"].ToString() + " Status: " + Request.QueryString["Status"].ToString());
                    }
                }
                else
                {
                    order.MoneyTransfered = 0;
                    order.LogText = $" ناموفق{order.MoneyTransfered} اشتراک خرید";
                    bool x = _log.UpdateLog(order, order.id);
                    Response.Write("Invalid Input");
                }
                return View();
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }

        }


        List<ShowOrderViewModel> getListOrder()
        {
            List<ShowOrderViewModel> list = new List<ShowOrderViewModel>();

            if (Session["ShopCart"] != null)
            {
                List<ShopCartItem> listShop = Session["ShopCart"] as List<ShopCartItem>;

                foreach (var item in listShop)
                {
                    var product = _products.SelectAllProducts().Where(p => p.id == item.ProductID).Select(p => new
                    {
                        p.TblProductImageRel.SingleOrDefault().TblImage.Image,
                        p.Name,
                        p.Price,
                        p.TblCatagory,
                        p.Discount
                    }).Single();
                    list.Add(new ShowOrderViewModel()
                    {
                        Count = item.Count,
                        ProductID = item.ProductID,
                        Price = product.Price,
                        ImageName = product.Image,
                        Title = product.Name,
                        Sum = product.Discount == 0 ? item.Count * product.Price : (product.Price - (long)(Math.Floor((double)product.Price * product.Discount / 100))) * item.Count,
                        CategoryName = product.TblCatagory.Name,
                        Discount = product.Discount
                    });
                }
            }
            return list;
        }

        public ActionResult Order()
        {
            try
            {
                return PartialView(getListOrder());
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }

        public ActionResult CommandOrder(int id, int count)
        {
            try
            {
                List<ShopCartItem> listShop = Session["ShopCart"] as List<ShopCartItem>;
                int index = listShop.FindIndex(p => p.ProductID == id);
                if (count == 0)
                {
                    listShop.RemoveAt(index);
                }
                else
                {
                    listShop[index].Count = count;
                }
                Session["ShopCart"] = listShop;

                return PartialView("Order", getListOrder());
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }

        [Authorize]
        public ActionResult Payment()
        {
            try
            {
                var listDetails = getListOrder();

                TblUserPass userId = _users.SelectUserPassByUsername(User.Identity.Name);
                int clientId = _client.SelectClientByUserPassId(userId.id).id;
                TblOrder order = new TblOrder()
                {
                    IsFInaly = false,
                    Date = DateTime.Now,
                    Sum = listDetails.Sum(i => i.Sum),
                };
                _order.AddOrder(order);

                int SumOrder = Convert.ToInt32(listDetails.Sum(i => i.Sum));

                foreach (var item in listDetails)
                {
                    _clientProductRel.AddClientProductRel(new TblClientProductRel()
                    {
                        Count = item.Count,
                        ClientId = clientId,
                        OrderId = order.id,
                        ProductId = item.ProductID,
                        Price = Convert.ToInt32(item.Price),
                        Discount = _products.SelectProductById(item.ProductID).Discount,
                    });
                }

                System.Net.ServicePointManager.Expect100Continue = false;
                ZarinPalTest.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPalTest.PaymentGatewayImplementationServicePortTypeClient();
                string Authority;

                int Status = zp.PaymentRequest("5f648351-94a0-4b6d-ab96-3eef0d58a8b5", SumOrder, "NFIX ", "info@newkharid.com", "09339634557", ConfigurationManager.AppSettings["MyDomain"] + "/HomeShopCart/Verify/" + order.id, out Authority);
                if (Status == 100)
                {
                    //Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);

                    ////test
                    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + Authority);
                }
                else
                {
                    ViewBag.Error = "Error : " + Status;
                    return RedirectToAction("Verify");

                }
                //TODO : Online Payment
                return null;
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }
        }


        public ActionResult Verify(int id)
        {
            try
            {

                TblOrder order = _order.SelectOrderById(id);
                if (Request.QueryString["Status"] != "" && Request.QueryString["Status"] != null && Request.QueryString["Authority"] != "" && Request.QueryString["Authority"] != null)
                {
                    if (Request.QueryString["Status"].ToString().Equals("OK"))
                    {
                        int Amount = (int)order.Sum;
                        long RefID;
                        System.Net.ServicePointManager.Expect100Continue = false;
                        ZarinPalTest.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPalTest.PaymentGatewayImplementationServicePortTypeClient();

                        int Status = zp.PaymentVerification("a282a431-19d8-43ee-ae50-e3d056519667", Request.QueryString["Authority"].ToString(), Amount, out RefID);
                        if (Status == 100)
                        {
                            order.IsFInaly = true;
                            ViewBag.IsSuccess = true;
                            ViewBag.RefId = RefID;
                            _order.UpdateOrder(order, order.id);
                            // Response.Write("Success!! RefId: " + RefID);
                            List<ShopCartItem> cart = Session["ShopCart"] as List<ShopCartItem>;
                            cart.Clear();
                            return Redirect("/User/Profile/FactorView/" + id + "?FinalFactor=" + RefID);
                        }
                        else
                        {
                            ViewBag.Status = Status;
                        }
                    }
                    else
                    {
                        Response.Write("Error! Authority: " + Request.QueryString["Authority"].ToString() + " Status: " + Request.QueryString["Status"].ToString());
                    }
                }
                else
                {
                    Response.Write("Invalid Input");
                }
                return View();
            }
            catch
            {
                return RedirectToAction("/ErrorPage/NotFound");
            }

        }



    }
}