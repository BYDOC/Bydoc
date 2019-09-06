using Bydoc.Areas.Admin.Models.Attributes;
using Bydoc.Models.ORM.Context;
using Bydoc.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bydoc.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
       [LoginControl]
        public ActionResult Index()
        {
            //db'den instance aldık. cookiedeki email ile eşleştirdik. emailden isim ve soyisim bulduk
            BydocDBContext db = new BydocDBContext();
            string email = HttpContext.User.Identity.Name;
            AdminUser adminuser = db.AdminUsers.FirstOrDefault(x => x.EMail == email);
            string name = adminuser.Name;
            string surname = adminuser.Surname;
            //////////



            return View();
        }
    }
}