using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.StockCountPlanStatus.Queries;

public class GetAllStockCountPlanStatusQuery
: IQuery<Result<PagingSortingFiltering<StockCountPlanStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllStockCountPlanStatusQueryHandler :
    IQueryHandler<GetAllStockCountPlanStatusQuery,
        Result<PagingSortingFiltering<StockCountPlanStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStockCountPlanStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<StockCountPlanStatusDetailsResponse>>> Handle(
        GetAllStockCountPlanStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.StockCountPlanStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<StockCountPlanStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<StockCountPlanStatusDetailsResponse>>.Success(result);
    }
}