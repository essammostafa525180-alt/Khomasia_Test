using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetCountPlanType.Queries;

public class GetAllAssetCountPlanTypeQuery
: IQuery<Result<PagingSortingFiltering<AssetCountPlanTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetCountPlanTypeQueryHandler :
    IQueryHandler<GetAllAssetCountPlanTypeQuery,
        Result<PagingSortingFiltering<AssetCountPlanTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetCountPlanTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetCountPlanTypeDetailsResponse>>> Handle(
        GetAllAssetCountPlanTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetCountPlanTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetCountPlanTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetCountPlanTypeDetailsResponse>>.Success(result);
    }
}