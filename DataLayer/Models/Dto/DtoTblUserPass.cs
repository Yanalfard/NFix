using System.Net;
using DataLayer.Models.Regular;

namespace DataLayer.Models.Dto
{
    public class DtoTblUserPass : Metadata.MdUserPass
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }

        public DtoTblUserPass(Metadata.MdUserPass userPass)
        {
            id = userPass.id;
            Username = userPass.Username;
            Password = userPass.Password;
            Auth = userPass.Auth;
            IsActive = userPass.IsActive;
            RoleId = userPass.RoleId;

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblUserPass(Metadata.MdUserPass userPass, HttpStatusCode statusEffect, string errorStr)
        {
            id = userPass.id;
            Username = userPass.Username;
            Password = userPass.Password;
            Auth = userPass.Auth;
            IsActive = userPass.IsActive;
            RoleId = userPass.RoleId;

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblUserPass()
        {
        }
    }
}