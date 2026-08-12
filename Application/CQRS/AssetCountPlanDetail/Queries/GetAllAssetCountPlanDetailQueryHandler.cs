using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetCountPlanDetail.Queries;

public class GetAllAssetCountPlanDetailQuery
: IQuery<Result<PagingSortingFiltering<AssetCountPlanDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetCountPlanDetailQueryHandler :
    IQueryHandler<GetAllAssetCountPlanDetailQuery,
        Result<PagingSortingFiltering<AssetCountPlanDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetCountPlanDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetCountPlanDetailDetailsResponse>>> Handle(
        GetAllAssetCountPlanDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetCountPlanDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetCountPlanDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetCountPlanDetailDetailsResponse>>.Success(result);
    }
}