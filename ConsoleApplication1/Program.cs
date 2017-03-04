using DevStormMvc.Data.Infrastructure;
using Domain.Entities;
using Domain.Entities.ComplexType;
using ServicesSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("debut");
            IServiceProduct s = new ServiceProduct();


            ////Category c = new Category { Name = "Test" };


            DatabaseFactory d = new DatabaseFactory();
            UnitOfWork u = new UnitOfWork(d);
            //Address ad = new Address { City = "Ariana" };
            //User a = new User { FirstName = "Ala",Adress=ad };
            //Product p = new Product {Brand="zara" };
            //u.GetRepository<User>().Add(a);
            Interaction I = new Interaction { ProductId=1,UserId=1};
            //Comment c = new Comment {InteractionId=1,Text="ss" };
            u.GetRepository<Interaction>().Add(I);
            //u.GetRepository<Comment>().Add(c);

            u.Commit();
            Console.WriteLine("fin");
            Console.ReadKey();

        }
    }
}
