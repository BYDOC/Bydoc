using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bydoc.Areas.Admin.Models.Attributes
{
    //httpost required gibi bir attribute login için yazıyoruz

    public class LoginControl:ActionFilterAttribute 
    {

        //ilgili isme sahip attribute girildiği zaman
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Redirect("/Admin/Login/Index");
            }
        }


    }
}