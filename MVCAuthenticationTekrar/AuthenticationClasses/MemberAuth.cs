using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthenticationTekrar.AuthenticationClasses
{
    public class MemberAuth:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["member"] != null)
            {
                return true;
            }
            httpContext.Response.Redirect("/Home/Login");
            return false;

        }
    }
}