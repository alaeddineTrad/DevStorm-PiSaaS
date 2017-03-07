using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStormMvc.Models
{
    public class InteractionModel
    {
        public int InteractionId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public User user { get; set; }
        public Product product { get; set; }
        public IEnumerable<SelectListItem> ListUsers { get; set; }
        public IEnumerable<SelectListItem> ListProducts { get; set; }
    }
}