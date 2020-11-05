using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using DataLayer.Utilities;

namespace DataLayer.Models.Dto
{
    public class DtoTblClient
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public List<DtoTblProduct> Products { get; set; }
        public Metadata.MdUserPass UserPass { get; set; }

        public int id { get; set; }
        [Display(Name = "نام")]
        [MinLength(4,ErrorMessage ="تعداد کاراکتر کم است")]
        public string Name { get; set; }
        [Display(Name="کد ملی")]
        public string IdentificationNo { get; set; }
        [Display(Name="شماره تلفن")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.PhoneNumber)]
        public string TellNo { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage ="ایمیل وارد شده صحیح نیست")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name="مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }
        public string PostalCode { get; set; }
        [Display(Name = "نام کاربری ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        public string UserName { get; set; }
        [Display(Name = "کد واژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار کد واژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(4, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }
        public int UserPassId { get; set; }
        public int Status { get; set; }
        public bool IsPremium { get; set; }
        public string PremiumTill { get; set; }
        public string InviteCode { get; set; }
        public DtoTblClient(Metadata.MdClient client)
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
            Products = MethodRepo.ConvertToDto<Metadata.MdProduct, DtoTblProduct>(new ClientService().SelectProductsByClientId(id));
            UserPass = new UserPassService().SelectUserPassById(id);

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblClient(Metadata.MdClient client, HttpStatusCode statusEffect, string errorStr)
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
            Products = MethodRepo.ConvertToDto<Metadata.MdProduct, DtoTblProduct>(new ClientService().SelectProductsByClientId(id));
            UserPass = new UserPassService().SelectUserPassById(id);

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblClient()
        {
        }
    }
}