using Bydoc.Areas.Admin.Models.DTO;
using Bydoc.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bydoc.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }


        //sayfayı çagırdıgımızda gelen design
        public ActionResult AddCategory()
        {
            return View();
        }

        //post edilince yapılacak islem
        [HttpPost]
        public ActionResult AddCategory(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Description = model.Description;

                db.Categories.Add(category);
                db.SaveChanges();

                ViewBag.submitStatus = 1;
                return View();
            }
            else
            {
                ViewBag.submitStatus = 2;
                return View();
            }
            
        }
    }
}