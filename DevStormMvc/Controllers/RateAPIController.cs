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
    public class RateAPIController : ApiController
    {
        IServiceRate serviceRate = new ServiceRate();
        // GET: api/RateAPI
        public IEnumerable<RateModel> Get()
        {
            List<RateModel> cr = new List<RateModel>();
            var l = serviceRate.GetAll();
            foreach (var item in l)
            {
                cr.Add(new RateModel
                {
                    InteractionId = item.InteractionId,
                    UserId = item.UserId,
                    ProductId = item.ProductId,
                    mark = item.Mark
                });
            }
            return cr;
        }

        // GET: api/RateAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RateAPI
        public IEnumerable<RateModel> Post(int mark, int ProductId, int UserId)
        {
            Random nn = new Random();
            Rate r = new Rate

            {
                InteractionId =  nn.Next(201, 400),
                ProductId = ProductId,
                UserId = UserId,
                Mark = mark
            };
            serviceRate.Add(r);
            serviceRate.Commit();
            RateAPIController rrr = new RateAPIController();
            return rrr.Get();
        }

        // PUT: api/RateAPI/5
        public IEnumerable<RateModel> Put(int InteractionId, int UserId, int ProductId, int mark)
        {
            Rate r = (Rate)serviceRate.GetBy3Id(InteractionId, UserId, ProductId);
            r.Mark = mark;
            serviceRate.Commit();
            RateAPIController rrr = new RateAPIController();
            return rrr.Get();

        }

        // DELETE: api/RateAPI/5
        public IEnumerable<RateModel> Delete(int InteractionId, int UserId, int ProductId)
        {
            serviceRate.Delete(serviceRate.GetBy3Id(InteractionId, UserId, ProductId));
            serviceRate.Commit();
            RateAPIController rrr = new RateAPIController();
            return rrr.Get();

        }
    }
}
