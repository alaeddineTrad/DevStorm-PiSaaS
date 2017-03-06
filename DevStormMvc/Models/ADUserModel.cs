using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class ADUserModel
    {

        [Required]
        [MinLength(4)]
        [MaxLength(19)]
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastName { get; set; }
        [Required]
        [MinLength(8)]
        
        [DataType(DataType.Password)]
        public string password1 { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password2 { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

    }
}