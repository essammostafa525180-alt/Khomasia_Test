using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemLocationBatchSerial.Queries;

public class GetAllInventoryItemLocationBatchSerialQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemLocationBatchSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemLocationBatchSerialQueryHandler :
    IQueryHandler<GetAllInventoryItemLocationBatchSerialQuery,
        Result<PagingSortingFiltering<InventoryItemLocationBatchSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemLocationBatchSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemLocationBatchSerialDetailsResponse>>> Handle(
        GetAllInventoryItemLocationBatchSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemLocationBatchSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemLocationBatchSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemLocationBatchSerialDetailsResponse>>.Success(result);
    }
}