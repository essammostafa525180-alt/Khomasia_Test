using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Hadiths.Queries
{
    public class GetHadithsByBabIdQuery : IQuery<Result<PagingSortingFiltering<HadithListResponse>>>
    {
        public int BabId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetHadithsByBabIdQueryHandler :
        IQueryHandler<GetHadithsByBabIdQuery, Result<PagingSortingFiltering<HadithListResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _http;

        public GetHadithsByBabIdQueryHandler(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor http)
        {
            _unitOfWork = unitOfWork;
            _http = http;
        }

        public async Task<Result<PagingSortingFiltering<HadithListResponse>>> Handle(
            GetHadithsByBabIdQuery request,
            CancellationToken cancellationToken)
        {
            var httpRequest = _http.HttpContext!.Request;
            var baseAudioUrl = $"{httpRequest.Scheme}://{httpRequest.Host}/api/v2/hadith/audio/";

            var result = await _unitOfWork.HadithRepository
     .GetQueryable()
     .AsNoTracking()
     .Where(h => h.BabId == request.BabId)
     .Select(h => new HadithListResponse
     {
         Id = h.Id,
         Matn = h.Matn,
         HadithWithSign = h.HadithWithSign,
         HadithWithNoSign = h.HadithWithNoSign,
         AudioUrl = !string.IsNullOrEmpty(h.AudioUrl)
                             ? baseAudioUrl + h.Id + ".mp3"
                             : null,
         HadithNumber = h.HadithNumber,
     })
     .OrderBy(h => h.HadithNumber)
     .ThenBy(h => h.Id)
     .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            return Result<PagingSortingFiltering<HadithListResponse>>.Success(result);
        }
    }
}