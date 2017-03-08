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

        //[Key]
        //[Column(Order = 1)]
        //[Key]
        public int PurchaseId { get; set; }
        //[ForeignKey("UserId")]

        //[ForeignKey("ProductId")]
        //[Column(Order = 2)]
        public DateTime DatePurchase { get; set; }
        public Double Total { get; set; }
        public String  Status { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
