using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.StockCountPlanType.Queries;

public class GetAllStockCountPlanTypeQuery
: IQuery<Result<PagingSortingFiltering<StockCountPlanTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllStockCountPlanTypeQueryHandler :
    IQueryHandler<GetAllStockCountPlanTypeQuery,
        Result<PagingSortingFiltering<StockCountPlanTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStockCountPlanTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<StockCountPlanTypeDetailsResponse>>> Handle(
        GetAllStockCountPlanTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.StockCountPlanTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<StockCountPlanTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<StockCountPlanTypeDetailsResponse>>.Success(result);
    }
}