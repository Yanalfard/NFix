using DataLayer.Services.Impl;
using DataLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeShopCartController : Controller
    {
        private ProductService _products = new ProductService();
        private UserPassService _users=new UserPassService();
        private ClientService _client=new ClientService();
        //private IOrdersRepository _orders;
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

        public ActionResult Index()
        {
            return View();
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
                        p.Price
                    }).Single();
                    list.Add(new ShowOrderViewModel()
                    {
                        Count = item.Count,
                        ProductID = item.ProductID,
                        Price = product.Price,
                        ImageName = product.Image,
                        Title = product.Name,
                        Sum = item.Count * product.Price
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

        //[Authorize]
        //[HttpPost]
        //public ActionResult Payment(string Discount, string DiscountId, string PriceSum)
        //{
        //    try
        //    {
        //        int userId = _users.SelectAllUserPasss().Single(u => u.Username == User.Identity.Name).id;
        //        int sumPrice = Convert.ToInt32(PriceSum);
        //        int Dis;
        //        Dis = Convert.ToInt32(DiscountId);
        //        Orders order = new Orders();
        //        if (DiscountId != "0")
        //        {
        //            order.UserID = userId;
        //            order.Date = DateTime.Now;
        //            order.IsFinaly = false;
        //            order.Sum = sumPrice;
        //            order.DiscountId = Dis;
        //        }
        //        else
        //        {
        //            order.UserID = userId;
        //            order.Date = DateTime.Now;
        //            order.IsFinaly = false;
        //            order.Sum = sumPrice;
        //        }
        //        _orders.InsertOrder(order);
        //        var listDetails = getListOrder();
        //        foreach (var item in listDetails)
        //        {
        //            _orderDetails.InsertOrderDetail(new OrderDetails()
        //            {
        //                Count = item.Count,
        //                OrderID = order.OrderID,
        //                Price = item.Price,
        //                ProductID = item.ProductID,
        //            });
        //        }

        //        if (DiscountId != "0")
        //        {
        //            int disId = Convert.ToInt32(DiscountId);
        //            Discount discountToUpdate = _discount.GetDiscountById(disId);
        //            discountToUpdate.Count--;
        //            _discount.Save();
        //        }
        //        System.Net.ServicePointManager.Expect100Continue = false;
        //        Zarin.PaymentGatewayImplementationServicePortTypeClient zp = new Zarin.PaymentGatewayImplementationServicePortTypeClient();
        //        string Authority;

        //        int Status = zp.PaymentRequest("5f648351-94a0-4b6d-ab96-3eef0d58a8b5", sumPrice, "نیو خرید ", "info@newkharid.com", "09339634557", ConfigurationManager.AppSettings["MyDomain"] + "/ShopCart/Verify/" + order.OrderID, out Authority);
        //        if (Status == 100)
        //        {
        //            Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);

        //            ////test
        //            //return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + Authority);
        //        }
        //        else
        //        {
        //            ViewBag.Error = "Error : " + Status;
        //            return RedirectToAction("Verify");

        //        }
        //        //TODO : Online Payment
        //        return null;
        //    }
        //    catch
        //    {
        //        return RedirectToAction("/ErrorPage/NotFound");
        //    }
        //}

        //public ActionResult Verify(int id)
        //{
        //    try
        //    {

        //        Orders order = _orders.GetOrdersById(id);
        //        if (Request.QueryString["Status"] != "" && Request.QueryString["Status"] != null && Request.QueryString["Authority"] != "" && Request.QueryString["Authority"] != null)
        //        {
        //            if (Request.QueryString["Status"].ToString().Equals("OK"))
        //            {
        //                int Amount = order.Sum;
        //                long RefID;
        //                System.Net.ServicePointManager.Expect100Continue = false;
        //                Zarin.PaymentGatewayImplementationServicePortTypeClient zp = new Zarin.PaymentGatewayImplementationServicePortTypeClient();

        //                int Status = zp.PaymentVerification("a282a431-19d8-43ee-ae50-e3d056519667", Request.QueryString["Authority"].ToString(), Amount, out RefID);
        //                if (Status == 100)
        //                {
        //                    order.IsFinaly = true;
        //                    ViewBag.IsSuccess = true;
        //                    ViewBag.RefId = RefID;
        //                    _orders.Save();
        //                    // Response.Write("Success!! RefId: " + RefID);
        //                    List<ShopCartItem> cart = Session["ShopCart"] as List<ShopCartItem>;
        //                    cart.Clear();
        //                    return Redirect("/UserPanel/Home/FactorView/" + id + "?FinalFactor=" + RefID);
        //                }
        //                else
        //                {
        //                    ViewBag.Status = Status;
        //                }
        //            }
        //            else
        //            {
        //                Response.Write("Error! Authority: " + Request.QueryString["Authority"].ToString() + " Status: " + Request.QueryString["Status"].ToString());
        //            }
        //        }
        //        else
        //        {
        //            Response.Write("Invalid Input");
        //        }
        //        return View();
        //    }
        //    catch
        //    {
        //        return RedirectToAction("/ErrorPage/NotFound");
        //    }

        //}
    }
}