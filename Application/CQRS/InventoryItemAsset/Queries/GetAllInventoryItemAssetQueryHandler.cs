using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemAsset.Queries;

public class GetAllInventoryItemAssetQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemAssetDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemAssetQueryHandler :
    IQueryHandler<GetAllInventoryItemAssetQuery,
        Result<PagingSortingFiltering<InventoryItemAssetDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemAssetQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemAssetDetailsResponse>>> Handle(
        GetAllInventoryItemAssetQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemAssetRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemAssetDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemAssetDetailsResponse>>.Success(result);
    }
}