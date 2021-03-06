﻿using DevStormMvc.Data.Infrastructure;
using Domain.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesSpec
{
    public class ServiceImage : Service<Image>, IServiceImage
    {
        private static IDatabaseFactory Dbf = new DatabaseFactory();
        private static IUnitOfWork UOW = new UnitOfWork(Dbf);

        public ServiceImage() : base(UOW)
        {
        }
    }
}
