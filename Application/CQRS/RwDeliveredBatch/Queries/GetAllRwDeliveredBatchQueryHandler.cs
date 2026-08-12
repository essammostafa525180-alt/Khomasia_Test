using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.RwDeliveredBatch.Queries;

public class GetAllRwDeliveredBatchQuery
: IQuery<Result<PagingSortingFiltering<RwDeliveredBatchDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllRwDeliveredBatchQueryHandler :
    IQueryHandler<GetAllRwDeliveredBatchQuery,
        Result<PagingSortingFiltering<RwDeliveredBatchDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRwDeliveredBatchQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<RwDeliveredBatchDetailsResponse>>> Handle(
        GetAllRwDeliveredBatchQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RwDeliveredBatchRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<RwDeliveredBatchDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<RwDeliveredBatchDetailsResponse>>.Success(result);
    }
}