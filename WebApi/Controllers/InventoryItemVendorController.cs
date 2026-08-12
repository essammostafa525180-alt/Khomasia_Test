using Application.CQRS.InventoryItemVendor.Commands;
using Application.CQRS.InventoryItemVendor.Queries;
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
    public class InventoryItemVendorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InventoryItemVendorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [EnableETag]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllInventoryItemVendorQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [EnableETag]
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetInventoryItemVendorByIdQuery { Id = id });
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateInventoryItemVendorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateInventoryItemVendorCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteInventoryItemVendorCommand { Id = id });
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
    }
}