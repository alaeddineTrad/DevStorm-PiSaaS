using DevStormMvc.Data.Infrastructure;
using Domain.Entities;
using Services;
using ServicesSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesSpec
{
    public class ServiceUser : Service<User>, IServiceUser
    {
        public static IDatabaseFactory Dbf = new DatabaseFactory();
        public static IUnitOfWork UOW = new UnitOfWork(Dbf);

        public ServiceUser() : base(UOW)
        {
        }
    }
}
