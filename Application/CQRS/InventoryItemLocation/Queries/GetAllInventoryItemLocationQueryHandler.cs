using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemLocation.Queries;

public class GetAllInventoryItemLocationQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemLocationDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemLocationQueryHandler :
    IQueryHandler<GetAllInventoryItemLocationQuery,
        Result<PagingSortingFiltering<InventoryItemLocationDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemLocationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemLocationDetailsResponse>>> Handle(
        GetAllInventoryItemLocationQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemLocationRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemLocationDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemLocationDetailsResponse>>.Success(result);
    }
}