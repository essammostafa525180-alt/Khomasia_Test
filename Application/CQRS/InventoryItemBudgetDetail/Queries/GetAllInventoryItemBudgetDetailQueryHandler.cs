using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemBudgetDetail.Queries;

public class GetAllInventoryItemBudgetDetailQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemBudgetDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemBudgetDetailQueryHandler :
    IQueryHandler<GetAllInventoryItemBudgetDetailQuery,
        Result<PagingSortingFiltering<InventoryItemBudgetDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemBudgetDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemBudgetDetailDetailsResponse>>> Handle(
        GetAllInventoryItemBudgetDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemBudgetDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemBudgetDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemBudgetDetailDetailsResponse>>.Success(result);
    }
}