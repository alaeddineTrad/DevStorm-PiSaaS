using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public int userId { get; set; }
        public IEnumerable<SelectListItem> ListShowroomers { get; set; }


    }
}