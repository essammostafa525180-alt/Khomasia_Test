using Application.CQRS.Bab.Commands;
using Application.CQRS.Bab.Queries;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BabsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BabsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [EnableETag]

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBabQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [EnableETag]

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetBabMeta([FromRoute] int id)
        {
            var query = new GetBabByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-all-by-bookId/{bookId}")]
        public async Task<IActionResult> GetAll([FromRoute] int bookId)
        {
            var query = new GetAllBabByBookIdQuery { BookId = bookId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBabCommand { Id = id });

            return Ok(result);
        }
    }
}
