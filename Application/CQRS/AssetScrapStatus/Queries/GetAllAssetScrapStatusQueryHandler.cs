using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetScrapStatus.Queries;

public class GetAllAssetScrapStatusQuery
: IQuery<Result<PagingSortingFiltering<AssetScrapStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetScrapStatusQueryHandler :
    IQueryHandler<GetAllAssetScrapStatusQuery,
        Result<PagingSortingFiltering<AssetScrapStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetScrapStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetScrapStatusDetailsResponse>>> Handle(
        GetAllAssetScrapStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetScrapStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetScrapStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetScrapStatusDetailsResponse>>.Success(result);
    }
}