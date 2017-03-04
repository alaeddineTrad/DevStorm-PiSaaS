using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class MediaModel
    {
        public int mediaId { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public User user { get; set; }
    }
}