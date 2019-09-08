using Bydoc.Areas.Admin.Models.Attributes;
using Bydoc.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bydoc.Areas.Admin.Controllers
{
    [LoginControl]
    public class BaseController : Controller
    {
        // GET: Admin/Base
        // bütün populate controllerları dbcontexe ulaşacak. ayrı ayrı yapmak yerine base controllerı dbcontexte bağlayıp bu cont miras alacagız

        public BydocDBContext db;
        public BaseController()
        {
            db = new BydocDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}