using CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Features.Commands.CreateProduct
{
    public record CreateProductCommand(Product product) : IRequest<int>
    {
    }
}
