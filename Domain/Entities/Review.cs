using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Entities
{
    public class Review
    {
        //[Key]
        //[Column(Order=1)]
        public int ShowroomerId { get; set; }
        //[Key]
        //[Column(Order = 2)]
        public int BuyerId { get; set; }
        //[ForeignKey("ShowroomerId")]
        public virtual Showroomer Showroomer { get; set; }
        //[ForeignKey("BuyerId")]
        public virtual Buyer Buyer { get; set; }

        public Review()
        {

        }
    }
}