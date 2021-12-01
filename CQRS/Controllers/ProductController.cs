using CQRS.CQ.Commands;
using CQRS.CQ.Queries;
using Domain.Parameters;
using DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediatR)
        {
            _mediator = mediatR;
        }
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult>GetAllProducts([FromQuery] ProductParameters productParameters)
        {
            var query = new GetAllProductsQuery(productParameters);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [AllowAnonymous]
        [HttpGet("GetProductDetails")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var query = new GetProductByIdCommand(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("CreateProduct")]

        public async Task<ActionResult<bool>> CreateProduct([FromBody] ProductDTO productDTO)
        {
            var query = new CreateProductCommand(productDTO);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDTO dto)
        {
            var query = new UpdateProductCommand(dto);
            var result = await _mediator.Send(query);
            return Ok(result);
        }



        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var query = new DeleteProductCommand(id);
            var result = await _mediator.Send(query);
            return Ok(result);
            //todo paginatie/filter
        }
    }
}
