using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemBudget.Queries;

public class GetAllInventoryItemBudgetQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemBudgetDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemBudgetQueryHandler :
    IQueryHandler<GetAllInventoryItemBudgetQuery,
        Result<PagingSortingFiltering<InventoryItemBudgetDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemBudgetQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemBudgetDetailsResponse>>> Handle(
        GetAllInventoryItemBudgetQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemBudgetRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemBudgetDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemBudgetDetailsResponse>>.Success(result);
    }
}