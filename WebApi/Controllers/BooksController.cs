using Application.Common;
using Application.CQRS.Books.Commands;
using Application.CQRS.Books.Queries;
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
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [EnableETag]

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBookQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var query = new GetBookByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [MapToApiVersion(ApiVersions.V2)]
        [EnableETag]
        [HttpGet("ByClassification")]
        public async Task<IActionResult> GetByClassificationId([FromQuery] GetAllBookByClassificationIdQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-all-by-ClassificationId/{classificationId}")]
        public async Task<IActionResult> GetAll([FromRoute] int classificationId)
        {
            var query = new GetAllBookByClassificationIdQuery { ClassificationId = classificationId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-details-with-babs/{bookId}")]
        public async Task<IActionResult> GetDetails([FromRoute] int bookId)
        {
            var query = new GetBookDetailsWithBabsQuery { Id = bookId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBookCommand { Id = id });

            return Ok(result);
        }
    }
}
