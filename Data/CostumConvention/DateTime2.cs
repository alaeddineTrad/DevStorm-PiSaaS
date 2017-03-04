using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CostumConvention
{
    public class DateTime2 : Convention
    {
        public DateTime2()
        {
            Properties<DateTime>().Configure(x => x.HasColumnType("DateTime2"));
        }
    }
}
