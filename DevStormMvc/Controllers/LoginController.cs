using DevStormMvc.App_Start;
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
                HttpCookie userCookie = new HttpCookie("UserId");
                ServiceUser serviceUser = new ServiceUser();
                IEnumerable<User> users = serviceUser.GetMany(x => x.UserName.Equals(model.Username));
                userCookie.Value = Convert.ToString(users.First().UserId);
                Response.Cookies.Add(userCookie);
                ViewData["UserId"] = userCookie;
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