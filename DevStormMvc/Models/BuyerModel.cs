using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class BuyerModel : UserModel
    {
        public string deliveryAddress { get; set; }
    }
}