using System.Collections.Generic;
using System.Linq;
using DataLayer.Models.Regular;
using DataLayer.Repositories.Impl;
using DataLayer.Services.Api;

namespace DataLayer.Services.Impl
{
    public class CommentService : ICommentService
    {
        public TblComment AddComment(TblComment comment)
        {
            return new CommentRepo().Add(comment);
        }
        public bool DeleteComment(int id)
        {
            return new CommentRepo().Delete<TblComment>(id);
        }
        public bool UpdateComment(TblComment comment, int logId)
        {
            return new CommentRepo().Update(comment, logId);
        }
        public List<TblComment> SelectAllComments()
        {
            return new CommentRepo().SelectAll<TblComment>().Cast<TblComment>().ToList();
        }
        public TblComment SelectCommentById(int id)
        {
            return new CommentRepo().SelectById<TblComment>(id);
        }
        public List<TblComment> SelectCommentByClientId(int clientId)
        {
            return new CommentRepo().SelectCommentByClientId(clientId);
        }
        public List<TblComment> SelectCommentByIsValid(bool isValid)
        {
            return new CommentRepo().SelectCommentByIsValid(isValid);
        }

    }
}