using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class VoucherModel
    {
        public int voucherId { get; set; }
        public string reference { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float amount { get; set; }
        public Showroomer showroomer { get; set; }
    }
}