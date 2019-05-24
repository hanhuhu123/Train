using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2
{
    public class AuthorizFilter:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["name"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Default/Login");
            }
        }
            
    }
}