using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Buyer : User
    {
        private string deliveryAddress;
        public virtual ICollection<Review> Reviews { get; set; }

      
        public string DeliveryAddress
        {
            get
            {
                return deliveryAddress;
            }

            set
            {
                deliveryAddress = value;
            }
        }
    }
}
