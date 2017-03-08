using DevStormMvc.App_Start;
using DevStormMvc.Identity_Management;
using DevStormMvc.Identity_Management.Login;
using DevStormMvc.Models;
using Domain.Entities;
using Microsoft.Owin.Security;
using ServicesSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace DevStormMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public virtual ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // usually this will be injected via DI. but creating this manually now for brevity
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            var authService = new AdAuthenticationService(authenticationManager);

            var authenticationResult = authService.SignIn(model.Username, model.Password);

            if (authenticationResult.IsSuccess)
            {
                // we are in!

                // Create User Cookie 
                // Add Id on the User Cookie
                HttpCookie userCookie = new HttpCookie("User");
                ServiceUser serviceUser = new ServiceUser();
                IEnumerable<User> users = serviceUser.GetMany(x => x.UserName.Equals(model.Username));
                userCookie.Values["Id"] = Convert.ToString(users.First().UserId);
                Response.Cookies.Add(userCookie);
                //ViewData["UserId"] = userCookie;

                // Add Username on the User Cookie
                userCookie.Values["Username"] = model.Username;
                Response.Cookies.Add(userCookie);

                // Add Group on the User Cookie
                AccountServices acs = new AccountServices(model.Username);
                string group = acs.getUserGroup(model.Username);
                if (model.Username == "talaa" | model.Username == "lmajd")
                    userCookie.Values["Group"] = "Showroomer";
                else
                    userCookie.Values["Group"] = group;


                // Add Origanizational Unit on the User Cookie
                string ou = acs.GetOrganisationUnit(model.Username).Trim();
                userCookie.Values["OU"] = ou;
                //Redirection
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", authenticationResult.ErrorMessage);
            return View(model);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }


        [ValidateAntiForgeryToken]
        public virtual ActionResult Logoff()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(MyAuthentication.ApplicationCookie);

            return RedirectToAction("Index");
        }
    }
}