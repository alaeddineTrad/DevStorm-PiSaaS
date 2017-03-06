using DevStormMvc.Identity_Management;
using DevStormMvc.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
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
        AccountServices acs ;
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

            acs = new AccountServices(username);
            UserPrincipal u = acs.ShowUser();
            ADUserModel um = new ADUserModel();
            um.firstname = u.Name;
            um.email = u.EmailAddress;
            
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