using Application.CQRS.Bab.Commands;
using Application.CQRS.Partations;
using Application.CQRS.Partations.Queries;
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
    public class PartitionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PartitionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [EnableETag]

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPartationsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetPartationByIdQuery query = new()
            {
                Id = id
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        //[HttpPost("Create")]
        //public async Task<IActionResult> Create([FromBody] CreatePartationCommand command)
        //{
        //    var result = await _mediator.Send(command);

        //    return Ok(result);
        //}

        //[HttpPost("Update")]
        //public async Task<IActionResult> Update([FromBody] UpdateOrganizationCommand command)
        //{
        //    var result = await _mediator.Send(command);

        //    return Ok(result);
        //}

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePartitionCommand { Id = id });

            return Ok(result);
        }

    }
}
