using CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Features.Queries.GetProductById
{
    public record GetProductByIdQuery(int id) : IRequest<Product>
    {
    }
}
