using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemEquivalentSp.Queries;

public class GetAllInventoryItemEquivalentSpQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemEquivalentSpDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemEquivalentSpQueryHandler :
    IQueryHandler<GetAllInventoryItemEquivalentSpQuery,
        Result<PagingSortingFiltering<InventoryItemEquivalentSpDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemEquivalentSpQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemEquivalentSpDetailsResponse>>> Handle(
        GetAllInventoryItemEquivalentSpQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemEquivalentSpRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemEquivalentSpDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemEquivalentSpDetailsResponse>>.Success(result);
    }
}