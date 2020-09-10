using System.Collections.Generic;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Api;
using DataLayer.Utilities;

namespace DataLayer.Repositories.Impl
{
    public class CommentRepo : HeartRepo, ICommentRepo
    {
        private MainProvider _main;
        public CommentRepo()
        {
            _main = new MainProvider();
        }
        public List<TblComment> SelectCommentByClientId(int clientId)
        {
            return _main.SelectCommentByClientId(clientId);
        }
        public List<TblComment> SelectCommentByIsValid(bool isValid)
        {
            return _main.SelectCommentByIsValid(isValid);
        }

    }
}