using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ComplexType
{
    public class Address
    {
        public String City { get; set; }
        public String Street { get; set; }
        public int ZipCode { get; set; }

    }
}
