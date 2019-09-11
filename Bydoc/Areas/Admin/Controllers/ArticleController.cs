using Bydoc.Areas.Admin.Models.DTO;
using Bydoc.Areas.Admin.Models.Services.HTMLDataSourceServices;
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
    }
}