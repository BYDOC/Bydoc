using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bydoc.Areas.Admin.Models.DTO
{
    public class ArticleVM:BaseVM
    {
        public string  Title { get; set; }

        public string Content { get; set; }

        public int CategoryID { get; set; }

        public IEnumerable<SelectListItem> drpCategories { get; set; }

        
    }
}