using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryStockCountDetailBatchSerial.Queries;

public class GetAllInventoryStockCountDetailBatchSerialQuery
: IQuery<Result<PagingSortingFiltering<InventoryStockCountDetailBatchSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryStockCountDetailBatchSerialQueryHandler :
    IQueryHandler<GetAllInventoryStockCountDetailBatchSerialQuery,
        Result<PagingSortingFiltering<InventoryStockCountDetailBatchSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryStockCountDetailBatchSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryStockCountDetailBatchSerialDetailsResponse>>> Handle(
        GetAllInventoryStockCountDetailBatchSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryStockCountDetailBatchSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryStockCountDetailBatchSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryStockCountDetailBatchSerialDetailsResponse>>.Success(result);
    }
}