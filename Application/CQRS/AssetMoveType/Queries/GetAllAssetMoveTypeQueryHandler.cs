using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetMoveType.Queries;

public class GetAllAssetMoveTypeQuery
: IQuery<Result<PagingSortingFiltering<AssetMoveTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetMoveTypeQueryHandler :
    IQueryHandler<GetAllAssetMoveTypeQuery,
        Result<PagingSortingFiltering<AssetMoveTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetMoveTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetMoveTypeDetailsResponse>>> Handle(
        GetAllAssetMoveTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetMoveTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetMoveTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetMoveTypeDetailsResponse>>.Success(result);
    }
}