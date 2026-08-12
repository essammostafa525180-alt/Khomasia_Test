using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetCountDetail.Queries;

public class GetAllAssetCountDetailQuery
: IQuery<Result<PagingSortingFiltering<AssetCountDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetCountDetailQueryHandler :
    IQueryHandler<GetAllAssetCountDetailQuery,
        Result<PagingSortingFiltering<AssetCountDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetCountDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetCountDetailDetailsResponse>>> Handle(
        GetAllAssetCountDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetCountDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetCountDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetCountDetailDetailsResponse>>.Success(result);
    }
}