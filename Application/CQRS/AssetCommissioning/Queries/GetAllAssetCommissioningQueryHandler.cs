using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetCommissioning.Queries;

public class GetAllAssetCommissioningQuery
: IQuery<Result<PagingSortingFiltering<AssetCommissioningDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetCommissioningQueryHandler :
    IQueryHandler<GetAllAssetCommissioningQuery,
        Result<PagingSortingFiltering<AssetCommissioningDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetCommissioningQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetCommissioningDetailsResponse>>> Handle(
        GetAllAssetCommissioningQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetCommissioningRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetCommissioningDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetCommissioningDetailsResponse>>.Success(result);
    }
}