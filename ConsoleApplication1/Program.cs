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

            //IServiceProduct s = new ServiceProduct();


            IServiceProduct s = new ServiceProduct();
            ServiceShowroomer serviceShowroomer = new ServiceShowroomer();
            Address add = new Address
            {
                City = "ariana",
                Street = "ariana",
                ZipCode = 25
            };
            Location loc = new Location { Latitude = 555, Longitude = 545 };
            Showroomer sh = new Showroomer { Adress = add, FirstName = "test", Location = loc };
            Showroomer sh1 = new Showroomer { Adress = add, FirstName = "test2", Location = loc };
            Showroomer sh2 = new Showroomer { Adress = add, FirstName = "test3", Location = loc };
            DatabaseFactory d = new DatabaseFactory();
            UnitOfWork u = new UnitOfWork(d);
            u.GetRepository<Showroomer>().Add(sh);
            u.GetRepository<Showroomer>().Add(sh1);
            u.GetRepository<Showroomer>().Add(sh2);
            u.Commit();
            IEnumerable<Showroomer> showroomers = serviceShowroomer.GetAll();
            foreach (var item in showroomers)
            {
                Console.WriteLine(item.FirstName);
            }


            ////Category c = new Category { Name = "Test" };


            //DatabaseFactory d = new DatabaseFactory();
            //UnitOfWork u = new UnitOfWork(d);
            //Address ad = new Address { City = "Ariana" };

            //User a = new User { FirstName = "Ala", Adress = ad };
            //Buyer a = new Buyer { Adress = ad, FirstName = "Ala" };
            //Product p = new Product { Brand = "zara" };
            //Console.WriteLine(u.GetRepository<Comment>().GetBy2Id(1, 1)); 
            //Interaction I = new Interaction { ProductId=1,UserId=1};
            //Comment c = new Comment {InteractionId=1,Text="ss" };
            //u.GetRepository<Product>().Add(p);
            //u.GetRepository<User>().Add(a);
            u.GetRepository<Comment>().Delete(u.GetRepository<Comment>().GetBy3Id(0, 1, 1));
            u.Commit();

            //User a = new User { FirstName = "Ala",Adress=ad };
            //Product p = new Product {Brand="zara" };
            //u.GetRepository<User>().Add(a);
            //Interaction I = new Interaction { ProductId=1,UserId=1};
            //Comment c = new Comment {InteractionId=1,Text="ss" };
            //u.GetRepository<Interaction>().Add(I);
            //u.GetRepository<Comment>().Add(c);

            //u.Commit();

            Console.WriteLine("fin");
            Console.ReadKey();

        }
    }
}
