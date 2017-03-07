using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public String ProductName { get; set; }
        public int Quantity { get; set; }
        public int idProd { get; set; }
        public double Price { get; set; }
    }
}