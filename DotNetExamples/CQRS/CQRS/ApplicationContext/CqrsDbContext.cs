using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.ApplicationContext
{
    public class CqrsDbContext : DbContext
    {
        public CqrsDbContext(DbContextOptions<CqrsDbContext> options) : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
    }
}
