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
    public class CommentAPIController : ApiController
    {
        IServiceComment serviceComment = new ServiceComment();
        // GET: api/CommentAPI
        public IEnumerable<CommentModel> Get()
        {
            List<CommentModel> cr = new List<CommentModel>();
            var l = serviceComment.GetAll();
            foreach (var item in l)
            {
                User a = new User();
                a = item.User;

                cr.Add(new CommentModel
                {
                    InteractionId = item.InteractionId,
                    UserId = item.UserId,
                    ProductId = item.ProductId,
                    date = item.Date,
                    text = item.Text,

                });

            }
            return cr;
        }

        // GET: api/CommentAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CommentAPI
        
        public void Post(string text,int idProduct,int userid )
        {
            Random nn = new Random();
            Comment c = new Comment
            {
                InteractionId = nn.Next(2, 200),
                ProductId = idProduct,
                UserId = userid,
                Date = DateTime.Now,
                Text = text

            };
            serviceComment.Add(c);
            serviceComment.Commit();
            
        }

        // PUT: api/CommentAPI/5
        public IEnumerable<CommentModel> Put(int InteractionId, int UserId, int ProductId,string text)
        {
            Comment c = (Comment)serviceComment.GetBy3Id(InteractionId, UserId, ProductId);
            c.Date = DateTime.Now;
            c.Text = text;
            CommentAPIController ccc= new CommentAPIController();
            serviceComment.Commit();
            return ccc.Get();

        }

        // DELETE: api/CommentAPI/5
        public IEnumerable<CommentModel> Delete(int InteractionId, int UserId, int ProductId)
        {
            serviceComment.Delete(serviceComment.GetBy3Id(InteractionId, UserId, ProductId));
            CommentAPIController ccc = new CommentAPIController();
            serviceComment.Commit();
            return ccc.Get();
        }
    }
}
