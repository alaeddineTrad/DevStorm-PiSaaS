using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Showroom
    {
        [Key]
        [Column(Order = 1)]
        public int ShowroomerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }
        [ForeignKey("ShowroomerId")]
        public virtual Showroomer Showroomer { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

       
    }
}
