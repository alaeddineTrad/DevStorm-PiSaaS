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
    public class CommentReviewController : Controller
    {
        IServiceCommentReview serviceCommentReview = new ServiceCommentReview();
        // GET: CommentReview
        public ActionResult Index()
        {
            List<CommentReviewModel> cr = new List<CommentReviewModel>();
            var l = serviceCommentReview.GetAll();
            foreach(var item in l)
            {
                cr.Add(new CommentReviewModel{
                   // commentreviewId=item.CommentReviewId,
                    date=item.Date,
                    text=item.Text
                    
                });
            }
            return View(cr);
        }

        // GET: CommentReview/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public PartialViewResult All()
        {
            List<CommentReviewModel> cr = new List<CommentReviewModel>();
            var l = serviceCommentReview.GetAll();
            foreach (var item in l)
            {
                cr.Add(new CommentReviewModel
                {  // commentreviewId=item.CommentReviewId,
                    date = item.Date,
                    text = item.Text
                     });
            }
            return PartialView("_Comment",cr);
        }
        // GET: CommentReview/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentReview/Create
        [HttpPost]
        public ActionResult Create(CommentReviewModel CRM)
        {
            CommentReview cr = new CommentReview
            {
              //  CommentReviewId = CRM.commentreviewId,
                Date = DateTime.Now,
                Text = CRM.text
            };
            try
            {
                // TODO: Add insert logic here

                serviceCommentReview.Add(cr);
                serviceCommentReview.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentReview/Edit/5
        public ActionResult Edit(int id)
        {
            CommentReview c = (CommentReview)serviceCommentReview.GetById(id);
            CommentReviewModel cm = new CommentReviewModel
            {   
                Buyer = c.Buyer,
                Showroomer = c.Showroomer,
                date=c.Date,
                text=c.Text

            };
            return View(cm);
        }

        // POST: CommentReview/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CommentReviewModel cm)
        {
            try
            {
                // TODO: Add update logic here
                CommentReview c = (CommentReview)serviceCommentReview.GetById(id);
                c.Date = DateTime.Now;
                c.Text = cm.text;
                c.Buyer = cm.Buyer;
                c.Showroomer = cm.Showroomer;
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cm);
            }
        }

        // GET: CommentReview/Delete/5
        public ActionResult Delete(int id)
        {
            CommentReview c = (CommentReview)serviceCommentReview.GetById(id);
            CommentReviewModel cm = new CommentReviewModel
            {
                
                Buyer = c.Buyer,
                Showroomer = c.Showroomer,
                date = c.Date,
                text = c.Text

            };
            return View(cm);
        }

        // POST: CommentReview/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CommentReviewModel cm)
        {
            try
            {
                // TODO: Add delete logic here
                serviceCommentReview.Delete(serviceCommentReview.GetById(id));
                serviceCommentReview.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}