using DevStormMvc.Models;
using Domain.Entities;
using Services;
using ServicesSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStormMvc.Controllers
{
    public class ShowroomController : Controller
    {
        IServiceShowroom serviceShowroom = new ServiceShowroom();
        IServiceProduct serviceProduct = new ServiceProduct();
        IServiceShowRoomer serviceShowroomer = new ServiceShowroomer();
        // GET: Showroom
        public ActionResult Index()
        {
            List<ShowroomModel> cr = new List<ShowroomModel>();
            var l = serviceShowroom.GetAll();
            foreach (var item in l)
            {
                cr.Add(new ShowroomModel
                {
                    ProductId=item.ProductId,
                    ShowroomerId=item.ShowroomerId,
                    Showroomer=item.Showroomer,
                    product=item.Product
                    
                });
            }
            return View(cr);
        }

        // GET: Showroom/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Showroom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Showroom/Create
        [HttpPost]
        public ActionResult Create(ShowroomModel sm)
        {
            Showroom s = new Showroom
            {
                ProductId=sm.ProductId,
                ShowroomerId=sm.ShowroomerId

            };
           
            try
            {

                serviceShowroom.Add(s);
                serviceShowroom.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Showroom/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Showroom/Edit/5
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

        // GET: Showroom/Delete/5
        public ActionResult Delete(int id, int idProduct)
        {
            Showroom c = (Showroom)serviceShowroom.GetBy2Id(id, idProduct);
            ShowroomModel cm = new ShowroomModel
            {
                product=c.Product
            };
            return View(cm);
        }

        // POST: Showroom/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, int idProduct, ShowroomModel cm)
        {
            try
            {
                // TODO: Add delete logic here

                serviceShowroom.Delete(serviceShowroom.GetBy2Id(id, idProduct));
                serviceShowroom.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
