using System.Collections.Generic;
using System.Net;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.Utilities;

namespace DataLayer.Models.Dto
{
    public class DtoTblBlog : Metadata.MdBlog
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public List<DtoTblComment> Comments { get; set; }
        public List<DtoTblKeyword> Keywords { get; set; }

        public DtoTblBlog(Metadata.MdBlog blog)
        {
            id = blog.id;
            MainImage = blog.MainImage;
            Body = blog.Body;
            LikeCount = blog.LikeCount;
            Comments = MethodRepo.ConvertToDto<Metadata.MdComment, DtoTblComment>(new BlogService().SelectCommentsByBlogId(id));
            Keywords = MethodRepo.ConvertToDto<Metadata.MdKeyword, DtoTblKeyword>(new BlogService().SelectKeywordsByBlogId(id));
            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblBlog(Metadata.MdBlog blog, HttpStatusCode statusEffect, string errorStr)
        {
            id = blog.id;
            MainImage = blog.MainImage;
            Body = blog.Body;
            LikeCount = blog.LikeCount;
            Comments = MethodRepo.ConvertToDto<Metadata.MdComment, DtoTblComment>(new BlogService().SelectCommentsByBlogId(id));
            Keywords = MethodRepo.ConvertToDto<Metadata.MdKeyword, DtoTblKeyword>(new BlogService().SelectKeywordsByBlogId(id));

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblBlog()
        {
        }
    }
}