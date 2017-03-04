using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class ReviewModel
    {
        public Showroomer Showroomer { get; set; }
        public Buyer Buyer { get; set; }
    }
}