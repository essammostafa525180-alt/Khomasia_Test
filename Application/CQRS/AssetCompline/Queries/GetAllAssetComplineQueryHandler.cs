using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetCompline.Queries;

public class GetAllAssetComplineQuery
: IQuery<Result<PagingSortingFiltering<AssetComplineDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetComplineQueryHandler :
    IQueryHandler<GetAllAssetComplineQuery,
        Result<PagingSortingFiltering<AssetComplineDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetComplineQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetComplineDetailsResponse>>> Handle(
        GetAllAssetComplineQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetComplineRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetComplineDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetComplineDetailsResponse>>.Success(result);
    }
}