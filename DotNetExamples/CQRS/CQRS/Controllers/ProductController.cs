using CQRS.Models;
using CQRS.Features.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Features.Commands.DeleteProduct;
using CQRS.Features.Commands.CreateProduct;
using CQRS.Features.Queries.GetProductById;

namespace CQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetProductQuery());
            return Ok(products);
        }

        [HttpGet(Name ="GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct([FromBody] Product product)
        {
            var result = await _mediator.Send(new CreateProductCommand(product));
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand() { Id = id});
            return NoContent();
        }
    }
}
