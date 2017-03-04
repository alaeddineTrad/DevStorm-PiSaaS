using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class PurchaseModel
    {
        
        public DateTime date { get; set; }

        public float total { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Product Product { get; set; }

    }
}