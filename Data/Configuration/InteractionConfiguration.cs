using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class InteractionConfiguration :EntityTypeConfiguration<Interaction>
    {   public InteractionConfiguration(){
            Map<Comment>(b => b.ToTable("Comment"));
            Map<Rate>(ch => ch.ToTable("Rate"));
            Map<Interaction>(prod => prod.ToTable("Interaction"));
            HasKey(a => new { a.UserId, a.ProductId });
            HasRequired(a => a.Product).WithMany(a => a.Interactions).HasForeignKey(a => a.ProductId);
            HasRequired(a => a.User).WithMany(a => a.Interactions).HasForeignKey(a => a.UserId);
            
        }
    }
}
