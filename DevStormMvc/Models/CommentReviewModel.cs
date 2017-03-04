using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class CommentReviewModel : ReviewModel
    {
       
        public DateTime date { get; set; }
        public string text { get; set; }
    }
}