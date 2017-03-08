using DevStormMvc.Models;
using Domain.Entities;
using ServicesSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevStormMvc.Controllers
{
    public class ProductAPIController : ApiController
    {
        IServiceProduct spa = new ServiceProduct();
        // GET: api/ProductAPI
        public IEnumerable<ProductModel> Get()
        {
            List<ProductModel> cr = new List<ProductModel>();
            var l = spa.GetAll();
            foreach (var item in l)
            {
                cr.Add(new ProductModel
                {
                   brand=item.Brand,
                   category=item.Category,
                   discount=item.Discount,
                   name=item.Name

                });
            }
            return cr;
        }

        // GET: api/ProductAPI/5
        public IEnumerable<ProductModel> Get(int id)
        {
            List<ProductModel> cr = new List<ProductModel>();
            var l = spa.GetById(id);
            
                cr.Add(new ProductModel
                {
                    brand = l.Brand,
                    category = l.Category,
                    discount = l.Discount,
                    name = l.Name

                });
            
            return cr;
        }

        // POST: api/ProductAPI
        public IEnumerable<ProductModel> Post(string name, string brand,
                                    float discount, 
                                    float tva, 
                                    float price,
                                    int quantity,
                                    string category)
        {
            Product p = new Product

            {
                
                Name = name,
                Brand = brand,
                Discount = discount,
                Tva = tva,
                Price = price,
                Quantity = quantity,
                Category = category,


            };
            spa.Add(p);
            spa.Commit();
            ProductAPIController ppp = new ProductAPIController();
            return ppp.Get();
        }

        // PUT: api/ProductAPI/5
        public IEnumerable<ProductModel> Put(int id, string name, string brand,
                                    float discount,
                                    float tva,
                                    float price,
                                    int quantity,
                                    string category)
        {
            Product p = (Product)spa.GetById(id);
            p.Name = name;
            p.Brand = brand;
            p.Discount = discount;
            p.Tva = tva;
            p.Price = price;
            p.Quantity = quantity;
            p.Category = category;
            spa.Commit();
            ProductAPIController ppp = new ProductAPIController();
            return ppp.Get();
        }

        // DELETE: api/ProductAPI/5
        public IEnumerable<ProductModel> Delete(int id)
        {
            spa.Delete(spa.GetById(id));
            spa.Commit();
            ProductAPIController ppp = new ProductAPIController();
            return ppp.Get();

        }
    }
}
