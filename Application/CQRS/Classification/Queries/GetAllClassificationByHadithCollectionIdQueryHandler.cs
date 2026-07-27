using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Classification.Queries
{
    public class GetAllClassificationByHadithCollectionIdQuery
 : IQuery<Result<PagingSortingFiltering<ClassificationListResponse>>>
    {
        public int HadithCollectionId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllClassificationByPartitionIdQueryHandler :
        IQueryHandler<GetAllClassificationByHadithCollectionIdQuery,
            Result<PagingSortingFiltering<ClassificationListResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClassificationByPartitionIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PagingSortingFiltering<ClassificationListResponse>>> Handle(
            GetAllClassificationByHadithCollectionIdQuery request,
            CancellationToken cancellationToken)
        {
            var classification = await _unitOfWork.ClassificationRepository.GetQueryable().AsNoTracking()
                                        .Where(c => c.HadithCollectionId == request.HadithCollectionId)
                                        .ProjectToType<ClassificationListResponse>()
                                        .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            return Result<PagingSortingFiltering<ClassificationListResponse>>.Success(classification);
        }
    }
}



