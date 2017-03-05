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
    public class CommentController : Controller
    {
        IServiceComment serviceComment = new ServiceComment();
        // GET: Comment
        public ActionResult Index()
        {
            List<CommentModel> cr = new List<CommentModel>();
            var l = serviceComment.GetAll();
            foreach (var item in l)
            {
                cr.Add(new CommentModel
                {
                    
                    date = item.Date,
                    text = item.Text

                });
            }
            return View(cr);
        }
        public PartialViewResult All()
        {
            List<CommentModel> cr = new List<CommentModel>();
            var l = serviceComment.GetAll();
            foreach (var item in l)
            {
                cr.Add(new CommentModel
                {
                    //commentId = item.CommentId,
                    date = item.Date,
                    text = item.Text
                });
            }
            return PartialView("_Comment", cr);
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CommentModel CM)
        {
            Comment c = new Comment
            {   ProductId=CM.ProductId,
                UserId=CM.UserId,
                //CommentId = CM.commentId,
                Date = DateTime.Now,
                Text = CM.text
                
            };
            
            try
            {
                serviceComment.Add(c);
                serviceComment.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            Comment c = (Comment)serviceComment.GetById(id);
            CommentModel cm = new CommentModel
            {
                UserId=c.UserId,
                product=c.Product,
                date = c.Date,
                text = c.Text

            };
            return View(cm);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CommentModel cm)
        {
            try
            {
                // TODO: Add update logic here
                Comment c = (Comment)serviceComment.GetById(id);
                c.Date = DateTime.Now;
                c.Text = cm.text;
                c.User = cm.user;
                c.Product = cm.product;
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cm);
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            Comment c = (Comment)serviceComment.GetById(id);
            CommentModel cm = new CommentModel
            {
                user = c.User,
                product = c.Product,
                date = c.Date,
                text = c.Text

            };
            return View(cm);
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CommentModel cm)
        {
            try
            {
                // TODO: Add delete logic here
                serviceComment.Delete(serviceComment.GetById(id));
                serviceComment.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}