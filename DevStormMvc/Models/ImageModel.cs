using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class ImageModel
    {
     
        public int imageId { get; set; }
        public string name { get; set; }

        public string url { get; set; }
        public virtual Product Product { get; set; }
        



    }
}