using Bydoc.Areas.Admin.Models.DTO;
using Bydoc.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Bydoc.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin/Login
        private BydocDBContext db = new BydocDBContext();

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.AdminUsers.Any(x => x.EMail == model.Email && x.Password == model.Password && x.IsDeleted == false))
                {

                    FormsAuthentication.SetAuthCookie(model.Email, true); //mail adresini cookiede tut sag ustte goster
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return View();
                }
            }
            else
                return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}

//web.config içine form auth oldugu bildiriliyor.