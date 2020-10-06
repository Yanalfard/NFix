using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class KeywordService : IKeywordService
    {
        public bool AddKeyword(TblKeyword keyword)
        {
            return new KeywordRepo().Add(keyword);
        }
        public bool DeleteKeyword(int id)
        {
            return new KeywordRepo().Delete<TblKeyword>(id);
        }
        public bool UpdateKeyword(TblKeyword keyword, int logId)
        {
            return new KeywordRepo().Update(keyword, logId);
        }
        public List<TblKeyword> SelectAllKeywords()
        {
            return new KeywordRepo().SelectAll<TblKeyword>().Cast<TblKeyword>().ToList();
        }
        public TblKeyword SelectKeywordById(int id)
        {
            return new KeywordRepo().SelectById<TblKeyword>(id);
        }
        public TblKeyword SelectKeywordByName(string name)
        {
            return new KeywordRepo().SelectKeywordByName(name);
        }

    }
}