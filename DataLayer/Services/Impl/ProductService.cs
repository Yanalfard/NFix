using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class ProductService : IProductService
    {
        public bool AddProduct(TblProduct product)
        {
            return new ProductRepo().Add(product);
        }
        public bool DeleteProduct(int id)
        {
            return new ProductRepo().Delete<TblProduct>(id);
        }
        public bool UpdateProduct(TblProduct product, int logId)
        {
            return new ProductRepo().Update(product, logId);
        }
        public List<TblProduct> SelectAllProducts()
        {
            return new ProductRepo().SelectAll<TblProduct>().Cast<TblProduct>().ToList();
        }
        public TblProduct SelectProductById(int id)
        {
            return new ProductRepo().SelectById<TblProduct>(id);
        }
        public TblProduct SelectProductByName(string name)
        {
            return new ProductRepo().SelectProductByName(name);
        }
        public List<TblProduct> SelectProductByCatagoryId(int catagoryId)
        {
            return new ProductRepo().SelectProductByCatagoryId(catagoryId);
        }
        public List<TblProduct> SelectProductByIsSuggested(bool isSuggested)
        {
            return new ProductRepo().SelectProductByIsSuggested(isSuggested);
        }
        public List<TblComment>SelectCommentsByProductId(int productId)
        {
            List<TblProductCommentRel> stp1 = new ProductCommentRelRepo().SelectProductCommentRelByProductId(productId);
            List<TblComment> stp2 = new List<TblComment>();
            foreach (TblProductCommentRel rel in stp1)
                stp2.Add(new CommentRepo().SelectById<TblComment>(rel.CommentId));
            return stp2;
        }
        public List<TblImage>SelectImagesByProductId(int productId)
        {
            List<TblProductImageRel> stp1 = new ProductImageRelRepo().SelectProductImageRelByProductId(productId);
            List<TblImage> stp2 = new List<TblImage>();
            foreach (TblProductImageRel rel in stp1)
                stp2.Add(new ImageRepo().SelectById<TblImage>(rel.ImageId));
            return stp2;
        }
        public List<TblKeyword>SelectKeywordsByProductId(int productId)
        {
            List<TblProductKeywordRel> stp1 = new ProductKeywordRelRepo().SelectProductKeywordRelByProductId(productId);
            List<TblKeyword> stp2 = new List<TblKeyword>();
            foreach (TblProductKeywordRel rel in stp1)
                stp2.Add(new KeywordRepo().SelectById<TblKeyword>(rel.KeywordId));
            return stp2;
        }
        public List<TblProperty>SelectPropertysByProductId(int productId)
        {
            List<TblProductPropertyRel> stp1 = new ProductPropertyRelRepo().SelectProductPropertyRelByProductId(productId);
            List<TblProperty> stp2 = new List<TblProperty>();
            foreach (TblProductPropertyRel rel in stp1)
                stp2.Add(new PropertyRepo().SelectById<TblProperty>(rel.PropertyId));
            return stp2;
        }

    }
}