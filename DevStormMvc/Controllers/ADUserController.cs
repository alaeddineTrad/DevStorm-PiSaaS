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
        AccountServices acs = new AccountServices("alaa");
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
                    u.Phone =  um.phone;
                    try
                    {
                        // TODO: Add insert logic here
                        acs.CreateNewUser(u.UserName, u.Password, u.FirstName, u.LastName, u.Email, u.Phone);
                        

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

        // GET: ADuser/Details
        public ActionResult Details()
        {

            var u = acs.ShowUser();

            ADUserLongModel um = new ADUserLongModel();
            um.username = u.Name;
            um.firstname =u.GivenName; 
            um.email = u.EmailAddress ;
            um.lastName = u.Surname;
            um.phone = u.VoiceTelephoneNumber;
            um.LastLogon =(DateTime) u.LastLogon;
            if (acs.IsUserGroupMember(u.Name,"showroomer"))
            {
                um.Role = "showroomer";
            }
            
            return View(um);
        }

    }
}