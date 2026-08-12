using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssetStatus.Queries;

public class GetAllAssetStatusQuery
: IQuery<Result<PagingSortingFiltering<AssetStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssetStatusQueryHandler :
    IQueryHandler<GetAllAssetStatusQuery,
        Result<PagingSortingFiltering<AssetStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssetStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssetStatusDetailsResponse>>> Handle(
        GetAllAssetStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssetStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssetStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssetStatusDetailsResponse>>.Success(result);
    }
}