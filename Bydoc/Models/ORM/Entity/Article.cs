using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bydoc.Models.ORM.Entity
{
    public class Article:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }


        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}