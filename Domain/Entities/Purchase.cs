using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Purchase
    {
        

        private DateTime date;
        private float total;
        //[Key]
        //[Column(Order = 1)]
        public int UserId { get; set; }
        //[Key]
        //[Column(Order = 2)]
        public int ProductId { get; set; }
        //[ForeignKey("UserId")]
        public virtual Buyer Buyer { get; set; }
        //[ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public float Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
    }
}
