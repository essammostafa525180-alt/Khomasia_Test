using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.HadithCollection.Queries
{
    public class GetAllHadithCollectionByPartitionIdQuery
   : IQuery<Result<PagingSortingFiltering<HadithCollectionLookupResponse>>>
    {
        public int PartitionId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = int.MaxValue;
    }
    public class GetAllHadithCollectionByPartitionIdQueryHandler :
        IQueryHandler<GetAllHadithCollectionByPartitionIdQuery,
            Result<PagingSortingFiltering<HadithCollectionLookupResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllHadithCollectionByPartitionIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PagingSortingFiltering<HadithCollectionLookupResponse>>> Handle(
            GetAllHadithCollectionByPartitionIdQuery request,
            CancellationToken cancellationToken)
        {
            var hadithCollection = await _unitOfWork.HadithCollectionRepository.GetQueryable()
                                        .AsNoTracking()
                                        .Where(h => h.PartationId == request.PartitionId)
                                        .OrderBy(h => h.Id)
                                        .AsSplitQuery()
                                        .ProjectToType<HadithCollectionLookupResponse>()
                                        .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            return Result<PagingSortingFiltering<HadithCollectionLookupResponse>>.Success(hadithCollection);
        }
    }
}


