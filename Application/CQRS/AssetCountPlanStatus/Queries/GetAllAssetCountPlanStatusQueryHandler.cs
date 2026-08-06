using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetCountPlanStatus.Queries;

public class GetAllAssetCountPlanStatusQuery
: IQuery<Result<PagingSortingFiltering<AssetCountPlanStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetCountPlanStatusQueryHandler :
    IQueryHandler<GetAllAssetCountPlanStatusQuery,
        Result<PagingSortingFiltering<AssetCountPlanStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetCountPlanStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetCountPlanStatusDetailsResponse>>> Handle(
        GetAllAssetCountPlanStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetCountPlanStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetCountPlanStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetCountPlanStatusDetailsResponse>>.Success(result);
    }
}