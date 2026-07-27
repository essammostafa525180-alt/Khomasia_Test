using Application.Abstractions;
using Application.Common;
using Application.Extensions;
using Application.Response;
using Domain.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Hadiths.Queries
{
    public class SearchByHadithTextQuery
        : IQuery<Result<PagingSortingFiltering<SearchResultResponse>>>
    {
        public string HadithText { get; set; }
        public int? ClassifcationId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class SearchByHadithTextQueryHandler
    : IQueryHandler<SearchByHadithTextQuery, Result<PagingSortingFiltering<SearchResultResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchByHadithTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PagingSortingFiltering<SearchResultResponse>>> Handle(
     SearchByHadithTextQuery request,
     CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.HadithText))
                return Result<PagingSortingFiltering<SearchResultResponse>>
                    .Failure("HadithText is required.");

            var detectedLanguage = LanguageDetector.Detect(request.HadithText.Trim());

            PagingSortingFiltering<SearchResultResponse> result;

            if (detectedLanguage == DetectedLanguage.Arabic)
            {
                var hadithText = LanguageDetector.RemoveDiacritics(request.HadithText.Trim());

                result = await _unitOfWork.HadithRepository
                    .GetQueryable()
                    .AsNoTracking()
                    .Where(h =>
                        EF.Functions.Like(h.HadithWithNoSign, $"%{hadithText}%") &&
                        (!request.ClassifcationId.HasValue ||
                         h.Bab.Book.ClassificationId == request.ClassifcationId.Value)
                    )
                    .OrderBy(h => h.Id)
                    .AsSplitQuery()
                    .ProjectToType<SearchResultResponse>()
                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);
            }
            else
            {
                result = await _unitOfWork.HadithTranslationRepository
                    .GetQueryable()
                    .AsNoTracking()
                    .Where(t =>
                        EF.Functions.Like(t.Content, $"%{request.HadithText}%") &&
                        (!request.ClassifcationId.HasValue ||
                         t.Hadith.Bab.Book.ClassificationId == request.ClassifcationId.Value)
                    )
                    .Select(t => t.Hadith)
                    .OrderBy(h => h.Id)
                    .AsSplitQuery()
                    .ProjectToType<SearchResultResponse>()
                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);
            }

            return Result<PagingSortingFiltering<SearchResultResponse>>.Success(result);
        }

    }
}