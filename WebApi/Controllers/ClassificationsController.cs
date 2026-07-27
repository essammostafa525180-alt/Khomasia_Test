using Application.Common;
using Application.CQRS.Bab.Commands;
using Application.CQRS.Classification.Queries;
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
    public class ClassificationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClassificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [EnableETag]

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllClassificationsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-by-id/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetClassificationByIdQuery query = new()
            {
                Id = id
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [MapToApiVersion(ApiVersions.V2)]
        [EnableETag]

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdV2(int id)
        {
            GetClassificationViewByIdQuery query = new()
            {
                Id = id
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-auther-info-by-id/{id:int}")]
        public async Task<IActionResult> GetInf(int id)
        {
            GetAuthorDetialsByIdQuery query = new()
            {
                Id = id
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-all-by-hadithCollectionId/{hadithCollectionId}")]
        public async Task<IActionResult> GetAll(int hadithCollectionId)
        {
            GetAllClassificationByHadithCollectionIdQuery query = new()
            {
                HadithCollectionId = hadithCollectionId
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteClassificationCommand { Id = id });

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



    }
}

