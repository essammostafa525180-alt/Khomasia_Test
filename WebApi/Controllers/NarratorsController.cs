using Application.CQRS.Narrators.Queries;
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
    public class NarratorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NarratorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [EnableETag]

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllNarratorQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetNarratorByIdQuery query = new()
            {
                Id = id
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
