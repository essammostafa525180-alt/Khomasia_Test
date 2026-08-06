using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryStockCountDetailBatch.Queries;

public class GetAllInventoryStockCountDetailBatchQuery
: IQuery<Result<PagingSortingFiltering<InventoryStockCountDetailBatchDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryStockCountDetailBatchQueryHandler :
    IQueryHandler<GetAllInventoryStockCountDetailBatchQuery,
        Result<PagingSortingFiltering<InventoryStockCountDetailBatchDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryStockCountDetailBatchQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryStockCountDetailBatchDetailsResponse>>> Handle(
        GetAllInventoryStockCountDetailBatchQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryStockCountDetailBatchRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryStockCountDetailBatchDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryStockCountDetailBatchDetailsResponse>>.Success(result);
    }
}