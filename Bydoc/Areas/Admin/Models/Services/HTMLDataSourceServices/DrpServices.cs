using Bydoc.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bydoc.Areas.Admin.Models.Services.HTMLDataSourceServices
{
    public class DrpServices
    {
        public static IEnumerable<SelectListItem> getDrpCategories()
        {
            using (BydocDBContext db =new BydocDBContext())
            {
                IEnumerable<SelectListItem> drpcategories = db.Categories.Where(x => x.IsDeleted == false).Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                }).ToList();

                return drpcategories;

            }
            

            
        } 
    }
}