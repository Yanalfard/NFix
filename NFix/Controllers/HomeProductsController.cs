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
    public class HomeProductsController : Controller
    {
        private ProductService _product;
        public HomeProductsController()
        {
            _product = new ProductService();
        }
        // GET: HomeProducts
        public ActionResult ProductsPage()
        {
            var allProducts = _product.SelectAllProducts();
            //List<DtoTblProduct> result = MethodRepo.ConvertToDto<TblProduct, DtoTblProduct>(allProducts);
            return PartialView(allProducts);
        }
        public ActionResult ProductView(int id)
        {
            TblProduct selectVideoById = _product.SelectProductById(id);
            DtoTblProduct result = new DtoTblProduct()
            {
                id = selectVideoById.id,
                Name = selectVideoById.Name,
                DateSubmited = selectVideoById.DateSubmited,
                Raiting = selectVideoById.Raiting,
                Price = selectVideoById.Price,
                DescriptionHtml = selectVideoById.DescriptionHtml,
                CatagoryId = selectVideoById.CatagoryId,
                Count = selectVideoById.Count,
                IsSuggested = selectVideoById.IsSuggested,
                Discount = selectVideoById.Discount,
                Status = selectVideoById.Status,
            };
            return View(result);
        }

        public ActionResult ModalProduct(int id)
        {
            TblProduct selectVideoById = _product.SelectProductById(id);
            return PartialView(selectVideoById);
        }
    }
}