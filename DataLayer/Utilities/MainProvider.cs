using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using DataLayer.Models.Regular;

namespace DataLayer.Utilities
{
    public class MainProvider
    {
        private NFixEntities Heart;
        public MainProvider()
        {
            Heart = new NFixEntities();
        }

        public enum BlogCommentRel
        {
            BlogId,
            CommentId
        }

        public enum BlogKeywordRel
        {
            BlogId,
            KeywordId
        }

        public enum ClientProductRel
        {
            ClientId,
            ProductId,
            Date,
            Count
        }

        public enum ProductCommentRel
        {
            ProductId,
            CommentId
        }

        public enum ProductImageRel
        {
            ProductId,
            ImageId
        }

        public enum ProductKeywordRel
        {
            ProductId,
            KeywordId
        }

        public enum ProductPropertyRel
        {
            ProductId,
            PropertyId
        }

        public enum DealPropertyRel
        {
            DealId,
            PropertyId
        }

        public enum TuotorVideoRel
        {
            ToutorId,
            VideoId
        }

        public object Add<T>(T table)
        {
            try
            {
                object tableObj = table;
                if (table.GetType() == typeof(TblAd))
                {
                    Heart.TblAd.Add((TblAd)tableObj);
                }
                else if (table.GetType() == typeof(TblBlog))
                {
                    Heart.TblBlog.Add((TblBlog)tableObj);
                }
                else if (table.GetType() == typeof(TblBlogCommentRel))
                {
                    Heart.TblBlogCommentRel.Add((TblBlogCommentRel)tableObj);
                }
                else if (table.GetType() == typeof(TblBlogKeywordRel))
                {
                    Heart.TblBlogKeywordRel.Add((TblBlogKeywordRel)tableObj);
                }
                else if (table.GetType() == typeof(TblCatagory))
                {
                    Heart.TblCatagory.Add((TblCatagory)tableObj);
                }
                else if (table.GetType() == typeof(TblClientProductRel))
                {
                    Heart.TblClientProductRel.Add((TblClientProductRel)tableObj);
                }
                else if (table.GetType() == typeof(TblComment))
                {
                    Heart.TblComment.Add((TblComment)tableObj);
                }
                else if (table.GetType() == typeof(TblImage))
                {
                    Heart.TblImage.Add((TblImage)tableObj);
                }
                else if (table.GetType() == typeof(TblKeyword))
                {
                    Heart.TblKeyword.Add((TblKeyword)tableObj);
                }
                else if (table.GetType() == typeof(TblProduct))
                {
                    Heart.TblProduct.Add((TblProduct)tableObj);
                }
                else if (table.GetType() == typeof(TblProductCommentRel))
                {
                    Heart.TblProductCommentRel.Add((TblProductCommentRel)tableObj);
                }
                else if (table.GetType() == typeof(TblProductImageRel))
                {
                    Heart.TblProductImageRel.Add((TblProductImageRel)tableObj);
                }
                else if (table.GetType() == typeof(TblProductPropertyRel))
                {
                    Heart.TblProductPropertyRel.Add((TblProductPropertyRel)tableObj);
                }
                else if (table.GetType() == typeof(TblProperty))
                {
                    Heart.TblProperty.Add((TblProperty)tableObj);
                }
                else if (table.GetType() == typeof(TblTutor))
                {
                    Heart.TblTutor.Add((TblTutor)tableObj);
                }
                else if (table.GetType() == typeof(TblVideo))
                {
                    Heart.TblVideo.Add((TblVideo)tableObj);
                }
                else if (table.GetType() == typeof(TblDeal))
                {
                    Heart.TblDeal.Add((TblDeal)tableObj);
                }
                else if (table.GetType() == typeof(TblDealPropertyRel))
                {
                    Heart.TblDealPropertyRel.Add((TblDealPropertyRel)tableObj);
                }
                else if (table.GetType() == typeof(TblUserPass))
                {
                    Heart.TblUserPass.Add((TblUserPass)tableObj);
                }
                else if (table.GetType() == typeof(TblDiscount))
                {
                    Heart.TblDiscount.Add((TblDiscount)tableObj);
                }
                else if (table.GetType() == typeof(TblClient))
                {
                    Heart.TblClient.Add((TblClient)tableObj);
                }
                else if (table.GetType() == typeof(TblTuotorVideoRel))
                {
                    Heart.TblTuotorVideoRel.Add((TblTuotorVideoRel)tableObj);
                }
                else if (table.GetType() == typeof(TblLog))
                {
                    Heart.TblLog.Add((TblLog)tableObj);
                }

                Heart.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update<T>(T table, int logId)
        {
            try
            {
                object tableObj = table;
                if (table.GetType() == typeof(TblAd))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblBlog))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblBlogCommentRel))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblBlogKeywordRel))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblCatagory))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblClientProductRel))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblComment))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblImage))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblKeyword))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblProduct))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblProductCommentRel))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblProductImageRel))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblProductKeywordRel))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblProductPropertyRel))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblProperty))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblTutor))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblVideo))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblDeal))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblDealPropertyRel))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblUserPass))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblDiscount))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblClient))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblTuotorVideoRel))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }
                else if (table.GetType() == typeof(TblLog))
                {
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId); val = (TblAd)tableObj;
                }

                Heart.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(EnumRepo.Tables tableType, int id)
        {
            try
            {
                switch (tableType)
                {
                    case EnumRepo.Tables.TblAd:
                        Heart.TblAd.Remove(new TblAd {id = id});
                        break;
                    case EnumRepo.Tables.TblBlog:
                        Heart.TblBlog.Remove(new TblBlog {id = id});
                        break;
                    case EnumRepo.Tables.TblBlogCommentRel:
                        Heart.TblBlogCommentRel.Remove(new TblBlogCommentRel {id = id});
                        break;
                    case EnumRepo.Tables.TblBlogKeywordRel:
                        Heart.TblBlogKeywordRel.Remove(new TblBlogKeywordRel {id = id});
                        break;
                    case EnumRepo.Tables.TblCatagory:
                        Heart.TblCatagory.Remove(new TblCatagory {id = id});
                        break;
                    case EnumRepo.Tables.TblClientProductRel:
                        Heart.TblClientProductRel.Remove(new TblClientProductRel {id = id});
                        break;
                    case EnumRepo.Tables.TblComment:
                        Heart.TblComment.Remove(new TblComment {id = id});
                        break;
                    case EnumRepo.Tables.TblImage:
                        Heart.TblImage.Remove(new TblImage {id = id});
                        break;
                    case EnumRepo.Tables.TblKeyword:
                        Heart.TblKeyword.Remove(new TblKeyword {id = id});
                        break;
                    case EnumRepo.Tables.TblProduct:
                        Heart.TblProduct.Remove(new TblProduct {id = id});
                        break;
                    case EnumRepo.Tables.TblProductCommentRel:
                        Heart.TblProductCommentRel.Remove(new TblProductCommentRel {id = id});
                        break;
                    case EnumRepo.Tables.TblProductImageRel:
                        Heart.TblProductImageRel.Remove(new TblProductImageRel {id = id});
                        break;
                    case EnumRepo.Tables.TblProductKeywordRel:
                        Heart.TblProductKeywordRel.Remove(new TblProductKeywordRel {id = id});
                        break;
                    case EnumRepo.Tables.TblProductPropertyRel:
                        Heart.TblProductPropertyRel.Remove(new TblProductPropertyRel {id = id});
                        break;
                    case EnumRepo.Tables.TblProperty:
                        Heart.TblProperty.Remove(new TblProperty {id = id});
                        break;
                    case EnumRepo.Tables.TblTutor:
                        Heart.TblTutor.Remove(new TblTutor {id = id});
                        break;
                    case EnumRepo.Tables.TblVideo:
                        Heart.TblVideo.Remove(new TblVideo {id = id});
                        break;
                    case EnumRepo.Tables.TblDeal:
                        Heart.TblDeal.Remove(new TblDeal {id = id});
                        break;
                    case EnumRepo.Tables.TblDealPropertyRel:
                        Heart.TblDealPropertyRel.Remove(new TblDealPropertyRel {id = id});
                        break;
                    case EnumRepo.Tables.TblUserPass:
                        Heart.TblUserPass.Remove(new TblUserPass {id = id});
                        break;
                    case EnumRepo.Tables.TblDiscount:
                        Heart.TblDiscount.Remove(new TblDiscount {id = id});
                        break;
                    case EnumRepo.Tables.TblClient:
                        Heart.TblClient.Remove(new TblClient {id = id});
                        break;
                    case EnumRepo.Tables.TblTuotorVideoRel:
                        Heart.TblTuotorVideoRel.Remove(new TblTuotorVideoRel {id = id});
                        break;
                    case EnumRepo.Tables.TblLog:
                        Heart.TblLog.Remove(new TblLog {id = id});
                        break;
                    default:
                        return false;
                }

                Heart.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable SelectAll(EnumRepo.Tables tableType)
        {
            try
            {
                switch (tableType)
                {
                    case EnumRepo.Tables.TblAd:
                        return Heart.TblAd.ToList();

                    case EnumRepo.Tables.TblBlog:
                        return Heart.TblBlog.ToList();

                    case EnumRepo.Tables.TblBlogCommentRel:
                        return Heart.TblBlogCommentRel.ToList();

                    case EnumRepo.Tables.TblBlogKeywordRel:
                        return Heart.TblBlogKeywordRel.ToList();

                    case EnumRepo.Tables.TblCatagory:
                        return Heart.TblCatagory.ToList();

                    case EnumRepo.Tables.TblClientProductRel:
                        return Heart.TblClientProductRel.ToList();

                    case EnumRepo.Tables.TblComment:
                        return Heart.TblComment.ToList();

                    case EnumRepo.Tables.TblImage:
                        return Heart.TblImage.ToList();

                    case EnumRepo.Tables.TblKeyword:
                        return Heart.TblKeyword.ToList();

                    case EnumRepo.Tables.TblProduct:
                        return Heart.TblProduct.ToList();

                    case EnumRepo.Tables.TblProductCommentRel:
                        return Heart.TblProductCommentRel.ToList();

                    case EnumRepo.Tables.TblProductImageRel:
                        return Heart.TblProductImageRel.ToList();

                    case EnumRepo.Tables.TblProductKeywordRel:
                        return Heart.TblProductKeywordRel.ToList();

                    case EnumRepo.Tables.TblProductPropertyRel:
                        return Heart.TblProductPropertyRel.ToList();

                    case EnumRepo.Tables.TblProperty:
                        return Heart.TblProperty.ToList();

                    case EnumRepo.Tables.TblTutor:
                        return Heart.TblTutor.ToList();

                    case EnumRepo.Tables.TblVideo:
                        return Heart.TblVideo.ToList();

                    case EnumRepo.Tables.TblDeal:
                        return Heart.TblDeal.ToList();

                    case EnumRepo.Tables.TblDealPropertyRel:
                        return Heart.TblDealPropertyRel.ToList();

                    case EnumRepo.Tables.TblUserPass:
                        return Heart.TblUserPass.ToList();

                    case EnumRepo.Tables.TblDiscount:
                        return Heart.TblDiscount.ToList();

                    case EnumRepo.Tables.TblClient:
                        return Heart.TblClient.ToList();

                    case EnumRepo.Tables.TblTuotorVideoRel:
                        return Heart.TblTuotorVideoRel.ToList();

                    case EnumRepo.Tables.TblLog:
                        return Heart.TblLog.ToList();

                    default:
                        return new List<bool>();
                }
            }
            catch
            {
                return new List<bool>();
            }
        }

        public object SelectById(EnumRepo.Tables table, int id)
        {
            try
            {
                if (table == EnumRepo.Tables.TblAd)
                    return Heart.TblAd.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblBlog)
                    return Heart.TblBlog.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblBlogCommentRel)
                    return Heart.TblBlogCommentRel.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblBlogKeywordRel)
                    return Heart.TblBlogKeywordRel.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblCatagory)
                    return Heart.TblCatagory.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblClientProductRel)
                    return Heart.TblClientProductRel.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblComment)
                    return Heart.TblComment.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblImage)
                    return Heart.TblImage.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblKeyword)
                    return Heart.TblKeyword.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblProduct)
                    return Heart.TblProduct.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblProductCommentRel)
                    return Heart.TblProductCommentRel.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblProductImageRel)
                    return Heart.TblProductImageRel.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblProductKeywordRel)
                    return Heart.TblProductKeywordRel.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblProductPropertyRel)
                    return Heart.TblProductPropertyRel.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblProperty)
                    return Heart.TblProperty.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblTutor)
                    return Heart.TblTutor.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblVideo)
                    return Heart.TblVideo.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblDeal)
                    return Heart.TblDeal.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblDealPropertyRel)
                    return Heart.TblDealPropertyRel.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblUserPass)
                    return Heart.TblUserPass.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblDiscount)
                    return Heart.TblDiscount.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblClient)
                    return Heart.TblClient.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblTuotorVideoRel)
                    return Heart.TblTuotorVideoRel.SingleOrDefault(i => i.id == id);
                else if (table == EnumRepo.Tables.TblLog)
                    return Heart.TblLog.SingleOrDefault(i => i.id == id);

                return null;
            }
            catch
            {
                return null;
            }
        }

        #region TblAd

        public TblAd SelectAdByImage(string image)
        {
            try
            {
                return Heart.TblAd.SingleOrDefault(i => i.Image == image);

            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region TblBlog

        #endregion

        #region TblBlogCommentRel

        public List<TblBlogCommentRel> SelectBlogCommentRel(int entry, BlogCommentRel entryType)
        {
            try
            {
                if (entryType == BlogCommentRel.BlogId)
                    return Heart.TblBlogCommentRel.Where(i => i.BlogId == entry).ToList();
                else if (entryType == BlogCommentRel.CommentId)
                    return Heart.TblBlogCommentRel.Where(i => i.CommentId == entry).ToList();
                else return null;
            }
            catch
            {
                return new List<TblBlogCommentRel>();
            }
        }

        #endregion

        #region TblBlogKeywordRel

        public List<TblBlogKeywordRel> SelectBlogKeywordRel(int entry, BlogKeywordRel entryType)
        {
            try
            {
                if (entryType == BlogKeywordRel.BlogId)
                    return Heart.TblBlogKeywordRel.Where(i => i.BlogId == entry).ToList();
                else if (entryType == BlogKeywordRel.KeywordId)
                    return Heart.TblBlogKeywordRel.Where(i => i.KeywordId == entry).ToList();
                else return null;
            }
            catch
            {
                return new List<TblBlogKeywordRel>();
            }
        }

        #endregion

        #region TblCatagory

        public TblCatagory SelectCatagoryByName(string name)
        {
            try
            {
                return Heart.TblCatagory.SingleOrDefault(i => i.Name == name);
            }
            catch
            {
                return null;
            }
        }
        public List<TblCatagory> SelectCatagoryByCatagoryId(int catagoryId)
        {
            try
            {
                return Heart.TblCatagory.Where(i => i.CatagoryId == catagoryId).ToList();
            }
            catch
            {
                return new List<TblCatagory>();
            }
        }

        #endregion

        #region TblClientProductRel

        public List<TblClientProductRel> SelectClientProductRel(int entry, ClientProductRel entryType)
        {
            try
            {
                if (entryType == ClientProductRel.ClientId)
                    return Heart.TblClientProductRel.Where(i => i.ClientId == entry).ToList();
                else if (entryType == ClientProductRel.ProductId)
                    return Heart.TblClientProductRel.Where(i => i.ProductId == entry).ToList();
                else return null;
            }
            catch
            {
                return new List<TblClientProductRel>();
            }
        }

        #endregion

        #region TblComment

        public List<TblComment> SelectCommentByClientId(int clientId)
        {
            try
            {
                return Heart.TblComment.Where(i => i.ClientId == clientId).ToList();
            }
            catch
            {
                return new List<TblComment>();
            }
        }
        public List<TblComment> SelectCommentByIsValid(bool isValid)
        {
            try
            {
                return Heart.TblComment.Where(i => i.IsValid == isValid).ToList();
            }
            catch
            {
                return new List<TblComment>();
            }
        }

        #endregion

        #region TblImage

        public TblImage SelectImageByImage(string image)
        {
            try
            {
                return Heart.TblImage.SingleOrDefault(i => i.Image == image);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region TblKeyword

        public TblKeyword SelectKeywordByName(string name)
        {
            try
            {
                return Heart.TblKeyword.SingleOrDefault(i => i.Name == name);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region TblProduct

        public TblProduct SelectProductByName(string name)
        {
            try
            {
                return Heart.TblProduct.SingleOrDefault(i => i.Name == name);
            }
            catch
            {
                return null;
            }
        }
        public List<TblProduct> SelectProductByCatagoryId(int catagoryId)
        {
            try
            {
                return Heart.TblProduct.Where(i => i.CatagoryId == catagoryId).ToList();
            }
            catch
            {
                return new List<TblProduct>();
            }
        }
        public List<TblProduct> SelectProductByIsSuggested(bool isSuggested)
        {
            try
            {
                return Heart.TblProduct.Where(i => i.IsSuggested == isSuggested).ToList();
            }
            catch
            {
                return new List<TblProduct>();
            }
        }

        #endregion

        #region TblProductCommentRel

        public List<TblProductCommentRel> SelectProductCommentRel(int entry, ProductCommentRel entryType)
        {
            try
            {
                if (entryType == ProductCommentRel.ProductId)
                    return Heart.TblProductCommentRel.Where(i => i.ProductId == entry).ToList();
                else if (entryType == ProductCommentRel.CommentId)
                    return Heart.TblProductCommentRel.Where(i => i.CommentId == entry).ToList();
                return null;
            }
            catch
            {
                return new List<TblProductCommentRel>();
            }
        }

        #endregion

        #region TblProductImageRel

        public List<TblProductImageRel> SelectProductImageRel(int entry, ProductImageRel entryType)
        {
            try
            {
                if (entryType == ProductImageRel.ProductId)
                    return Heart.TblProductImageRel.Where(i => i.ProductId == entry).ToList();
                else if (entryType == ProductImageRel.ImageId)
                    return Heart.TblProductImageRel.Where(i => i.ImageId == entry).ToList();
                return null;
            }
            catch
            {
                return new List<TblProductImageRel>();
            }
        }

        #endregion

        #region TblProductKeywordRel

        public List<TblProductKeywordRel> SelectProductKeywordRel(int entry, ProductKeywordRel entryType)
        {
            try
            {
                if (entryType == ProductKeywordRel.ProductId)
                    return Heart.TblProductKeywordRel.Where(i => i.ProductId == entry).ToList();
                else if (entryType == ProductKeywordRel.KeywordId)
                    return Heart.TblProductKeywordRel.Where(i => i.KeywordId == entry).ToList();
                return null;
            }
            catch
            {
                return new List<TblProductKeywordRel>();
            }
        }

        #endregion

        #region TblProductPropertyRel

        public List<TblProductPropertyRel> SelectProductPropertyRel(int entry, ProductPropertyRel entryType)
        {
            try
            {
                if (entryType == ProductPropertyRel.ProductId)
                    return Heart.TblProductPropertyRel.Where(i => i.ProductId == entry).ToList();
                else if (entryType == ProductPropertyRel.PropertyId)
                    return Heart.TblProductPropertyRel.Where(i => i.PropertyId == entry).ToList();
                return null;
            }
            catch
            {
                return new List<TblProductPropertyRel>();
            }
        }

        #endregion

        #region TblProperty

        public TblProperty SelectPropertyByName(string name)
        {
            try
            {
                return Heart.TblProperty.SingleOrDefault(i => i.Name == name);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region TblTutor

        public TblTutor SelectTutorByName(string name)
        {
            try
            {
                return Heart.TblTutor.SingleOrDefault(i => i.Name == name);
            }
            catch
            {
                return null;
            }
        }
        public TblTutor SelectTutorByIdentificationNo(string identificationNo)
        {
            try
            {
                return Heart.TblTutor.SingleOrDefault(i => i.IdentificationNo == identificationNo);
            }
            catch
            {
                return null;
            }
        }
        public TblTutor SelectTutorByTellNo(string tellNo)
        {
            try
            {
                return Heart.TblTutor.SingleOrDefault(i => i.TellNo == tellNo);
            }
            catch
            {
                return null;
            }
        }
        public TblTutor SelectTutorByUserPassId(int userPassId)
        {
            try
            {
                return Heart.TblTutor.SingleOrDefault(i => i.UserPassId == userPassId);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region TblVideo

        public TblVideo SelectVideoByTitle(string title)
        {
            try
            {
                return Heart.TblVideo.SingleOrDefault(i => i.Title == title);
            }
            catch
            {
                return null;
            }
        }
        public List<TblVideo> SelectVideoByIsOnline(bool isOnline)
        {
            try
            {
                return Heart.TblVideo.Where(i => i.IsOnline == isOnline).ToList();
            }
            catch
            {
                return new List<TblVideo>();
            }
        }
        public List<TblVideo> SelectVideoByIsHome(bool isHome)
        {
            try
            {
                return Heart.TblVideo.Where(i => i.IsHome == isHome).ToList();
            }
            catch
            {
                return new List<TblVideo>();
            }
        }

        #endregion

        #region TblDeal

        public TblDeal SelectDealByName(string name)
        {
            try
            {
                return Heart.TblDeal.SingleOrDefault(i => i.Name == name);
            }
            catch
            {
                return null;
            }
        }
        public List<TblDeal> SelectDealByIsValid(bool isValid)
        {
            try
            {
                return Heart.TblDeal.Where(i => i.IsValid == isValid).ToList();
            }
            catch
            {
                return new List<TblDeal>();
            }
        }

        #endregion

        #region TblDealPropertyRel

        public List<TblDealPropertyRel> SelectDealPropertyRel(int entry, DealPropertyRel entryType)
        {
            try
            {
                if (entryType == DealPropertyRel.DealId)
                    return Heart.TblDealPropertyRel.Where(i => i.DealId == entry).ToList();
                else if (entryType == DealPropertyRel.PropertyId)
                    return Heart.TblDealPropertyRel.Where(i => i.PropertyId == entry).ToList();
                return null;
            }
            catch
            {
                return new List<TblDealPropertyRel>();
            }
        }

        #endregion

        #region TblUserPass

        public TblUserPass SelectUserPassByUsername(string username)
        {
            try
            {
                return Heart.TblUserPass.SingleOrDefault(i => i.Username == username);
            }
            catch
            {
                return null;
            }
        }
        public TblUserPass SelectUserPassByUsernameAndPassword(string username, string password)
        {
            try
            {
                return Heart.TblUserPass.SingleOrDefault(i => i.Username == username && i.Password == password);
            }
            catch
            {
                return null;
            }
        }
        public TblUserPass SelectUserPassByPassword(string password)
        {
            try
            {
                return Heart.TblUserPass.SingleOrDefault(i => i.Password == password);
            }
            catch
            {
                return null;
            }
        }
        public List<TblUserPass> SelectUserPassByIsActive(bool isActive)
        {
            try
            {
                return Heart.TblUserPass.Where(i => i.IsActive == isActive).ToList();
            }
            catch
            {
                return new List<TblUserPass>();
            }
        }

        #endregion

        #region TblDiscount

        public TblDiscount SelectDiscountByName(string name)
        {
            try
            {
                return Heart.TblDiscount.SingleOrDefault(i => i.Name == name);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region TblClient

        public TblClient SelectClientByName(string name)
        {
            try
            {
                return Heart.TblClient.SingleOrDefault(i => i.Name == name);
            }
            catch
            {
                return null;
            }
        }
        public TblClient SelectClientByIdentificationNo(string identificationNo)
        {
            try
            {
                return Heart.TblClient.SingleOrDefault(i => i.IdentificationNo == identificationNo);
            }
            catch
            {
                return null;
            }
        }
        public TblClient SelectClientByTellNo(string tellNo)
        {
            try
            {
                return Heart.TblClient.SingleOrDefault(i => i.TellNo == tellNo);
            }
            catch
            {
                return null;
            }
        }
        public TblClient SelectClientByEmail(string email)
        {
            try
            {
                return Heart.TblClient.SingleOrDefault(i => i.Email == email);
            }
            catch
            {
                return null;
            }
        }
        public TblClient SelectClientByUserPassId(int userPassId)
        {
            try
            {
                return Heart.TblClient.SingleOrDefault(i => i.UserPassId == userPassId);
            }
            catch
            {
                return null;
            }
        }
        public List<TblClient> SelectClientByIsPremium(bool isPremium)
        {
            try
            {
                return Heart.TblClient.Where(i => i.IsPremium == isPremium).ToList();
            }
            catch
            {
                return new List<TblClient>();
            }
        }

        #endregion

        #region TblTuotorVideoRel

        public List<TblTuotorVideoRel> SelectTuotorVideoRel(int entry, TuotorVideoRel entryType)
        {
            try
            {
                if (entryType == TuotorVideoRel.ToutorId)
                    return Heart.TblTuotorVideoRel.Where(i => i.ToutorId == entry).ToList();
                else if (entryType == TuotorVideoRel.VideoId)
                    return Heart.TblTuotorVideoRel.Where(i => i.VideoId == entry).ToList();
                return null;
            }
            catch
            {
                return new List<TblTuotorVideoRel>();
            }
        }
        #endregion
        #region TblLog
        #endregion

    }
}
