using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemTrasnsactionType.Queries;

public class GetAllInventoryItemTrasnsactionTypeQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemTrasnsactionTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemTrasnsactionTypeQueryHandler :
    IQueryHandler<GetAllInventoryItemTrasnsactionTypeQuery,
        Result<PagingSortingFiltering<InventoryItemTrasnsactionTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemTrasnsactionTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemTrasnsactionTypeDetailsResponse>>> Handle(
        GetAllInventoryItemTrasnsactionTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemTrasnsactionTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemTrasnsactionTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemTrasnsactionTypeDetailsResponse>>.Success(result);
    }
}