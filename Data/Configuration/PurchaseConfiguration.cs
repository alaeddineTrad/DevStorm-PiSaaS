using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class PurchaseConfiguration : EntityTypeConfiguration<Purchase>
    {public PurchaseConfiguration()
        {
            /*HasRequired(a => a.Buyer).WithMany(a => a.Purchases).HasForeignKey(a => a.UserId).WillCascadeOnDelete(true);
            HasRequired(a => a.Product).WithMany(a => a.Purchases).HasForeignKey(a => a.ProductId).WillCascadeOnDelete(true);*/

        }
    }
}
