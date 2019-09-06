using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bydoc.Areas.Admin.Models.DTO
{
    public class CategoryVM:BaseVM
    {
        //dogrudan models altındaki category classını kullanabilirdik. ekranda görünmesini istediğimiz propertyleri sececegiz

        [Required(ErrorMessage ="Pleases enter a category name")]
        [Display(Name ="Category Name")]
        public string Name { get; set; }
         
        [Display(Name ="Description")]
        public string Description { get; set; }

    }
}