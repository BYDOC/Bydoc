using Bydoc.Areas.Admin.Models.DTO;
using Bydoc.Areas.Admin.Models.Services.HTMLDataSourceServices;
using Bydoc.Models.ORM.Context;
using Bydoc.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bydoc.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {

        public ActionResult Index()
        {
                List<ArticleVM> model = db.Articles.Where(x => x.IsDeleted == false).OrderBy(x => x.DateAdded).Select(x => new ArticleVM {
                    Title = x.Title,
                    CategoryName = x.Category.Name,
                    ID=x.ID
                    
                }).ToList();
                return View(model);
            
        }


        // GET: Admin/Article
        public ActionResult AddArticle()
        {
            ArticleVM model = new ArticleVM();

            model.drpCategories = DrpServices.getDrpCategories();


            return View(model);
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddArticle(ArticleVM model)
        {
            ArticleVM vmodel = new ArticleVM();
            vmodel.drpCategories = DrpServices.getDrpCategories();

            if (ModelState.IsValid)
            {
                Article article = new Article();
                article.CategoryID = model.CategoryID;
                article.Content = model.Content;
                article.Title = model.Title;
                

                db.Articles.Add(article);
                db.SaveChanges();

                ViewBag.submitStatus = 1;
                return View(vmodel);
            }
            else
            {
                ViewBag.submitStatus = 2;
                return View(model);
            }
        }


        public ActionResult UpdateArticle(int id)
        {
            Article article = db.Articles.FirstOrDefault(x => x.ID == id);
            ArticleVM model = new ArticleVM();

            model.CategoryID = article.CategoryID;
            model.Title = article.Title;
            model.Content = article.Content;
            model.drpCategories = DrpServices.getDrpCategories();

            return View(model);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateArticle(ArticleVM model)
        {
            model.drpCategories = DrpServices.getDrpCategories();
            if (ModelState.IsValid)
            {
                Article article = db.Articles.FirstOrDefault(x => x.ID == model.ID);
                article.CategoryID = model.CategoryID;
                article.Title = model.Title;
                article.Content = model.Content;

                db.SaveChanges();

                ViewBag.SubmitStatus = 1;
                return View(model);
            }
            else
            {
                ViewBag.SubmitStatus = 2;
                return View(model);
            }

        }

        public JsonResult DeleteArticle(int id)
        {
            Article article = db.Articles.FirstOrDefault(x => x.ID == id);
            article.DeleteDate = DateTime.Now;
            article.IsDeleted = true;
            db.SaveChanges();

            return Json("");
        }
    }
}