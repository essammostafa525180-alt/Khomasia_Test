using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetComponent.Queries;

public class GetAllAssetComponentQuery
: IQuery<Result<PagingSortingFiltering<AssetComponentDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetComponentQueryHandler :
    IQueryHandler<GetAllAssetComponentQuery,
        Result<PagingSortingFiltering<AssetComponentDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetComponentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetComponentDetailsResponse>>> Handle(
        GetAllAssetComponentQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetComponentRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetComponentDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetComponentDetailsResponse>>.Success(result);
    }
}