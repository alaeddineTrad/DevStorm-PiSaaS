using Data.Configuration;
using Data.CostumConvention;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Context : DbContext
    {
        public Context() : base("name=Alias")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<CommentReview> CommentReviews { get; set; }
        public DbSet<RateReview> RateReviews { get; set; }
        public DbSet<Image> Images { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new InteractionConfiguration());
            modelBuilder.Configurations.Add(new ReviewConfiguration());
            modelBuilder.Configurations.Add(new PurchaseConfiguration());
            modelBuilder.Conventions.Add(new DateTime2());
        }


    }
}
