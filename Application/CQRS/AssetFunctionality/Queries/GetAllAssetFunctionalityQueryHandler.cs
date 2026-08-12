using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetFunctionality.Queries;

public class GetAllAssetFunctionalityQuery
: IQuery<Result<PagingSortingFiltering<AssetFunctionalityDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetFunctionalityQueryHandler :
    IQueryHandler<GetAllAssetFunctionalityQuery,
        Result<PagingSortingFiltering<AssetFunctionalityDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetFunctionalityQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetFunctionalityDetailsResponse>>> Handle(
        GetAllAssetFunctionalityQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetFunctionalityRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetFunctionalityDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetFunctionalityDetailsResponse>>.Success(result);
    }
}