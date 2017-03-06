using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStormMvc.Models
{
    public class LoginViewModel
    {
        [Required, AllowHtml]
        public string Username { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}