using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetDisposed.Queries;

public class GetAllAssetDisposedQuery
: IQuery<Result<PagingSortingFiltering<AssetDisposedDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetDisposedQueryHandler :
    IQueryHandler<GetAllAssetDisposedQuery,
        Result<PagingSortingFiltering<AssetDisposedDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetDisposedQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetDisposedDetailsResponse>>> Handle(
        GetAllAssetDisposedQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetDisposedRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetDisposedDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetDisposedDetailsResponse>>.Success(result);
    }
}