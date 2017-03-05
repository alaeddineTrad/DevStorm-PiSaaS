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
                    InteractionId=item.InteractionId,
                    UserId =item.UserId,
                    ProductId=item.ProductId,
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
            {

                InteractionId =CM.InteractionId,
                ProductId=CM.ProductId,
                UserId=CM.UserId,
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
        public ActionResult Edit(int id,int idUser,int idProduct)
        {
            Comment c = (Comment)serviceComment.GetBy3Id(id,idUser,idProduct);
            CommentModel cm = new CommentModel
            {   InteractionId=c.InteractionId,
                UserId = c.UserId,
                ProductId =c.ProductId,
                date = c.Date,
                text = c.Text
            };
            return View(cm);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,int idUser, int idProduct, CommentModel cm)
        {
            try
            {
                // TODO: Add update logic here
                Comment c = (Comment)serviceComment.GetBy3Id(id,idUser,idProduct);
                c.Date = DateTime.Now;
                c.Text = cm.text;
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cm);
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id, int idUser, int idProduct)
        {
            Comment c = (Comment)serviceComment.GetBy3Id(id, idUser, idProduct);
            CommentModel cm = new CommentModel
            {   date = c.Date,
                text = c.Text

            };
            return View(cm);
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,int idUser, int idProduct, CommentModel cm)
        {
            try
            {
                // TODO: Add delete logic here
                serviceComment.Delete(serviceComment.GetBy3Id(id, idUser, idProduct));
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