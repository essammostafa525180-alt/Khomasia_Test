using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemReturnSerial.Queries;

public class GetAllInventoryItemReturnSerialQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemReturnSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemReturnSerialQueryHandler :
    IQueryHandler<GetAllInventoryItemReturnSerialQuery,
        Result<PagingSortingFiltering<InventoryItemReturnSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemReturnSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemReturnSerialDetailsResponse>>> Handle(
        GetAllInventoryItemReturnSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemReturnSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemReturnSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemReturnSerialDetailsResponse>>.Success(result);
    }
}