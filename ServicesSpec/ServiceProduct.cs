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
    public class ServiceProduct : Service<Product>, IServiceProduct
    {
        public static IDatabaseFactory Dbf = new DatabaseFactory();
        public static IUnitOfWork UOW = new UnitOfWork(Dbf);

        public ServiceProduct() : base(UOW)
        {
        }

        public int getLastId()
        {
            return GetAll().Select(x => x.ProductId).Max();
        }
        public void testId()
        {

        }

        public IEnumerable<Image> GetImageByProductId(int productId)
        {
            return UOW.GetRepository<Image>().GetAll().Where(x => x.ProductId == productId);
        }

    }
}
