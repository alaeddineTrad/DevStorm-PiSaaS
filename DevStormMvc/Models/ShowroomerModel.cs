using Domain.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class ShowroomerModel : UserModel
    {
        private string description { get; set; }
        private Location location { get; set; }
    }
}