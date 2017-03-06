using DevStormMvc.Identity_Management;
using DevStormMvc.Models;
using Domain.Entities;
using ServicesSpec;
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
        IServiceUser su = new ServiceUser();
        AccountServices acs = new AccountServices("alaa");
        
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
            if( !(acs.IsUserExisiting(um.username))) { 
           
                if (um.password1 == um.password2)
                {
                    u.FirstName = um.firstname;
                    u.LastName = um.lastName;
                    u.Password = um.password1;
                    u.Email = um.email;
                    u.UserName = um.username;
                    u.Phone =  um.phone;
                    u.Adress = new Domain.Entities.ComplexType.Address { City = "Tunis" ,Street="33khirdine",ZipCode=2090};
                    try
                    {                 
                        acs.CreateNewUser(u.UserName, u.Password, u.FirstName, u.LastName, u.Email, u.Phone);
                        //su.Add(u);
                        //su.Commit();
                        return RedirectToAction("Details");
                       
                    }
                    catch(Exception ex)
                    {
                         return View();
                        //return ex;

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
            if (acs.IsUserGroupMember(u.SamAccountName,"showroomer"))
            {
                um.Role = "showroomer";
            }
            else
            {
                um.Role = "User";
            }
            
            return View(um);
        }

    }
}