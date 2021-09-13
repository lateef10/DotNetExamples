using CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Features.Queries.GetAllProducts
{
    public class GetProductQuery : IRequest<IEnumerable<Product>>
    {
    }
}
