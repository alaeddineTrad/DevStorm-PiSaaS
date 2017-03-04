using Domain.Entities;
using Domain.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class ProductModel
    {
        public int productId { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public float price { get; set; }
        public float tva { get; set; }
        public string category { get; set; }
        public int quantity { get; set; }
        public float discount { get; set; }
        public List<Image> Images { get; set; }
    }
}