using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemTransactionType.Queries;

public class GetAllInventoryItemTransactionTypeQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemTransactionTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemTransactionTypeQueryHandler :
    IQueryHandler<GetAllInventoryItemTransactionTypeQuery,
        Result<PagingSortingFiltering<InventoryItemTransactionTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemTransactionTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemTransactionTypeDetailsResponse>>> Handle(
        GetAllInventoryItemTransactionTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemTransactionTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemTransactionTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemTransactionTypeDetailsResponse>>.Success(result);
    }
}