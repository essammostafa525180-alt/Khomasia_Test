using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryStockCountPlan.Queries;

public class GetAllInventoryStockCountPlanQuery
: IQuery<Result<PagingSortingFiltering<InventoryStockCountPlanDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryStockCountPlanQueryHandler :
    IQueryHandler<GetAllInventoryStockCountPlanQuery,
        Result<PagingSortingFiltering<InventoryStockCountPlanDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryStockCountPlanQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryStockCountPlanDetailsResponse>>> Handle(
        GetAllInventoryStockCountPlanQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryStockCountPlanRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryStockCountPlanDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryStockCountPlanDetailsResponse>>.Success(result);
    }
}