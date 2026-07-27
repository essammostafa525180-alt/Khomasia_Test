using Application.Abstractions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Hadiths.Queries
{
    public class GetHadithTranslationQuery
: IQuery<Result<HadithTranslationResponse>>
    {
        public int LanguageId { get; set; }
        public int HadithId { get; set; }
    }
    public class GetHadithTranslationQueryHandler
         : IQueryHandler<GetHadithTranslationQuery, Result<HadithTranslationResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHadithTranslationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<HadithTranslationResponse>> Handle(
            GetHadithTranslationQuery request,
            CancellationToken cancellationToken)
        {
            var hadith = await _unitOfWork.HadithTranslationRepository
                .GetQueryable()
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    ht => ht.LanguageId == request.LanguageId
                    && ht.HadithId == request.HadithId,
                    cancellationToken);

            if (hadith is null)
                return Result<HadithTranslationResponse>.Failure(Errors.HadithNotFound);

            var response = hadith.Adapt<HadithTranslationResponse>();

            return Result<HadithTranslationResponse>.Success(response);
        }
    }
}




