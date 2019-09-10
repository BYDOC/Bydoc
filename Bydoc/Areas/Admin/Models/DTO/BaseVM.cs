using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bydoc.Areas.Admin.Models.DTO
{
    public class BaseVM
    {
        //projede cok fazla View Model olacagı için BASEVM olusturduk.
        public int ID { get; set; }

        public bool? IsDeleted { get; set; }

    }
}