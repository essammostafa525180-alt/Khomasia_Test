using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemReturnBatch.Queries;

public class GetAllInventoryItemReturnBatchQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemReturnBatchDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemReturnBatchQueryHandler :
    IQueryHandler<GetAllInventoryItemReturnBatchQuery,
        Result<PagingSortingFiltering<InventoryItemReturnBatchDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemReturnBatchQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemReturnBatchDetailsResponse>>> Handle(
        GetAllInventoryItemReturnBatchQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemReturnBatchRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemReturnBatchDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemReturnBatchDetailsResponse>>.Success(result);
    }
}