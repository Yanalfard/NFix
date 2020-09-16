using System.Collections.Generic;
using System.Net;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.Utilities;

namespace DataLayer.Models.Dto
{
    public class DtoTblProduct : TblProduct
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public List<DtoTblComment> Comments { get; set; }
        public List<DtoTblImage> Images { get; set; }
        public List<DtoTblKeyword> Keywords { get; set; }
        public List<DtoTblProperty> Propertys { get; set; }
        public TblCatagory Catagory { get; set; }

        public DtoTblProduct(TblProduct product)
        {
            id = product.id;
            Name = product.Name;
            DateSubmited = product.DateSubmited;
            Raiting = product.Raiting;
            Price = product.Price;
            DescriptionHtml = product.DescriptionHtml;
            CatagoryId = product.CatagoryId;
            Count = product.Count;
            IsSuggested = product.IsSuggested;
            Discount = product.Discount;
            Status = product.Status;
            Comments = MethodRepo.ConvertToDto<TblComment, DtoTblComment>(new ProductService().SelectCommentsByProductId(id));
            Images = MethodRepo.ConvertToDto<TblImage, DtoTblImage>(new ProductService().SelectImagesByProductId(id));
            Keywords = MethodRepo.ConvertToDto<TblKeyword, DtoTblKeyword>(new ProductService().SelectKeywordsByProductId(id));
            Propertys = MethodRepo.ConvertToDto<TblProperty, DtoTblProperty>(new ProductService().SelectPropertysByProductId(id));
            Catagory = new CatagoryService().SelectCatagoryById(id);

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblProduct(TblProduct product, HttpStatusCode statusEffect, string errorStr)
        {
            id = product.id;
            Name = product.Name;
            DateSubmited = product.DateSubmited;
            Raiting = product.Raiting;
            Price = product.Price;
            DescriptionHtml = product.DescriptionHtml;
            CatagoryId = product.CatagoryId;
            Count = product.Count;
            IsSuggested = product.IsSuggested;
            Discount = product.Discount;
            Status = product.Status;
            Comments = MethodRepo.ConvertToDto<TblComment, DtoTblComment>(new ProductService().SelectCommentsByProductId(id));
            Images = MethodRepo.ConvertToDto<TblImage, DtoTblImage>(new ProductService().SelectImagesByProductId(id));
            Keywords = MethodRepo.ConvertToDto<TblKeyword, DtoTblKeyword>(new ProductService().SelectKeywordsByProductId(id));
            Propertys = MethodRepo.ConvertToDto<TblProperty, DtoTblProperty>(new ProductService().SelectPropertysByProductId(id));
            Catagory = new CatagoryService().SelectCatagoryById(id);

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblProduct()
        {
        }
    }
}