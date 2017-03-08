using DevStormMvc.Data.Infrastructure;
using Domain.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesSpec
{
   public class OrderService : Service<Order>, IService<Order>
    {
        private static IDatabaseFactory Dbf = new DatabaseFactory();
        private static IUnitOfWork UOW = new UnitOfWork(Dbf);
        ServiceProduct serviceProduct = new ServiceProduct();
        public OrderService():base(UOW)
        {

        }

        public void AddtoCart(int idUser,int idProduct,int Quantity)
        {
            int check = 0;
            IEnumerable<int> distinctedPurchaseId= (from p in GetAll()
                                                     where p.UserId==idUser
                                                    select p.PurchaseId).Distinct();
            foreach(int i in distinctedPurchaseId)
            {
                Purchase p = UOW.GetRepository<Purchase>().GetById(i);
                if (p.Status.Equals("Cart"))
                {
                    check = p.PurchaseId;
                }
            }
            if (check == 0)
            {
                Purchase pp = new Purchase
                {
                    DatePurchase = new DateTime(),
                    Total = (serviceProduct.GetById(idProduct).Price)*Quantity,  
                    Status = "Cart"  
                };
                UOW.GetRepository<Purchase>().Add(pp);
                UOW.Commit();
                int idNewPurchase = UOW.GetRepository<Purchase>().GetAll().Select(x => x.PurchaseId).Max();

                Order o = new Order
                {
                    PurchaseId = idNewPurchase,
                    ProductId = idProduct,
                    UserId = idUser,
                    Quantity = Quantity    
                };
                UOW.GetRepository<Order>().Add(o);
                UOW.Commit();
            }

            else
            {
                int checkProduct = 0;
                Purchase pp = UOW.GetRepository<Purchase>().GetById(check);
                pp.Total = pp.Total + (serviceProduct.GetById(idProduct).Price) * Quantity;
                UOW.GetRepository<Purchase>().Update(pp);
                UOW.Commit();
                int idNewPurchase = pp.PurchaseId;
                Order o = new Order
                {
                    PurchaseId = idNewPurchase,
                    ProductId = idProduct,
                    UserId = idUser,
                    Quantity = Quantity
                };
                foreach (Order order in GetAll().Where(x => x.PurchaseId == idNewPurchase))
                {
                    if (order.ProductId == idProduct)
                    {
                        order.Quantity = Quantity;
                        Update(order);
                        checkProduct = 1;
                        UOW.Commit();
                    }

                }
                if(checkProduct!=1)
                    {
                    Add(o);
                    UOW.Commit();
                    }

            }


        }

        public IEnumerable<Order> CartOrders(int idUser)
        {
            IEnumerable<Order> allOrders= GetAll().Where(x => x.UserId == idUser);
            IEnumerable<Purchase> allPurchases = UOW.GetRepository<Purchase>().GetAll().Where(x=>x.Status.Equals("Cart"));

            return
                from purchase in allPurchases
                join order in allOrders on purchase.PurchaseId equals order.PurchaseId into purchases
                from prod2 in purchases
                select prod2;

        }
        public void ClearAll(int idUser)
        {
            int idPurchased=CartOrders(idUser).First().PurchaseId;
            UOW.GetRepository<Purchase>().Delete(UOW.GetRepository<Purchase>().GetById(idPurchased));
            Commit();
        }
    }
}
