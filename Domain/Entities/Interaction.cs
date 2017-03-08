using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Interaction
    {
        //[Key]
        //[Column(Order=1)]
        
        public int InteractionId { get; set; }
        public int UserId { get; set; }
        //[Key]
        //[Column(Order = 2)]
        public int ProductId { get; set; }
        
        public virtual User User { get; set; }
        
        public virtual Product Product { get; set; }
         public Interaction()
        {

        }

    }
}
