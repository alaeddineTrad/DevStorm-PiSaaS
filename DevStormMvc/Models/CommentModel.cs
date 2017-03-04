using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStormMvc.Models
{
    public class CommentModel : InteractionModel
    {
        public int commentId { get; set; }
        public DateTime date { get; set; }
        public string text { get; set; }
    }
}