using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace NFix.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ProductService _product = new ProductService();
        private ImageService _image = new ImageService();
        private ProductImageRelService _productImage = new ProductImageRelService();
        private KeywordService _keyword = new KeywordService();
        private ProductKeywordRelService _productKeyword = new ProductKeywordRelService();
        private CatagoryService _catagory = new CatagoryService();
        private OrderService _order = new OrderService();
        private ClientProductRelService _clientProductRel = new ClientProductRelService();
        private ClientService _client = new ClientService();
        private UserPassService _user = new UserPassService();
        // GET: Admin/Product
        #region Product

        public ActionResult ProductTable(int? id)
        {
            if (id == null)
            {
                List<TblProduct> products = _product.SelectAllProducts();
                return View(products);
            }
            return View(_product.SelectProductByCatagoryId(id.Value));
        }
        public ActionResult ChildCategory(int id)
        {
            return PartialView(_catagory.SelectCatagoryByCatagoryId(id).ToList());
        }
        public ActionResult ProductAdder()
        {
            ProductViewModel productViewModel = new ProductViewModel()
            {
                AllCatagory = _catagory.SelectAllCatagorys().Where(i => i.CatagoryId == null).ToList()

            };

            ViewBag.CatagoryMain = new SelectList(_catagory.SelectAllCatagorys().Where(i => i.CatagoryId == null), "id", "Name");
            ViewBag.CatagoryId = new SelectList(_catagory.SelectAllCatagorys().Where(i => i.CatagoryId != null), "id", "Name");
            return View(productViewModel);
        }
        [HttpPost]
        public ActionResult ProductAdder(ProductViewModel product, HttpPostedFileBase Image)
        {
            //product.Discount= product.Discount == 0 ? 1 : product.Discount;
            ViewBag.CatagoryMain = new SelectList(_catagory.SelectAllCatagorys().Where(i => i.CatagoryId == null), "id", "Name", product.CatagoryMain);
            ViewBag.CatagoryId = new SelectList(_catagory.SelectAllCatagorys().Where(i => i.CatagoryId == product.CatagoryMain), "id", "Name", product.CatagoryId);
            if (product.DescriptionHtml == "" || product.DescriptionHtml == null)
            {
                ProductViewModel productViewModel = new ProductViewModel()
                {
                    AllCatagory = _catagory.SelectAllCatagorys().Where(i => i.CatagoryId == null).ToList()

                };
                ModelState.AddModelError("DescriptionHtml", "لطفا متن را وارد کنید");
                return View(productViewModel);
            }
            if (product.CatagoryId == 0 || product.CatagoryId == null)
            {
                ProductViewModel productViewModel = new ProductViewModel()
                {
                    AllCatagory = _catagory.SelectAllCatagorys().Where(i => i.CatagoryId == null).ToList()

                };
                ModelState.AddModelError("CatagoryId", "لطفا دسته را انتخاب کنید");
                return View(productViewModel);
            }

            TblProduct addProduct = new TblProduct()
            {
                Price = product.Price,
                Name = product.Name,
                Status = 1,
                Raiting = 0,
                IsSuggested = product.IsSuggested,
                Count = product.Count,
                Discount = product.Discount,
                Description = product.Description,
                DescriptionHtml = product.DescriptionHtml,
                DateSubmited = DateTime.Now.ToShortDateString(),
                CatagoryId = product.CatagoryId

            };
            _product.AddProduct(addProduct);
            TblImage addImage = new TblImage();
            if (Image != null)
            {
                addImage.Image = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                Image.SaveAs(Server.MapPath("/Resources/Product/" + addImage.Image));
                ImageResizer img = new ImageResizer();
                img.Resize(Server.MapPath("/Resources/Product/" + addImage.Image),
                    Server.MapPath("/Resources/Product/Thumb/" + addImage.Image));

                _image.AddImage(addImage);
                TblProductImageRel tblProductImageRel = new TblProductImageRel()
                {
                    ImageId = addImage.id,
                    ProductId = addProduct.id,

                };
                bool x = _productImage.AddProductImageRel(tblProductImageRel);
            }

            string tags = product.Keywords;
            if (!string.IsNullOrEmpty(tags))
            {
                foreach (var item in tags.Split('،'))
                {
                    if (tags[tags.Length - 1] == '،')
                    {
                        tags = tags.Remove(tags.Length - 1);
                    }
                }

                List<TblKeyword> idKeywords = new List<TblKeyword>();
                string[] tag = tags.Split('،');
                foreach (string t in tag)
                {
                    TblKeyword addKeywords = new TblKeyword()
                    {
                        Name = t.Trim(),
                    };
                    _keyword.AddKeyword(addKeywords);
                    idKeywords.Add(addKeywords);

                }
                foreach (var item in idKeywords)
                {
                    _productKeyword.AddProductKeywordRel(new TblProductKeywordRel()
                    {
                        KeywordId = item.id,
                        ProductId = addProduct.id,
                    });
                }
            }
            return RedirectToAction("ProductTable");
        }
        public ActionResult ProductEdit(int id)
        {

            var selectProduct = _product.SelectProductById(id);
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.id = selectProduct.id;
            productViewModel.CatagoryId = selectProduct.CatagoryId;
            productViewModel.Count = selectProduct.Count;
            productViewModel.DateSubmited = selectProduct.DateSubmited;
            productViewModel.Discount = selectProduct.Discount;
            productViewModel.IsSuggested = selectProduct.IsSuggested;
            productViewModel.Name = selectProduct.Name;
            productViewModel.Price = selectProduct.Price;
            productViewModel.Raiting = selectProduct.Raiting;
            productViewModel.Description = selectProduct.Description;
            productViewModel.DescriptionHtml = selectProduct.DescriptionHtml;
            var catagory = _catagory.SelectCatagoryById(Convert.ToInt32(selectProduct.CatagoryId)).CatagoryId;
            productViewModel.CatagoryMain = Convert.ToInt32(catagory);
            ViewBag.CatagoryMain = new SelectList(_catagory.SelectAllCatagorys().Where(i => i.CatagoryId == null), "id", "Name", productViewModel.CatagoryMain);
            ViewBag.CatagoryId = new SelectList(_catagory.SelectAllCatagorys().Where(i => i.CatagoryId == productViewModel.CatagoryMain), "id", "Name", selectProduct.CatagoryId);
            List<TblKeyword> tblkKeyword = _product.SelectKeywordsByProductId(selectProduct.id);
            foreach (var item in tblkKeyword)
            {
                productViewModel.Keywords = productViewModel.Keywords + item.Name + "،";
            }
            return View(productViewModel);
        }
        [HttpPost]
        public ActionResult ProductEdit(ProductViewModel product, HttpPostedFileBase Image)
        {
            ViewBag.CatagoryMain = new SelectList(_catagory.SelectAllCatagorys().Where(i => i.CatagoryId == null), "id", "Name", product.CatagoryMain);
            ViewBag.CatagoryId = new SelectList(_catagory.SelectAllCatagorys().Where(i => i.CatagoryId == product.CatagoryMain), "id", "Name", product.CatagoryId);
            if (product.DescriptionHtml == "" || product.DescriptionHtml == null)
            {
                ProductViewModel productViewModel = new ProductViewModel()
                {
                    AllCatagory = _catagory.SelectAllCatagorys().Where(i => i.CatagoryId == null).ToList()

                };
                ModelState.AddModelError("DescriptionHtml", "لطفا متن را وارد کنید");
                return View(productViewModel);
            }
            if (product.CatagoryId == 0 || product.CatagoryId == null)
            {
                ProductViewModel productViewModel = new ProductViewModel()
                {
                    AllCatagory = _catagory.SelectAllCatagorys().Where(i => i.CatagoryId == null).ToList()

                };
                ModelState.AddModelError("CatagoryId", "لطفا دسته را انتخاب کنید");
                return View(productViewModel);
            }

            TblProduct addProduct = new TblProduct()
            {
                id = product.id,
                Price = product.Price,
                Name = product.Name,
                Status = 1,
                Raiting = 0,
                IsSuggested = product.IsSuggested,
                Count = product.Count,
                Discount = product.Discount,
                Description = product.Description,
                DescriptionHtml = product.DescriptionHtml,
                DateSubmited = DateTime.Now.ToShortDateString(),
                CatagoryId = product.CatagoryId

            };
            _product.UpdateProduct(addProduct, product.id);

            TblImage addImage = new TblImage();
            if (Image != null)
            {
                List<TblProductImageRel> TblImage = _productImage.SelectProductImageRelByProductId(product.id);
                foreach (var j in TblImage)
                {
                    string fullPathLogo = Request.MapPath("/Resources/Product/" + j.TblImage.Image);
                    if (System.IO.File.Exists(fullPathLogo))
                    {
                        System.IO.File.Delete(fullPathLogo);
                    }
                    string fullPathLogo2 = Request.MapPath("/Resources/Product/Thumb/" + j.TblImage.Image);
                    if (System.IO.File.Exists(fullPathLogo2))
                    {
                        System.IO.File.Delete(fullPathLogo2);
                    }
                    bool h = _image.DeleteImage(j.ImageId);
                }
                addImage.Image = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                Image.SaveAs(Server.MapPath("/Resources/Product/" + addImage.Image));
                ImageResizer img = new ImageResizer();
                img.Resize(Server.MapPath("/Resources/Product/" + addImage.Image),
                    Server.MapPath("/Resources/Product/Thumb/" + addImage.Image));
                _image.AddImage(addImage);
                TblProductImageRel tblProductImageRel = new TblProductImageRel()
                {
                    ImageId = addImage.id,
                    ProductId = addProduct.id,
                };
                _productImage.AddProductImageRel(tblProductImageRel);
            }
            List<TblProductKeywordRel> TblKeywords = _productKeyword.SelectProductKeywordRelByProductId(product.id);
            foreach (var item in TblKeywords)
            {
                _keyword.DeleteKeyword(item.KeywordId);
            }
            string tags = product.Keywords;
            if (!string.IsNullOrEmpty(tags))
            {
                foreach (var item in tags.Split('،'))
                {
                    if (tags[tags.Length - 1] == '،')
                    {
                        tags = tags.Remove(tags.Length - 1);
                    }
                }
                List<TblKeyword> idKeywords = new List<TblKeyword>();
                string[] tag = tags.Split('،');
                foreach (string t in tag)
                {
                    TblKeyword addKeywords = new TblKeyword()
                    {
                        Name = t.Trim(),
                    };
                    _keyword.AddKeyword(addKeywords);
                    idKeywords.Add(addKeywords);

                }
                foreach (var item in idKeywords)
                {
                    _productKeyword.AddProductKeywordRel(new TblProductKeywordRel()
                    {
                        KeywordId = item.id,
                        ProductId = addProduct.id,
                    });
                }
            }
            return RedirectToAction("ProductTable");
        }
        public ActionResult OrderTable()
        {
            //List<TblOrder> selectOrder = _order.SelectAllOrders().OrderByDescending(i => i.Date).ToList();
            //List<OrderViewModel> ordere = new List<OrderViewModel>();
            //List<TblClientProductRel> allOrders = _clientProductRel.SelectAllClientProductRels();
            //foreach (var item in selectOrder)
            //{
            //    //  TblClient client = allOrders.SingleOrDefault(i => i.OrderId == item.id).TblClient;
            //    TblClientProductRel clientProductRe = _clientProductRel.SelectAllClientProductRels().Where(i => i.OrderId == item.id).First();
            //    TblClient client = _client.SelectClientById(clientProductRe.ClientId);
            //    OrderViewModel orderViewModel = new OrderViewModel();
            //    orderViewModel.Date = item.Date;
            //    orderViewModel.DiscountId = item.DiscountId;
            //    orderViewModel.IsFInaly = item.IsFInaly;
            //    orderViewModel.Sum = item.Sum;
            //    orderViewModel.id = item.id;
            //    orderViewModel.Usernmae = client.TblUserPass.Username;
            //    orderViewModel.TellClient = client.TellNo;
            //    ordere.Add(orderViewModel);
            //}
            return View(_order.SelectAllOrders().OrderByDescending(i => i.Date).ToList());
        }
        public string ListCategory(int id)
        {
            List<TblCatagory> searchIdCatagory = _catagory.SelectCatagoryByCatagoryId(id).ToList();
            //return View(_catagory.SelectCatagoryByCatagoryId(id).ToList());
            return JsonConvert.SerializeObject(searchIdCatagory, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            //return Json(new { success = true, responseText = _catagory.SelectCatagoryByCatagoryId(id).ToList() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult deleteProduct(int id)
        {
            var getBlogId = _product.SelectImagesByProductId(id);
            if (getBlogId.Count() !=0)
            {
                string fullPathLogo = Request.MapPath("/Resources/Product/" + getBlogId.FirstOrDefault().Image);
                if (System.IO.File.Exists(fullPathLogo))
                {
                    System.IO.File.Delete(fullPathLogo);
                }
                string fullPathLogo2 = Request.MapPath("/Resources/Product/Thumb/" + getBlogId.FirstOrDefault().Image);
                if (System.IO.File.Exists(fullPathLogo2))
                {
                    System.IO.File.Delete(fullPathLogo2);
                }
            }

            _product.DeleteProduct(id);
            return JavaScript("");
        }
        public ActionResult FactorView(int id)
        {
            NFixEntities db = new NFixEntities();
            TblOrder order = _order.SelectOrderById(id);
            TblClientProductRel tblClientProd = _clientProductRel.SelectAllClientProductRels().Where(i => i.OrderId == order.id).FirstOrDefault();
            TblClient tblClient = _client.SelectClientById(tblClientProd.ClientId);
            TblUserPass tblUserPass = _user.SelectUserPassById(tblClient.UserPassId);
            ViewBag.FactId = id;
            ViewBag.Date = order.Date.ToShamsi();
            ViewBag.UserName = tblUserPass.Username;
            ViewBag.Tell = tblClient.TellNo;
            return View(_clientProductRel.SelectAllClientProductRels().Where(i => i.OrderId == id).ToList());
        }


        public ActionResult Discount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Discount(TblBlog blog)
        {
            return View();
        }

        #endregion

    }
}