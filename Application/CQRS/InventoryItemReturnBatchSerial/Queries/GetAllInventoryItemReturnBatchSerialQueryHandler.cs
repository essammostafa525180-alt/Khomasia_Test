using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemReturnBatchSerial.Queries;

public class GetAllInventoryItemReturnBatchSerialQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemReturnBatchSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemReturnBatchSerialQueryHandler :
    IQueryHandler<GetAllInventoryItemReturnBatchSerialQuery,
        Result<PagingSortingFiltering<InventoryItemReturnBatchSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemReturnBatchSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemReturnBatchSerialDetailsResponse>>> Handle(
        GetAllInventoryItemReturnBatchSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemReturnBatchSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemReturnBatchSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemReturnBatchSerialDetailsResponse>>.Success(result);
    }
}