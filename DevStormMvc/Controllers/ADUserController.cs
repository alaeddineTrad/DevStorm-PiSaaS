using DevStormMvc.Identity_Management;
using DevStormMvc.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStormMvc.Controllers
{
    public class ADUserController : Controller
    {
        // GET: ADUser
        ADCrud adc = new ADCrud();
        ADMethodsAccountManagement Admethods = new ADMethodsAccountManagement();
        // GET: AD
        public ActionResult Index()
        {
            return View();
        }

        // GET: ADUser/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: ADUser/Create
        [HttpPost]
        public ActionResult Create(ADUserModel um)
        {
            User u = new User();
            string b;
                try
                {
                  b =Admethods.GetUser(um.username).UserPrincipalName;
                }
                catch
                {
                    b = null;
                }
            if (b == null)
            {
                if (um.password1 == um.password2)
                {

                    u.FirstName = um.firstname;
                    u.LastName = um.lastName;

                    u.Password = um.password1;
                    u.Email = um.email;
                    u.UserName = um.username;
                    try
                    {
                        // TODO: Add insert logic here
                        adc.AddUser(u);
                        Admethods.EnableUserAccount(u.UserName);

                        return RedirectToAction("Details");
                        // return View();
                    }
                    catch
                    {

                        return View();
                    }
                }
            }
            return View();
        }

        // GET: ADuser/Details/username
        public ActionResult Details(string username)
        {
            
            var u= Admethods.GetUser(username);

            ADUserModel um = new ADUserModel();
            um.firstname = u.Name;
            um.email = u.EmailAddress;
            
            return View(um);
        }

    }
}