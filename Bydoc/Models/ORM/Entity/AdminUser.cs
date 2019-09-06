using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bydoc.Models.ORM.Entity
{
    public class AdminUser:BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [Required,StringLength(50)]
        public string EMail { get; set; }
        [Required,StringLength(15)]
        public string Password { get; set; }
    }
}