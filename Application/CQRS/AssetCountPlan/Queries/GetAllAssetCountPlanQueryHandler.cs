using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetCountPlan.Queries;

public class GetAllAssetCountPlanQuery
: IQuery<Result<PagingSortingFiltering<AssetCountPlanDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetCountPlanQueryHandler :
    IQueryHandler<GetAllAssetCountPlanQuery,
        Result<PagingSortingFiltering<AssetCountPlanDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetCountPlanQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetCountPlanDetailsResponse>>> Handle(
        GetAllAssetCountPlanQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetCountPlanRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetCountPlanDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetCountPlanDetailsResponse>>.Success(result);
    }
}