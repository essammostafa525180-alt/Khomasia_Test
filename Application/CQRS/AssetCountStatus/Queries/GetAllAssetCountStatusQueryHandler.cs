using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetCountStatus.Queries;

public class GetAllAssetCountStatusQuery
: IQuery<Result<PagingSortingFiltering<AssetCountStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetCountStatusQueryHandler :
    IQueryHandler<GetAllAssetCountStatusQuery,
        Result<PagingSortingFiltering<AssetCountStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetCountStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetCountStatusDetailsResponse>>> Handle(
        GetAllAssetCountStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetCountStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetCountStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetCountStatusDetailsResponse>>.Success(result);
    }
}