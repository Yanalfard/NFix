using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;

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
        
        public enum VideoCommentRel
        {
            CommentId,
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
                else if (table.GetType() == typeof(TblProductKeywordRel))
                {
                    Heart.TblProductKeywordRel.Add((TblProductKeywordRel)tableObj);
                }
                else if (table.GetType() == typeof(TblVideoCommentRel))
                {
                    Heart.TblVideoCommentRel.Add((TblVideoCommentRel)tableObj);
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
                    TblAd val = Heart.TblAd.SingleOrDefault(i => i.id == logId);
                    TblAd update = (TblAd)tableObj;
                    val.id = update.id;
                    val.Image = update.Image;
                    val.Link = update.Link;
                }
                else if (table.GetType() == typeof(TblBlog))
                {
                    TblBlog val = Heart.TblBlog.SingleOrDefault(i => i.id == logId);
                    TblBlog update = (TblBlog)tableObj;
                    val.id = update.id;
                    val.LikeCount = update.LikeCount;
                    val.MainImage = update.MainImage;
                    val.Body = update.Body;
                    val.Description = update.Description;
                    val.Title = update.Title;
                }
                else if (table.GetType() == typeof(TblBlogCommentRel))
                {
                    TblBlogCommentRel val = Heart.TblBlogCommentRel.SingleOrDefault(i => i.id == logId);
                    TblBlogCommentRel update = (TblBlogCommentRel)tableObj;
                    val.BlogId = update.BlogId;
                    val.id = update.id;
                    val.CommentId = update.CommentId;
                }
                else if (table.GetType() == typeof(TblBlogKeywordRel))
                {
                    TblBlogKeywordRel val = Heart.TblBlogKeywordRel.SingleOrDefault(i => i.id == logId);
                    TblBlogKeywordRel update = (TblBlogKeywordRel)tableObj;
                    val.id = update.id;
                    val.KeywordId = update.KeywordId;
                    val.BlogId = update.BlogId;
                }
                else if (table.GetType() == typeof(TblCatagory))
                {
                    TblCatagory val = Heart.TblCatagory.SingleOrDefault(i => i.id == logId);
                    TblCatagory update = (TblCatagory)tableObj;
                    val.id = update.id;
                    val.Name = update.Name;
                    val.CatagoryId = update.CatagoryId;
                }
                else if (table.GetType() == typeof(TblClientProductRel))
                {
                    TblClientProductRel val = Heart.TblClientProductRel.SingleOrDefault(i => i.id == logId);
                    TblClientProductRel update = (TblClientProductRel)tableObj;
                    val.ClientId = update.ClientId;
                    val.id = update.id;
                    val.Count = update.Count;
                    val.ProductId = update.ProductId;
                }
                else if (table.GetType() == typeof(TblComment))
                {
                    TblComment val = Heart.TblComment.SingleOrDefault(i => i.id == logId);
                    TblComment update = (TblComment)tableObj;
                    val.id = update.id;
                    val.IsValid = update.IsValid;
                    val.Body = update.Body;
                    val.ClientId = update.ClientId;
                    val.DateSubmited = update.DateSubmited;

                }
                else if (table.GetType() == typeof(TblImage))
                {
                    TblImage val = Heart.TblImage.SingleOrDefault(i => i.id == logId);
                    TblImage update = (TblImage)tableObj;
                    val.id = update.id;
                    val.Image = update.Image;
                }
                else if (table.GetType() == typeof(TblKeyword))
                {
                    TblKeyword val = Heart.TblKeyword.SingleOrDefault(i => i.id == logId);
                    TblKeyword update = (TblKeyword)tableObj;
                    val.Name = update.Name;
                    val.id = update.id;
                }
                else if (table.GetType() == typeof(TblProduct))
                {
                    TblProduct val = Heart.TblProduct.SingleOrDefault(i => i.id == logId);
                    TblProduct update = (TblProduct)tableObj;
                    val.CatagoryId = update.CatagoryId;
                    val.Count = update.Count;
                    val.DateSubmited = update.DateSubmited;
                    val.DescriptionHtml = update.DescriptionHtml;
                    val.Discount = update.Discount;
                    val.id = update.id;
                    val.IsSuggested = update.IsSuggested;
                    val.Name = update.Name;
                    val.Price = update.Price;
                    val.Raiting = update.Raiting;
                    val.Status = update.Status;
                }
                else if (table.GetType() == typeof(TblProductCommentRel))
                {
                    TblProductCommentRel val = Heart.TblProductCommentRel.SingleOrDefault(i => i.id == logId);
                    TblProductCommentRel update = (TblProductCommentRel)tableObj;
                    val.id = update.id;
                    val.CommentId = update.CommentId;
                    val.ProductId = update.ProductId;
                }
                else if (table.GetType() == typeof(TblProductImageRel))
                {
                    TblProductImageRel val = Heart.TblProductImageRel.SingleOrDefault(i => i.id == logId);
                    TblProductImageRel update = (TblProductImageRel)tableObj;
                    val.id = update.id;
                    val.ImageId = update.ImageId;
                    val.ProductId = update.ProductId;
                }
                else if (table.GetType() == typeof(TblProductKeywordRel))
                {
                    TblProductKeywordRel val = Heart.TblProductKeywordRel.SingleOrDefault(i => i.id == logId);
                    TblProductKeywordRel update = (TblProductKeywordRel)tableObj;
                    val.id = update.id;
                    val.KeywordId = update.ProductId;
                    val.ProductId = update.ProductId;
                }
                else if (table.GetType() == typeof(TblProductPropertyRel))
                {
                    TblProductPropertyRel val = Heart.TblProductPropertyRel.SingleOrDefault(i => i.id == logId);
                    TblProductPropertyRel update = (TblProductPropertyRel)tableObj;
                    val.id = update.id;
                    val.ProductId = update.ProductId;
                    val.PropertyId = update.PropertyId;
                }
                else if (table.GetType() == typeof(TblProperty))
                {
                    TblProperty val = Heart.TblProperty.SingleOrDefault(i => i.id == logId);
                    TblProperty update = (TblProperty)tableObj;
                    val.Name = update.Name;
                    val.Description = update.Description;
                    val.id = update.id;
                }
                else if (table.GetType() == typeof(TblTutor))
                {
                    TblTutor val = Heart.TblTutor.SingleOrDefault(i => i.id == logId);
                    TblTutor update = (TblTutor)tableObj;
                    val.IdentificationNo = update.IdentificationNo;
                    val.MainImage = update.MainImage;
                    val.Name = update.Name;
                    val.TellNo = update.TellNo;
                    val.id = update.id;
                    val.UserPassId = update.UserPassId;
                    val.Description = update.Description;
                }
                else if (table.GetType() == typeof(TblVideo))
                {
                    TblVideo val = Heart.TblVideo.SingleOrDefault(i => i.id == logId);
                    TblVideo videoUpdated = (TblVideo)tableObj;
                    val.DateSubmited = videoUpdated.DateSubmited;
                    val.Description = videoUpdated.Description;
                    val.DescriptionDemo = videoUpdated.DescriptionDemo;
                    val.id = videoUpdated.id;
                    val.IsHome = videoUpdated.IsHome;
                    val.IsOnline = videoUpdated.IsOnline;
                    val.MainImage = videoUpdated.MainImage;
                    val.Raiting = videoUpdated.Raiting;
                    val.ShareLink = videoUpdated.ShareLink;
                    val.Title = videoUpdated.Title;
                    val.VideoUrl = videoUpdated.VideoUrl;
                    val.VidioDemoUrl = videoUpdated.VidioDemoUrl;
                    val.ViewCount = videoUpdated.ViewCount;
                }
                else if (table.GetType() == typeof(TblDeal))
                {
                    TblDeal val = Heart.TblDeal.SingleOrDefault(i => i.id == logId);
                    TblDeal update = (TblDeal)tableObj;
                    val.Description = update.Description;
                    val.id = update.id;
                    val.IsValid = update.IsValid;
                    val.Length = update.Length;
                    val.Name = update.Name;
                    val.Price = update.Price;
                }
                else if (table.GetType() == typeof(TblDealPropertyRel))
                {
                    TblDealPropertyRel val = Heart.TblDealPropertyRel.SingleOrDefault(i => i.id == logId);
                    TblDealPropertyRel update = (TblDealPropertyRel)tableObj;
                    val.PropertyId = update.PropertyId;
                    val.DealId = update.DealId;
                    val.id = update.id;
                }
                else if (table.GetType() == typeof(TblUserPass))
                {
                    TblUserPass val = Heart.TblUserPass.SingleOrDefault(i => i.id == logId);
                    TblUserPass update = (TblUserPass)tableObj;
                    val.id = update.id;
                    val.Auth = update.Auth;
                    val.IsActive = update.IsActive;
                    val.Password = update.Password;
                    val.RoleId = update.RoleId;
                    val.Username = update.Username;
                }
                else if (table.GetType() == typeof(TblDiscount))
                {
                    TblDiscount val = Heart.TblDiscount.SingleOrDefault(i => i.id == logId);
                    TblDiscount update = (TblDiscount)tableObj;
                    val.id = update.id;
                    val.Count = update.Count;
                    val.Discount = update.Discount;
                    val.Name = update.Name;
                }
                else if (table.GetType() == typeof(TblClient))
                {
                    TblClient val = Heart.TblClient.SingleOrDefault(i => i.id == logId);
                    TblClient update = (TblClient)tableObj;
                    val.id = update.id;
                    val.Address = update.Address;
                    val.Email = update.Email;
                    val.IdentificationNo = update.IdentificationNo;
                    val.InviteCode = update.InviteCode;
                    val.IsPremium = update.IsPremium;
                    val.Name = update.Name;
                    val.PostalCode = update.PostalCode;
                    val.PremiumTill = update.PremiumTill;
                    val.Status = update.Status;
                    val.TellNo = update.TellNo;
                    val.UserPassId = update.UserPassId;
                }
                else if (table.GetType() == typeof(TblTuotorVideoRel))
                {
                    TblTuotorVideoRel val = Heart.TblTuotorVideoRel.SingleOrDefault(i => i.id == logId);
                    TblTuotorVideoRel update = (TblTuotorVideoRel)tableObj;
                    val.id = update.id;
                    val.ToutorId = update.ToutorId;
                    val.VideoId = update.VideoId;
                }
                else if (table.GetType() == typeof(TblLog))
                {
                    TblLog val = Heart.TblLog.SingleOrDefault(i => i.id == logId);
                    TblLog update = (TblLog)tableObj;
                    val.id = update.id;
                    val.LogText = update.LogText;
                    val.MoneyTransfered = update.MoneyTransfered;
                }
                else if (table.GetType() == typeof(TblVideoCommentRel))
                {
                    TblVideoCommentRel val = Heart.TblVideoCommentRel.SingleOrDefault(i => i.id == logId);
                    TblVideoCommentRel update = (TblVideoCommentRel)tableObj;
                    val.id = update.id;
                    val.CommentId = update.CommentId;
                    val.VideoId = update.VideoId;
                }
                else if (table.GetType() == typeof(TblOrder))
                {
                    TblOrder val = Heart.TblOrder.SingleOrDefault(i => i.id == logId);
                    TblOrder update = (TblOrder)tableObj;
                    val.id = update.id;
                    val.Date = update.Date;
                    val.DiscountId = update.DiscountId;
                    val.IsFInaly = update.IsFInaly;
                    val.Sum = update.Sum;
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
                        Heart.TblAd.Remove((TblAd)SelectById(EnumRepo.Tables.TblAd, id));
                        break;
                    case EnumRepo.Tables.TblBlog:
                        Heart.TblBlog.Remove((TblBlog)SelectById(EnumRepo.Tables.TblBlog, id));
                        break;
                    case EnumRepo.Tables.TblBlogCommentRel:
                        Heart.TblBlogCommentRel.Remove((TblBlogCommentRel)SelectById(EnumRepo.Tables.TblBlogCommentRel, id));
                        break;
                    case EnumRepo.Tables.TblBlogKeywordRel:
                        Heart.TblBlogKeywordRel.Remove((TblBlogKeywordRel)SelectById(EnumRepo.Tables.TblBlogKeywordRel, id));
                        break;
                    case EnumRepo.Tables.TblCatagory:
                        Heart.TblCatagory.Remove((TblCatagory)SelectById(EnumRepo.Tables.TblCatagory, id));
                        break;
                    case EnumRepo.Tables.TblClientProductRel:
                        Heart.TblClientProductRel.Remove((TblClientProductRel)SelectById(EnumRepo.Tables.TblClientProductRel, id));
                        break;
                    case EnumRepo.Tables.TblComment:
                        Heart.TblComment.Remove((TblComment)SelectById(EnumRepo.Tables.TblComment, id));
                        break;
                    case EnumRepo.Tables.TblImage:
                        Heart.TblImage.Remove((TblImage)SelectById(EnumRepo.Tables.TblImage, id));
                        break;
                    case EnumRepo.Tables.TblKeyword:
                        Heart.TblKeyword.Remove((TblKeyword)SelectById(EnumRepo.Tables.TblKeyword, id));
                        break;
                    case EnumRepo.Tables.TblProduct:
                        Heart.TblProduct.Remove((TblProduct)SelectById(EnumRepo.Tables.TblProduct, id));
                        break;
                    case EnumRepo.Tables.TblProductCommentRel:
                        Heart.TblProductCommentRel.Remove((TblProductCommentRel)SelectById(EnumRepo.Tables.TblProductCommentRel, id));
                        break;
                    case EnumRepo.Tables.TblProductImageRel:
                        Heart.TblProductImageRel.Remove((TblProductImageRel)SelectById(EnumRepo.Tables.TblProductImageRel, id));
                        break;
                    case EnumRepo.Tables.TblProductKeywordRel:
                        Heart.TblProductKeywordRel.Remove((TblProductKeywordRel)SelectById(EnumRepo.Tables.TblProductKeywordRel, id));
                        break;
                    case EnumRepo.Tables.TblProductPropertyRel:
                        Heart.TblProductPropertyRel.Remove((TblProductPropertyRel)SelectById(EnumRepo.Tables.TblProductPropertyRel, id));
                        break;
                    case EnumRepo.Tables.TblProperty:
                        Heart.TblProperty.Remove((TblProperty)SelectById(EnumRepo.Tables.TblProperty, id));
                        break;
                    case EnumRepo.Tables.TblTutor:
                        Heart.TblTutor.Remove((TblTutor)SelectById(EnumRepo.Tables.TblTutor, id)); ;
                        break;
                    case EnumRepo.Tables.TblVideo:
                        Heart.TblVideo.Remove((TblVideo)SelectById(EnumRepo.Tables.TblVideo, id));
                        break;
                    case EnumRepo.Tables.TblDeal:
                        Heart.TblDeal.Remove((TblDeal)SelectById(EnumRepo.Tables.TblDeal, id));
                        break;
                    case EnumRepo.Tables.TblDealPropertyRel:
                        Heart.TblDealPropertyRel.Remove((TblDealPropertyRel)SelectById(EnumRepo.Tables.TblDealPropertyRel, id));
                        break;
                    case EnumRepo.Tables.TblUserPass:
                        Heart.TblUserPass.Remove((TblUserPass)SelectById(EnumRepo.Tables.TblUserPass, id));
                        break;
                    case EnumRepo.Tables.TblDiscount:
                        Heart.TblDiscount.Remove((TblDiscount)SelectById(EnumRepo.Tables.TblDiscount, id));
                        break;
                    case EnumRepo.Tables.TblClient:
                        Heart.TblClient.Remove((TblClient)SelectById(EnumRepo.Tables.TblClient, id));
                        break;
                    case EnumRepo.Tables.TblTuotorVideoRel:
                        Heart.TblTuotorVideoRel.Remove((TblTuotorVideoRel)SelectById(EnumRepo.Tables.TblTuotorVideoRel, id));
                        break;
                    case EnumRepo.Tables.TblLog:
                        Heart.TblLog.Remove((TblLog)SelectById(EnumRepo.Tables.TblLog, id));
                        break;
                    case EnumRepo.Tables.TblVideoCommentRel:
                        Heart.TblVideoCommentRel.Remove((TblVideoCommentRel)SelectById(EnumRepo.Tables.TblVideoCommentRel, id));
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
            //try
            //{
            Heart = new NFixEntities();
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

                case EnumRepo.Tables.TblVideoCommentRel:
                    return Heart.TblVideoCommentRel.ToList();

                default:
                    return new List<bool>();
            }
            //}
            //catch(Exception e)
            //{
            //    return new List<bool>();
            //}
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
                else if (table == EnumRepo.Tables.TblVideoCommentRel)
                    return Heart.TblVideoCommentRel.SingleOrDefault(i => i.id == id);

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

        #region TblVideoCommentRel
        public List<TblVideoCommentRel> SelectVideoCommentRel(int entry, VideoCommentRel entryType)
        {
            try
            {
                if (entryType == VideoCommentRel.CommentId)
                    return Heart.TblVideoCommentRel.Where(i => i.CommentId == entry).ToList();
                else if (entryType == VideoCommentRel.VideoId)
                    return Heart.TblVideoCommentRel.Where(i => i.VideoId == entry).ToList();
                return null;
            }
            catch
            {
                return new List<TblVideoCommentRel>();
            }
        }

        #endregion
    }
}
