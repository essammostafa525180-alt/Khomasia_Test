using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryStockCountStatus.Queries;

public class GetAllInventoryStockCountStatusQuery
: IQuery<Result<PagingSortingFiltering<InventoryStockCountStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryStockCountStatusQueryHandler :
    IQueryHandler<GetAllInventoryStockCountStatusQuery,
        Result<PagingSortingFiltering<InventoryStockCountStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryStockCountStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryStockCountStatusDetailsResponse>>> Handle(
        GetAllInventoryStockCountStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryStockCountStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryStockCountStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryStockCountStatusDetailsResponse>>.Success(result);
    }
}