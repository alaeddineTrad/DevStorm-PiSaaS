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
            List<RateModel> cr = new List<RateModel>();
            var l = serviceRate.GetAll();
            foreach (var item in l)
            {
                cr.Add(new RateModel
                {
                    InteractionId = item.InteractionId,
                    UserId = item.UserId,
                    ProductId = item.ProductId,
                    mark = item.Mark
                });
            }
            return View(cr);
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
            int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
            Random nn = new Random();
            Rate r = new Rate

            {
                InteractionId = RM.InteractionId+nn.Next(201,400),
                ProductId = RM.ProductId,
                UserId = UserId,
                Mark = RM.mark
           };
            try
            {
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
        public ActionResult Edit(int id , int idProduct)
        {
            int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
            Rate c = (Rate)serviceRate.GetBy3Id(id, UserId, idProduct);
            RateModel cm = new RateModel
            {
                InteractionId = c.InteractionId,
                UserId = c.UserId,
                ProductId = c.ProductId,
                mark=c.Mark
            };
            return View(cm);
        }

        // POST: Rate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id , int idProduct, RateModel cm)
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
                Rate c = (Rate)serviceRate.GetBy3Id(id, UserId, idProduct);
                c.Mark = cm.mark;
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cm);
            }
        }

        // GET: Rate/Delete/5
        public ActionResult Delete(int id, int idProduct)
        {
            int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
            Rate c = (Rate)serviceRate.GetBy3Id(id, UserId, idProduct);
            RateModel cm = new RateModel
            {
                mark = c.Mark
             };
            return View(cm);
        }

        // POST: Rate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, int idProduct, RateModel RM)
        {
            try
            {
                // TODO: Add delete logic here
                int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
                serviceRate.Delete(serviceRate.GetBy3Id(id, UserId, idProduct));
                serviceRate.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}