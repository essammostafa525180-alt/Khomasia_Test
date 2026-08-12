using Application.CQRS.NotificationTemplateContact.Commands;
using Application.CQRS.NotificationTemplateContact.Queries;
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
    public class NotificationTemplateContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationTemplateContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [EnableETag]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllNotificationTemplateContactQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [EnableETag]
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetNotificationTemplateContactByIdQuery { Id = id });
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateNotificationTemplateContactCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateNotificationTemplateContactCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteNotificationTemplateContactCommand { Id = id });
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
    }
}