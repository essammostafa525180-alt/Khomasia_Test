using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryStockCountPlanDetail.Queries;

public class GetAllInventoryStockCountPlanDetailQuery
: IQuery<Result<PagingSortingFiltering<InventoryStockCountPlanDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryStockCountPlanDetailQueryHandler :
    IQueryHandler<GetAllInventoryStockCountPlanDetailQuery,
        Result<PagingSortingFiltering<InventoryStockCountPlanDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryStockCountPlanDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryStockCountPlanDetailDetailsResponse>>> Handle(
        GetAllInventoryStockCountPlanDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryStockCountPlanDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryStockCountPlanDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryStockCountPlanDetailDetailsResponse>>.Success(result);
    }
}