using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryTransfereDetailBatch.Queries;

public class GetAllInventoryTransfereDetailBatchQuery
: IQuery<Result<PagingSortingFiltering<InventoryTransfereDetailBatchDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryTransfereDetailBatchQueryHandler :
    IQueryHandler<GetAllInventoryTransfereDetailBatchQuery,
        Result<PagingSortingFiltering<InventoryTransfereDetailBatchDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryTransfereDetailBatchQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryTransfereDetailBatchDetailsResponse>>> Handle(
        GetAllInventoryTransfereDetailBatchQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryTransfereDetailBatchRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryTransfereDetailBatchDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryTransfereDetailBatchDetailsResponse>>.Success(result);
    }
}