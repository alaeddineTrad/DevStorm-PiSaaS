using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class ShowroomConfiguration:EntityTypeConfiguration<Showroom>
    {
        public ShowroomConfiguration()
        {
            HasKey(a => new { a.ShowroomerId, a.ProductId });
            HasRequired(a => a.Showroomer).WithMany(a => a.Showrooms).HasForeignKey(a => a.ShowroomerId);
            HasRequired(a => a.Product).WithMany(a => a.Showrooms).HasForeignKey(a => a.ProductId);
        }
    }
}
