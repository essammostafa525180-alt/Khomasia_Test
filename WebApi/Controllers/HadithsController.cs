using Application.Common;
using Application.CQRS.Hadiths.Queries;
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
    public class HadithsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HadithsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [EnableETag]

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchByHadithTextQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [MapToApiVersion(ApiVersions.V2)]
        [EnableETag]
        [HttpGet("{babId}/meta")]
        public async Task<IActionResult> GetHadithMeta([FromRoute] int babId)
        {
            var query = new GetHadithMetaQuery { Id = babId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [MapToApiVersion(ApiVersions.V2)]
        [EnableETag]

        [HttpGet()]
        public async Task<IActionResult> GetByBabId([FromQuery] GetHadithsByBabIdQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("get-audio/{fileName}")]
        public async Task<IActionResult> GetAudio(string fileName)
        {
            var result = await _mediator.Send(
                new GetHadithAudioQuery { FileName = fileName }
            );

            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.ErrorMessage);

            return result.Data;
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var query = new GetHadithByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-by-lang/{languageId}/hadith/{hadithId}")]
        public async Task<IActionResult> GetHadithLang([FromRoute] int languageId, [FromRoute] int hadithId)
        {
            var query = new GetHadithTranslationQuery { LanguageId = languageId, HadithId = hadithId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("get-all-by-babId/{babId}")]
        public async Task<IActionResult> GetAll([FromRoute] int babId)
        {
            var query = new GetAllHadithByBabIdQuery { BabId = babId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        //[HttpDelete("delete/{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _mediator.Send(new DeleteHadithCommand { Id = id });

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



