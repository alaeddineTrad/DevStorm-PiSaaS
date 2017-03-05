using DevStormMvc.Data.Infrastructure;
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
    public class RateController : Controller
    {
        IServiceRate serviceRate = new ServiceRate();
        // GET: Rate
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rate/Create
        [HttpPost]
        public ActionResult Create(RateModel RM)
        {
            Rate r = new Rate

            {
                //RateId = RM.rateId,
                Mark = RM.mark


            };
            try
            {
                // TODO: Add insert logic here
                //DatabaseFactory dbf = new DatabaseFactory();
                //UnitOfWork u = new UnitOfWork(dbf);
                //u.GetRepository<Rate>().Add(r);
                //u.Commit();
                serviceRate.Add(r);
                serviceRate.Commit();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Rate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}