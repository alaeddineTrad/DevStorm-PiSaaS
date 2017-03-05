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
    public class RateReviewController : Controller
    {
        IServiceRateReview serviceRateReview = new ServiceRateReview();
        // GET: RateReview
        public ActionResult Index()
        {
            List<RateReviewModel> rm = new List<RateReviewModel>();
            var l = serviceRateReview.GetAll();
            foreach(var item in l)
            {
                rm.Add(new RateReviewModel{
                    //ratereviewId=item.RateReviewId,
                    Buyer=item.Buyer,
                    mark=item.Mark,
                    Showroomer=item.Showroomer
                    
                });
            }
            return View(rm);
        }

        // GET: RateReview/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RateReview/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RateReview/Create
        [HttpPost]
        public ActionResult Create(RateReviewModel RRM)
        {
            RateReview rr = new RateReview

            {  // RateReviewId=RRM.ratereviewId,
                Mark = RRM.mark,

                
            };
            try
            {
                // TODO: Add insert logic here

                serviceRateReview.Add(rr);
                serviceRateReview.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RateReview/Edit/5
        public ActionResult Edit(int id)
        {
            RateReview r = (RateReview)serviceRateReview.GetById(id);
            RateReviewModel rm = new RateReviewModel
            {
                //ratereviewId = r.RateReviewId,
                Buyer = r.Buyer,
                mark = r.Mark,
                Showroomer = r.Showroomer

            }; 
        
            return View(rm);
        }

        // POST: RateReview/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RateReviewModel rm)
        {
            try
            {
                // TODO: Add update logic here
                RateReview r = (RateReview)serviceRateReview.GetById(id);
                r.Mark = rm.mark;

              //  r.RateReviewId = rm.ratereviewId;
                r.Buyer = rm.Buyer;
                r.Showroomer = rm.Showroomer;
                return RedirectToAction("Index");
            }
            catch
            {
                return View(rm);
            }
        }

        // GET: RateReview/Delete/5
        public ActionResult Delete(int id)
        {
            RateReview r = (RateReview)serviceRateReview.GetById(id);
            RateReviewModel rm = new RateReviewModel
            {
               // ratereviewId = r.RateReviewId,
                Buyer = r.Buyer,
                mark = r.Mark,
                Showroomer = r.Showroomer

            };

            return View(rm);
        }

        // POST: RateReview/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RateReviewModel rm)
        {
            try
            {
                // TODO: Add delete logic here
                serviceRateReview.Delete(serviceRateReview.GetById(id));
                serviceRateReview.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}