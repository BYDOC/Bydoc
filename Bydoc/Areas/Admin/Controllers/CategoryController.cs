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
            List<CategoryVM> model = db.Categories.Where(x => x.IsDeleted == false).OrderBy(x => x.DateAdded).Select(x => new CategoryVM()
            {
                Name = x.Name,
                Description = x.Description,
                ID = x.ID
            }).ToList();

            
            return View(model);
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



        public ActionResult UpdateCategory(int id)
        {
            //önce güncellenecek kategoriyi bulup ekrana yazdırıyoruz
            if (ModelState.IsValid)
            {

            }
            Category category = db.Categories.FirstOrDefault(x => x.ID == id);
            CategoryVM model = new CategoryVM();
            model.Name = category.Name;
            model.Description = category.Description;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateCategory(CategoryVM model)
        {
            //güncellenecek kategori yakalanır ve yeni verilerlee update edilir.
            if (ModelState.IsValid)
            {
                Category category = db.Categories.FirstOrDefault(x => x.ID == model.ID);
                category.Name = model.Name;
                category.Description = model.Description;

                ViewBag.submitStatus = 1;
                db.SaveChanges();
                return View();
            }
            else if (true)
            {
                ViewBag.submitStatus = 2;
                return View();
            }
            
        }






        public JsonResult DeleteCategory(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.ID == id);
            category.DeleteDate = DateTime.Now;
            category.IsDeleted = true;

            db.SaveChanges();
            return Json("");

        }
    }
}