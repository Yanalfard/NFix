using System.Collections.Generic;
using DataLayer.Models.Regular;

namespace DataLayer.Repositories.Api
{
    public interface ICommentRepo
    {
        List<TblComment> SelectCommentByClientId(int clientId);
        List<TblComment> SelectCommentByIsValid(bool isValid);

    }
}