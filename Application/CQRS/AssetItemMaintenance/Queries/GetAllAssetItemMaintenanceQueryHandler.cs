using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetItemMaintenance.Queries;

public class GetAllAssetItemMaintenanceQuery
: IQuery<Result<PagingSortingFiltering<AssetItemMaintenanceDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetItemMaintenanceQueryHandler :
    IQueryHandler<GetAllAssetItemMaintenanceQuery,
        Result<PagingSortingFiltering<AssetItemMaintenanceDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetItemMaintenanceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetItemMaintenanceDetailsResponse>>> Handle(
        GetAllAssetItemMaintenanceQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetItemMaintenanceRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetItemMaintenanceDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetItemMaintenanceDetailsResponse>>.Success(result);
    }
}