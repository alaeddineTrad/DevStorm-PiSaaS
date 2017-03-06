using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class ADUserLongModel
    {
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime LastLogon { get; set; }
        public string Role { get; set; }
    }
}