using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class PropertyService : IPropertyService
    {
        public TblProperty AddProperty(TblProperty property)
        {
            return new PropertyRepo().Add(property);
        }
        public bool DeleteProperty(int id)
        {
            return new PropertyRepo().Delete<TblProperty>(id);
        }
        public bool UpdateProperty(TblProperty property, int logId)
        {
            return new PropertyRepo().Update(property, logId);
        }
        public List<TblProperty> SelectAllPropertys()
        {
            return new PropertyRepo().SelectAll<TblProperty>().Cast<TblProperty>().ToList();
        }
        public TblProperty SelectPropertyById(int id)
        {
            return new PropertyRepo().SelectById<TblProperty>(id);
        }
        public TblProperty SelectPropertyByName(string name)
        {
            return new PropertyRepo().SelectPropertyByName(name);
        }

    }
}