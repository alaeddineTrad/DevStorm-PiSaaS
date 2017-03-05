using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class ADUserModel
    {
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastName { get; set; }
        public string password1 { get; set; }
        public string password2 { get; set; }
        public string email { get; set; }
        
    }
}