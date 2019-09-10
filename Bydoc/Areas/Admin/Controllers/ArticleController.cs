using Bydoc.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
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
            model.drpCategories = db.Categories.Select(x => new SelectListItem()
                {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();


            return View(model);
        }
    }
}