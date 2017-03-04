using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class UserConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {

            Map<Showroomer>(b => b.ToTable("Showroomer"));
            Map<Buyer>(ch => ch.ToTable("Buyer"));
            Map<User>(prod => prod.ToTable("User"));

            
        }
    }
}
