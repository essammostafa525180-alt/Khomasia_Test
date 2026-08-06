using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetCount.Queries;

public class GetAllAssetCountQuery
: IQuery<Result<PagingSortingFiltering<AssetCountDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetCountQueryHandler :
    IQueryHandler<GetAllAssetCountQuery,
        Result<PagingSortingFiltering<AssetCountDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetCountQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetCountDetailsResponse>>> Handle(
        GetAllAssetCountQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetCountRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetCountDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetCountDetailsResponse>>.Success(result);
    }
}