using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace icemaoCN.Models
{
    public class IceContext: IdentityDbContext<User>
    {
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>(e => {

            });
            builder.Entity<Article>(e =>
            {
                e.HasIndex(x => x.Time);
                e.HasIndex(x => x.Category);
            });
        }
    }
}
