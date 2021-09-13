using CQRS.ApplicationContext;
using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CqrsDbContext _dbContext;

        public ProductRepository(CqrsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var res = await _dbContext.products.ToListAsync();
            return res;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.products.FindAsync(id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _dbContext.products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProductById(Product product)
        {
            _dbContext.products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
