using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class ReviewConfiguration : EntityTypeConfiguration<Review>
    {
        public ReviewConfiguration()
        {
            Map<CommentReview>(b => b.ToTable("CommentReview"));
            Map<RateReview>(ch => ch.ToTable("RateReview"));
            Map<Review>(prod => prod.ToTable("Review"));
            HasKey(a => new { a.BuyerId, a.ShowroomerId });
            HasRequired(a => a.Buyer).WithMany(a => a.Reviews).HasForeignKey(a => a.BuyerId);
            HasRequired(a => a.Showroomer).WithMany(a => a.Reviews).HasForeignKey(a => a.ShowroomerId);

        }
    }
}
