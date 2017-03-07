using DevStormMvc.Identity_Management;
using DevStormMvc.Models;
using Domain.Entities;
using ServicesSpec;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace DevStormMvc.Controllers
{
    public class ADUserController : Controller
    {
        // GET: ADUser

        IServiceUser su = new ServiceUser();
        AccountServices acs = new AccountServices();
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
                    u.UserName = um.username;
                    u.Adress = new Domain.Entities.ComplexType.Address { City = um.city ,Street=um.street,ZipCode=um.zipcode};
                                    
                        
                        su.Add(u);
                        su.Commit();
                        acs.CreateNewUser(um.username, um.password1, um.firstname, um.lastName, um.email, um.phone);
                        return RedirectToAction("Details");
                       
                   
                        
                        //return ex;

                    
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

        // GET: ADUser/Edit/
        public ActionResult Edit(string username)
        {
            acs = new AccountServices(username);
            UserPrincipal user = acs.ShowUser();
            ADUserModel userModel = new ADUserModel
            {
                username = username,
                firstname = user.GivenName,
                lastName = user.Surname,
                email = user.EmailAddress
            };
            return View(userModel);

        }

        // POST: ADUser/Edit/
        [HttpPost]
        public ActionResult Edit(ADUserModel userModel)
        {
            try
            {
                acs = new AccountServices(userModel.username);
                acs.UpdateAdUser(userModel.firstname,userModel.lastName,userModel.email);
                return RedirectToAction("Details");
            }
            catch 
            {
                return View(userModel);
            }
        }

    }
}