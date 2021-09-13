using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Features.Commands.DeleteProduct
{
    public class DeleteProductCommand: IRequest
    {
        public int Id { get; set; }
    }
}
