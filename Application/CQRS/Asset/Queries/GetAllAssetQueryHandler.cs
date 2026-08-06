using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Asset.Queries;

public class GetAllAssetQuery
: IQuery<Result<PagingSortingFiltering<AssetDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetQueryHandler :
    IQueryHandler<GetAllAssetQuery,
        Result<PagingSortingFiltering<AssetDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetDetailsResponse>>> Handle(
        GetAllAssetQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetDetailsResponse>>.Success(result);
    }
}