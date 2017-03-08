using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStormMvc.Identity_Management
{
    public class ADGroupAuthorize : AuthorizeAttribute
    {
        private readonly bool _authorize;


        public ADGroupAuthorize()
        {
            _authorize = true;
        }

        public ADGroupAuthorize(bool authorize)
        {
            _authorize = authorize;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.Cookies["User"].Values["Group"].Equals("Buyer"))
                return false;

            return base.AuthorizeCore(httpContext);
        }
    }
}