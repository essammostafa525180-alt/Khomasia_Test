using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryStockCount.Queries;

public class GetAllInventoryStockCountQuery
: IQuery<Result<PagingSortingFiltering<InventoryStockCountDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryStockCountQueryHandler :
    IQueryHandler<GetAllInventoryStockCountQuery,
        Result<PagingSortingFiltering<InventoryStockCountDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryStockCountQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryStockCountDetailsResponse>>> Handle(
        GetAllInventoryStockCountQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryStockCountRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryStockCountDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryStockCountDetailsResponse>>.Success(result);
    }
}