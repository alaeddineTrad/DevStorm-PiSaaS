using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class ShowroomModel
    {
        public int ShowroomerId { get; set; }
        public int ProductId { get; set; }
        public Showroomer Showroomer { get; set; }
        public Product product { get; set; }
    }
}