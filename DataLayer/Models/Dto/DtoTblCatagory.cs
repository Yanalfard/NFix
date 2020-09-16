using System.Net;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;

namespace DataLayer.Models.Dto
{
    public class DtoTblCatagory : TblCatagory
    {
        public HttpStatusCode StatusEffect { get; set; }
        public string ErrorStr { get; set; }
        public TblCatagory Catagory { get; set; }

        public DtoTblCatagory(TblCatagory catagory)
        {
            id = catagory.id;
            Name = catagory.Name;
            CatagoryId = catagory.CatagoryId;
            Catagory = new CatagoryService().SelectCatagoryById(id);

            StatusEffect = HttpStatusCode.OK;
        }

        public DtoTblCatagory(TblCatagory catagory, HttpStatusCode statusEffect, string errorStr)
        {
            id = catagory.id;
            Name = catagory.Name;
            CatagoryId = catagory.CatagoryId;
            Catagory = new CatagoryService().SelectCatagoryById(id);

            StatusEffect = statusEffect;
            ErrorStr = errorStr;
        }

        public DtoTblCatagory()
        {
        }
    }
}