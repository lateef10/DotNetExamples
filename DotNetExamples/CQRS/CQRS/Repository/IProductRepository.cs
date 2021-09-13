using CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task DeleteProductById(Product product);
    }
}
