using Application.Common;
using Application.CQRS.Sharh.Queries;
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
    public class SharhsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SharhsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [MapToApiVersion(ApiVersions.V2)]
        [EnableETag]
        [HttpGet("{bookSharhId}/meta")]
        public async Task<IActionResult> GetMeta([FromRoute] int bookSharhId)
        {
            var query = new GetSharhBookMetaQuery { BookSharhId = bookSharhId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]
        [HttpGet("get-all-by-ClassificationId/{ClassificationId}")]
        public async Task<IActionResult> GetAll([FromRoute] int ClassificationId)
        {
            var query = new GetBookSharhByClassificationIdQuery { ClassificationId = ClassificationId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var query = new GetBookSharhByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [EnableETag]
        [HttpGet("get-by-bookId/{bookId}/hadithId/{hadithId}")]
        public async Task<IActionResult> GetAllBook([FromRoute] int bookId, [FromRoute] int hadithId)
        {
            var query = new GetHadithSharhByHadithIdQuery { BookId = bookId, HadithId = hadithId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]
        [HttpGet("get-by-HadithId/{hadithId}")]
        public async Task<IActionResult> GetAllBook([FromRoute] int hadithId)
        {
            var query = new GetBookSharhByHadithIdQuery { HadithId = hadithId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]
        [HttpGet("get-other-books-by-HadithId/{hadithId}")]
        public async Task<IActionResult> GetAllOtherBook([FromRoute] int hadithId)
        {
            var query = new GetOtherBookSharhByHadithIdQuery { HadithId = hadithId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [EnableETag]

        [HttpGet("{bookId}/get-all-bab/{babId}")]
        public async Task<IActionResult> GetAllSharh([FromRoute] int bookId, [FromRoute] int babId)
        {
            var query = new GetAllBabSharhQuery { BookId = bookId, BabId = babId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
