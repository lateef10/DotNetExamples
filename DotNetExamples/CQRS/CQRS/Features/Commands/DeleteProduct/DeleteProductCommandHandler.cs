using CQRS.Models;
using CQRS.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace CQRS.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepository.GetProductById(request.Id);

            if(productToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            await _productRepository.DeleteProductById(productToDelete);

            return Unit.Value; //Default return for void in MediatR
        }
    }
}
