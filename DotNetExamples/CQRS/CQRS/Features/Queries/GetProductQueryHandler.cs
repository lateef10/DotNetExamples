using CQRS.Models;
using CQRS.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Features.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllProducts();
        }
    }
}
