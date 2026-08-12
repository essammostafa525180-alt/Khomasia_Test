using Application.CQRS.Scope.Commands;
using Application.CQRS.Scope.Queries;
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
    public class ScopeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ScopeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [EnableETag]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllScopeQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [EnableETag]
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetScopeByIdQuery { Id = id });
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateScopeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateScopeCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteScopeCommand { Id = id });
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
    }
}