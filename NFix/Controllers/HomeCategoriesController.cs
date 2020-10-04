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
    public class HomeCategoriesController : Controller
    {
        private CatagoryService _catagory;
        public HomeCategoriesController()
        {
            _catagory = new CatagoryService();
        }
        // GET: HomeCategories
        public ActionResult CategoriesPage()
        {
            var AllCategori = _catagory.SelectAllCatagorys();
            List<DtoTblCatagory> result = MethodRepo.ConvertToDto<TblCatagory, DtoTblCatagory>(AllCategori);
            return PartialView(result);
        }
        public ActionResult CategoryView(int id)
        {
            TblCatagory selectCategoryById = _catagory.SelectCatagoryById(id);
            DtoTblCatagory result = new DtoTblCatagory()
            {
                id = selectCategoryById.id,
                Name = selectCategoryById.Name,
                CatagoryId = selectCategoryById.CatagoryId,
            };
            return View();
        }
    }
}