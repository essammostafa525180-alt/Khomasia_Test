using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemLocationBatch.Queries;

public class GetAllInventoryItemLocationBatchQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemLocationBatchDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemLocationBatchQueryHandler :
    IQueryHandler<GetAllInventoryItemLocationBatchQuery,
        Result<PagingSortingFiltering<InventoryItemLocationBatchDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemLocationBatchQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemLocationBatchDetailsResponse>>> Handle(
        GetAllInventoryItemLocationBatchQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemLocationBatchRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemLocationBatchDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemLocationBatchDetailsResponse>>.Success(result);
    }
}