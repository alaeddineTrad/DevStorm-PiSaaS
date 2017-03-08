using DevStormMvc.Identity_Management;
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
    [ADGroupAuthorize]
    public class OrderController : Controller
    {
        ServiceProduct serviceProduct;
        OrderService orderService;
        public OrderController()
        {
            orderService = new OrderService();
            serviceProduct = new ServiceProduct();
        }
        // GET: Cart
        public ActionResult Index()
        {
            int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
            IEnumerable<Order> orders = orderService.CartOrders(UserId);
            List<OrderModel> OrdersModels = new List<OrderModel>();
            double Total = 0;
            foreach(Order o in orders)
            {
                OrderModel om = new OrderModel
                {
                    OrderId = o.OrderId,
                    idProd = o.ProductId,
                    ProductName = serviceProduct.GetById(o.ProductId).Name,
                    Price = serviceProduct.GetById(o.ProductId).Price,
                    Quantity = o.Quantity
                };
                Total = Total+(serviceProduct.GetById(o.ProductId).Price*o.Quantity);
                OrdersModels.Add(om);
            }
            ViewBag.Total = Total;
            return View(OrdersModels);
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create(int idProduct)
        {
            ViewBag.product = serviceProduct.GetById(idProduct);
            ViewBag.idProduct = idProduct;
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(OrderModel om)
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
                orderService.AddtoCart(UserId,om.idProd,om.Quantity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
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

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            Order o = orderService.GetById(id);
           
                OrderModel om = new OrderModel
                {
                    idProd = o.ProductId,
                    ProductName = serviceProduct.GetById(o.ProductId).Name,
                    Price = serviceProduct.GetById(o.ProductId).Price,
                    Quantity=o.Quantity
                };
               
            return View(om);
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OrderModel om)
        {
            try
            {
                orderService.Delete(orderService.GetById(id));
                orderService.Commit();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Clear()
        {
            int UserId = Convert.ToInt32(HttpContext.Request.Cookies["User"].Values["Id"]);
            orderService.ClearAll(UserId);
            return RedirectToAction("Index");
        }
    }
}
