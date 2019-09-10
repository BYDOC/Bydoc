using Bydoc.Areas.Admin.Models.DTO;
using Bydoc.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bydoc.Areas.Admin.Controllers
{
    public class SiteMenuController : BaseController
    {
        // GET: Admin/SiteMenu
     
        
        public ActionResult AddSiteMenu()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AddSiteMenu(SiteMenuVM model)
        {
            //model.isvalid yerine jquery validation yapıyoruz

            SiteMenu sitemenu = new SiteMenu();
            sitemenu.Name = model.Name;
            sitemenu.Url = model.Url;
            sitemenu.cssClass = model.cssClass;

            db.SiteMenus.Add(sitemenu);
            db.SaveChanges();

            ViewBag.submitStatus = 1;

            return View();
        }

        public ActionResult AddSiteMenuWithJson()
        {
            return View();
        }

        public JsonResult AddSiteMenuJSON(SiteMenuVM model)
        {

            SiteMenu sitemenu = new SiteMenu();
            sitemenu.Name = model.Name;
            sitemenu.Url = model.Url;
            sitemenu.cssClass = model.cssClass;

            db.SiteMenus.Add(sitemenu);
            db.SaveChanges();

            return Json("");
        }
    }
}