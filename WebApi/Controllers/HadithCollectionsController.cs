using Application.CQRS.HadithCollection.Queries;
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
    public class HadithCollectionsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public HadithCollectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [EnableETag]

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllHadithCollectionsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var query = new GetHadithCollectionByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-all-by-partitionId/{partitionId}")]
        public async Task<IActionResult> GetAll([FromRoute] int partitionId)
        {
            var query = new GetAllHadithCollectionByPartitionIdQuery { PartitionId = partitionId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        //[HttpDelete("delete/{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _mediator.Send(new DeleteHadithCommand { Id = id });

        //    return Ok(result);
        //}
        //[HttpGet("GetById/{id}")]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    GetOrganizationByIdQuery query = new()
        //    {
        //        Id = id
        //    };
        //    var result = await _mediator.Send(query);

        //    return Ok(result);
        //}
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



