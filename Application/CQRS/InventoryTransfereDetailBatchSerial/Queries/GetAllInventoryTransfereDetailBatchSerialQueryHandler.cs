using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryTransfereDetailBatchSerial.Queries;

public class GetAllInventoryTransfereDetailBatchSerialQuery
: IQuery<Result<PagingSortingFiltering<InventoryTransfereDetailBatchSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryTransfereDetailBatchSerialQueryHandler :
    IQueryHandler<GetAllInventoryTransfereDetailBatchSerialQuery,
        Result<PagingSortingFiltering<InventoryTransfereDetailBatchSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryTransfereDetailBatchSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryTransfereDetailBatchSerialDetailsResponse>>> Handle(
        GetAllInventoryTransfereDetailBatchSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryTransfereDetailBatchSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryTransfereDetailBatchSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryTransfereDetailBatchSerialDetailsResponse>>.Success(result);
    }
}