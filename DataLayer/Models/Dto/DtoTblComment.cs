using System.Net;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;

namespace DataLayer.Models.Dto
{
    public class DtoTblComment : TblComment
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public TblClient Client { get; set; }
        public DtoTblComment(TblComment comment)
        {
            id = comment.id;
            ClientId = comment.ClientId;
            Body = comment.Body;
            DateSubmited = comment.DateSubmited;
            IsValid = comment.IsValid;
            Client = new ClientService().SelectClientById(id);

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblComment(TblComment comment, HttpStatusCode statusEffect, string errorStr)
        {
            id = comment.id;
            ClientId = comment.ClientId;
            Body = comment.Body;
            DateSubmited = comment.DateSubmited;
            IsValid = comment.IsValid;
            Client = new ClientService().SelectClientById(id);

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblComment()
        {
        }
    }
}