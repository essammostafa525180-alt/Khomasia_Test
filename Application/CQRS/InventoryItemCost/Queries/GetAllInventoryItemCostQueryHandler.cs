using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemCost.Queries;

public class GetAllInventoryItemCostQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemCostDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemCostQueryHandler :
    IQueryHandler<GetAllInventoryItemCostQuery,
        Result<PagingSortingFiltering<InventoryItemCostDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemCostQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemCostDetailsResponse>>> Handle(
        GetAllInventoryItemCostQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemCostRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemCostDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemCostDetailsResponse>>.Success(result);
    }
}