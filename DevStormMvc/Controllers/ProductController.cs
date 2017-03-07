﻿using Data;
using DevStormMvc.Data.Infrastructure;
using DevStormMvc.Models;
using Domain.Entities;
using Domain.Entities.ComplexType;
using ServicesSpec;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Services;

namespace DevStormMvc.Controllers
{
    public class ProductController : Controller
    {
        IServiceRate serviceRate = new ServiceRate();
        IServiceProduct serviceProduct = new ServiceProduct();
        IServiceComment serviceComment = new ServiceComment();
        IServiceShowroom serviceShowroom = new ServiceShowroom();
        // GET: Product
        public ActionResult Index()
        {
            DatabaseFactory dbf = new DatabaseFactory();
            UnitOfWork u = new UnitOfWork(dbf);
            List<ProductModel> pm = new List<ProductModel>();
            var l = u.GetRepository<Product>().GetAll();
           foreach(var item in l)
            {
                pm.Add(new ProductModel
                {
                    productId = item.ProductId,
                    name = item.Name,
                    brand = item.Brand,
                    discount = item.Discount,
                    tva = item.Tva,
                    price = item.Price,
                    quantity = item.Quantity,
                    category = item.Category,

                });
            }
            return View(pm);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product p = (Product)serviceProduct.GetById(id);
            ProductModel pm = new ProductModel
            {
                productId = p.ProductId,
                name = p.Name,
                brand = p.Brand,
                discount = p.Discount,
                tva = p.Tva,
                price = p.Price,
                quantity = p.Quantity,
                category = p.Category,
            };
            return View(pm);
        }
        public PartialViewResult All(int id)
        {
            List<CommentModel> cr = new List<CommentModel>();
            var l = serviceComment.GetAll().Where(x => x.ProductId == id);
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
        public PartialViewResult AllRate(int id)
        {
            List<RateModel> cr = new List<RateModel>();
            var l = serviceRate.GetAll().Where(x=>x.ProductId==id);
            foreach (var item in l)
            {
                cr.Add(new RateModel
                {   
                    mark = item.Mark,
                    user=item.User
                    
                 });
            }
            return PartialView("_Rate", cr);
        }
        public PartialViewResult AllShowrooms(int id)
        {
            List<ShowroomModel> cr = new List<ShowroomModel>();
            var l = serviceShowroom.GetAll().Where(x => x.ProductId == id);
            foreach (var item in l)
            {
                cr.Add(new ShowroomModel
                {
                    
                    Showroomer = item.Showroomer,


                });
            }
            return PartialView("_Showrooms", cr);
        }
        public PartialViewResult AvgRate(int id)
        {
            
            var l = serviceRate.GetAll().Where(x => x.ProductId == id).Average(x=>x.Mark);
            return PartialView("_Avg",l);

        }
        public PartialViewResult Last(int id)
        {
            List<CommentModel> cr = new List<CommentModel>();
            var l = serviceComment.GetAll().Where(x => x.ProductId == id).OrderByDescending(x => x.Date).Take(1);
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


        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel PM)
        {
            Context ctx = new Context(); 
            Product p = new Product

            {
                ProductId = PM.productId,
                Name = PM.name,
                Brand = PM.brand,
                Discount = PM.discount,
                Tva = PM.tva,
                Price = PM.price,
                Quantity = PM.quantity,
                Category = PM.category,
                //Images = im
               
            };
            
            try
            {
                // TODO: Add insert logic here
                //serviceProduct.Add(p);
                //serviceProduct.Commit();
                DatabaseFactory dbf = new DatabaseFactory();
                UnitOfWork u = new UnitOfWork(dbf);
                u.GetRepository<Product>().Add(p);
                u.Commit();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = (Product)serviceProduct.GetById(id);
            ProductModel pm = new ProductModel
            {
                productId = p.ProductId,
                name = p.Name,
                brand = p.Brand,
                discount = p.Discount,
                tva = p.Tva,
                price = p.Price,
                quantity = p.Quantity,
                category = p.Category,
            };
            return View(pm);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductModel pm)
        {
            try
            {
                // TODO: Add update logic here
                Product p = (Product)serviceProduct.GetById(id);
                p.Name = pm.name;
                p.Brand = pm.brand;
                p.Discount = pm.discount;
                p.Tva = pm.tva;
                p.Price = pm.price;
                p.Quantity = pm.quantity;
                p.Category = pm.category;
                serviceProduct.Update(p);
                serviceProduct.Commit();
                //DatabaseFactory dbf = new DatabaseFactory();
                //UnitOfWork u = new UnitOfWork(dbf);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pm);
            }
        }
    
    
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product p = (Product)serviceProduct.GetById(id);
            ProductModel pm = new ProductModel
            {
                productId = p.ProductId,
                name = p.Name,
                brand = p.Brand,
                discount = p.Discount,
                tva = p.Tva,
                price = p.Price,
                quantity = p.Quantity,
                category = p.Category,

            };
            return View(pm);
        }
        

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductModel pm)
        {
            try
            {
                // TODO: Add delete logic here
                serviceProduct.Delete(serviceProduct.GetById(id));
                serviceProduct.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
