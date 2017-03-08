using DevStormMvc.Data.Infrastructure;
using DevStormMvc.helper;
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
    [Authorize]
    public class CommentController : Controller
    {
        IServiceComment serviceComment = new ServiceComment();
        IServiceRate serviceRate = new ServiceRate();
        ServiceUser serviceUser = new ServiceUser();
        IServiceProduct serviceProduct = new ServiceProduct();
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
                    UserId = item.UserId,
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
            //IEnumerable<User> Users = serviceUser.GetAll();
            //IEnumerable<Product> Products = serviceProduct.GetAll();
            
            //CommentModel pum = new CommentModel();

            //pum.ListUsers = Users.ToSelectUser();
            //pum.ListProducts = Products.ToSelectProduct();

            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CommentModel CM)
        {
            int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
            Random nn = new Random();
            Comment c = new Comment
            {
                InteractionId =CM.InteractionId+nn.Next(2,200),
                ProductId = CM.ProductId,
                UserId= UserId,
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
        public ActionResult Edit(int id, int idProduct)
        {
            int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
            Comment c = (Comment)serviceComment.GetBy3Id(id,UserId,idProduct);
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
        public ActionResult Edit(int id, int idProduct, CommentModel cm)
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
                // TODO: Add update logic here
                Comment c = (Comment)serviceComment.GetBy3Id(id,UserId,idProduct);
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
        public ActionResult Delete(int id, int idProduct)
        {
            int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
            Comment c = (Comment)serviceComment.GetBy3Id(id, UserId, idProduct);
            CommentModel cm = new CommentModel
            {   date = c.Date,
                text = c.Text

            };
            return View(cm);
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, int idProduct, CommentModel cm)
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
                // TODO: Add delete logic here
                serviceComment.Delete(serviceComment.GetBy3Id(id, UserId, idProduct));
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