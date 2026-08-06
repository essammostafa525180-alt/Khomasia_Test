using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetItem.Queries;

public class GetAllAssetItemQuery
: IQuery<Result<PagingSortingFiltering<AssetItemDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetItemQueryHandler :
    IQueryHandler<GetAllAssetItemQuery,
        Result<PagingSortingFiltering<AssetItemDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetItemQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetItemDetailsResponse>>> Handle(
        GetAllAssetItemQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetItemRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetItemDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetItemDetailsResponse>>.Success(result);
    }
}