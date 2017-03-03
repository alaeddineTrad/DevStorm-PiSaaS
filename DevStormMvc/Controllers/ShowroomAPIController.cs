using DevStormMvc.Models;
using Domain.Entities;
using Services;
using ServicesSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevStormMvc.Controllers
{
    public class ShowroomAPIController : ApiController
    {
        IServiceShowroom serviceShowroom = new ServiceShowroom();
        // GET: api/ShowroomAPI
        public IEnumerable<ShowroomerModel> Get()
        {
            List<ShowroomModel> cr = new List<ShowroomModel>();
            List<Showroomer> lsr = new List<Showroomer>();
            List<ShowroomerModel> lsrm = new List<ShowroomerModel>();
            List<Product> lsp = new List<Product>();
            List<ProductModel> lspm = new List<ProductModel>();
            var l = serviceShowroom.GetAll();
            foreach (var item in l)
            {
                cr.Add(new ShowroomModel
                {
                    ProductId = item.ProductId,
                    ShowroomerId = item.ShowroomerId,
                    Showroomer=item.Showroomer
                 });
            }
            foreach(var item in cr)
            {
                lsr.Add(item.Showroomer);
            }
            //foreach (var item in cr)
            //{
            //    lsp.Add(item.product);
            //}
            foreach (var item in lsr)
            {
                lsrm.Add(new ShowroomerModel
                {   
                    firstName = item.FirstName,
                    lastName = item.LastName,
                    phone = Convert.ToInt32(item.Phone)
                    
                });
            }
            return lsrm;
            //{
            //foreach (var item in lsp) {
            //    lspm.Add(new ProductModel
            //    {
            //        name = item.Name,
            //        category = item.Category, 
            //        price=item.Price

            //    });
            //} }


        }

        // GET: api/ShowroomAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ShowroomAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShowroomAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShowroomAPI/5
        public void Delete(int id)
        {
        }
    }
}
