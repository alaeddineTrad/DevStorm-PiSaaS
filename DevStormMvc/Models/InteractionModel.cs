using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class InteractionModel
    {
       
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public User user { get; set; }
        public Product product { get; set; }
    }
}