using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ApplicationContext
{
    public class CqrsDbContext : DbContext
    {
        public CqrsDbContext(DbContextOptions<CqrsDbContext> options) : base(options)
        {
        }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasData
            (
                new Product { Id = 1, Name = "iPhone X" },
                new Product { Id = 2, Name = "Samsung S9" }
            );
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "lat";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "lat";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
