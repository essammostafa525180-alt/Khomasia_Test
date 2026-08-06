using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemSerial.Queries;

public class GetAllInventoryItemSerialQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemSerialQueryHandler :
    IQueryHandler<GetAllInventoryItemSerialQuery,
        Result<PagingSortingFiltering<InventoryItemSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemSerialDetailsResponse>>> Handle(
        GetAllInventoryItemSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemSerialDetailsResponse>>.Success(result);
    }
}