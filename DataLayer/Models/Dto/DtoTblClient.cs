using System.Collections.Generic;
using System.Net;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.Utilities;

namespace DataLayer.Models.Dto
{
    public class DtoTblClient : TblClient
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public List<DtoTblProduct> Products { get; set; }
        public TblUserPass UserPass { get; set; }

        public DtoTblClient(TblClient client)
        {
            id = client.id;
            Name = client.Name;
            IdentificationNo = client.IdentificationNo;
            TellNo = client.TellNo;
            Email = client.Email;
            Address = client.Address;
            PostalCode = client.PostalCode;
            UserPassId = client.UserPassId;
            Status = client.Status;
            IsPremium = client.IsPremium;
            PremiumTill = client.PremiumTill;
            InviteCode = client.InviteCode;
            Products = MethodRepo.ConvertToDto<TblProduct, DtoTblProduct>(new ClientService().SelectProductsByClientId(id));
            UserPass = new UserPassService().SelectUserPassById(id);

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblClient(TblClient client, HttpStatusCode statusEffect, string errorStr)
        {
            id = client.id;
            Name = client.Name;
            IdentificationNo = client.IdentificationNo;
            TellNo = client.TellNo;
            Email = client.Email;
            Address = client.Address;
            PostalCode = client.PostalCode;
            UserPassId = client.UserPassId;
            Status = client.Status;
            IsPremium = client.IsPremium;
            PremiumTill = client.PremiumTill;
            InviteCode = client.InviteCode;
            Products = MethodRepo.ConvertToDto<TblProduct, DtoTblProduct>(new ClientService().SelectProductsByClientId(id));
            UserPass = new UserPassService().SelectUserPassById(id);

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblClient()
        {
        }
    }
}