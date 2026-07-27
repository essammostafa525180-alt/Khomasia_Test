using Application.CQRS.Takhreej.Queries;
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
    public class TakheejsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TakheejsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [EnableETag]

        [HttpGet("get-by-hadithId/{hadithId}")]
        public async Task<IActionResult> GetAll([FromRoute] int hadithId)
        {
            var query = new GetAllTakhreejByHadithIdQuery { HadithId = hadithId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
