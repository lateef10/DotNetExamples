using CQRS.ApplicationContext;
using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(CqrsDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            var productList = await _dbContext.products.Where(p => p.Name == name).ToListAsync();
            return productList;
        }
    }
}
