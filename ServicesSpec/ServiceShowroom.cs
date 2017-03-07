
using Domain.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevStormMvc.Data.Infrastructure;

namespace ServicesSpec
{
    public class ServiceShowroom : Service<Showroom>, IServiceShowroom
    {
        public static IDatabaseFactory Dbf = new DatabaseFactory();
        public static IUnitOfWork UOW = new UnitOfWork(Dbf);
        public ServiceShowroom() : base(UOW)
        {
        }
    }
}
