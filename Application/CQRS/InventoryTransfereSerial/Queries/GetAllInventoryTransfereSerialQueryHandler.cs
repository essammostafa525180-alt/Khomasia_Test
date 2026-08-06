using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryTransfereSerial.Queries;

public class GetAllInventoryTransfereSerialQuery
: IQuery<Result<PagingSortingFiltering<InventoryTransfereSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryTransfereSerialQueryHandler :
    IQueryHandler<GetAllInventoryTransfereSerialQuery,
        Result<PagingSortingFiltering<InventoryTransfereSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryTransfereSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryTransfereSerialDetailsResponse>>> Handle(
        GetAllInventoryTransfereSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryTransfereSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryTransfereSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryTransfereSerialDetailsResponse>>.Success(result);
    }
}