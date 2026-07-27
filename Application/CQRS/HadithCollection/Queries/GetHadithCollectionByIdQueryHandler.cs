using Application.Abstractions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.HadithCollection.Queries
{
    public class GetHadithCollectionByIdQuery
 : IQuery<Result<HadithCollectionDetailsResponse>>
    {
        public int Id { get; set; }
    }
    public class GetHadithCollectionByIdQueryHandler
         : IQueryHandler<GetHadithCollectionByIdQuery, Result<HadithCollectionDetailsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHadithCollectionByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<HadithCollectionDetailsResponse>> Handle(
            GetHadithCollectionByIdQuery request,
            CancellationToken cancellationToken)
        {
            var hadithCollection = await _unitOfWork.HadithCollectionRepository
                .GetQueryable()
                .Include(hc => hc.Classifications)
                .OrderBy(hc => hc.Id)
                .AsSplitQuery()
                .FirstOrDefaultAsync(hc => hc.Id == request.Id, cancellationToken);

            if (hadithCollection is null)
                return Result<HadithCollectionDetailsResponse>.Failure(Errors.HadithCollectionNotFound);

            var response = hadithCollection.Adapt<HadithCollectionDetailsResponse>();

            return Result<HadithCollectionDetailsResponse>.Success(response);
        }
    }
}




