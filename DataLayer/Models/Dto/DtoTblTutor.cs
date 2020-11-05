using System.Net;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;

namespace DataLayer.Models.Dto
{
    public class DtoTblTutor : Metadata.MdTutor
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public Metadata.MdUserPass UserPass { get; set; }


        public DtoTblTutor(Metadata.MdTutor tutor)
        {
            id = tutor.id;
            Name = tutor.Name;
            IdentificationNo = tutor.IdentificationNo;
            TellNo = tutor.TellNo;
            MainImage = tutor.MainImage;
            Description = tutor.Description;
            UserPassId = tutor.UserPassId;
            UserPass = new UserPassService().SelectUserPassById(id);

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblTutor(Metadata.MdTutor tutor, HttpStatusCode statusEffect, string errorStr)
        {
            id = tutor.id;
            Name = tutor.Name;
            IdentificationNo = tutor.IdentificationNo;
            TellNo = tutor.TellNo;
            MainImage = tutor.MainImage;
            Description = tutor.Description;
            UserPassId = tutor.UserPassId;
            UserPass = new UserPassService().SelectUserPassById(id);

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblTutor()
        {
        }
    }
}