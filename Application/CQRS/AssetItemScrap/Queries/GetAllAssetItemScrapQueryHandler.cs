using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetItemScrap.Queries;

public class GetAllAssetItemScrapQuery
: IQuery<Result<PagingSortingFiltering<AssetItemScrapDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetItemScrapQueryHandler :
    IQueryHandler<GetAllAssetItemScrapQuery,
        Result<PagingSortingFiltering<AssetItemScrapDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetItemScrapQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetItemScrapDetailsResponse>>> Handle(
        GetAllAssetItemScrapQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetItemScrapRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetItemScrapDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetItemScrapDetailsResponse>>.Success(result);
    }
}