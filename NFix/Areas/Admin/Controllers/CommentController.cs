using DataLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFix.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        private ClientService _client = new ClientService();
        private CommentService _comment = new CommentService();
        // GET: Admin/Comment
        public ActionResult ViewClientInfo(int id)
        {
            var c = _client.SelectClientById(id);
            return PartialView(_client.SelectClientById(id));
        }

        public ActionResult DeleteComment(int id)
        {
            _comment.DeleteComment(id);
            return JavaScript("");
        }
    }
}