using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetMaintenanceStatus.Queries;

public class GetAllAssetMaintenanceStatusQuery
: IQuery<Result<PagingSortingFiltering<AssetMaintenanceStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetMaintenanceStatusQueryHandler :
    IQueryHandler<GetAllAssetMaintenanceStatusQuery,
        Result<PagingSortingFiltering<AssetMaintenanceStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetMaintenanceStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetMaintenanceStatusDetailsResponse>>> Handle(
        GetAllAssetMaintenanceStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetMaintenanceStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetMaintenanceStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetMaintenanceStatusDetailsResponse>>.Success(result);
    }
}